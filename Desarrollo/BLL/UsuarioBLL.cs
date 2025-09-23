using BE;
using DAL;
using DAL.Daos;
using DAL.Mappers;
using Interfaces;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL 
    {
        private readonly UsuarioDAO usuarioDAO;
        private readonly LoginService loginservice;
        private readonly ISessionService<Usuario> _sessionService; // variable tipo genérico especificando que trabajará con 'Usuario'
        private readonly IBitacoraService _bitacoraService;
        private readonly BitacoraDAO _bitacoraDAO;
        private readonly PermisoDAO _permisoDAO; 


        public UsuarioBLL()
        {
            usuarioDAO = new UsuarioDAO();
            loginservice = new LoginService();

            _sessionService = SessionService<Usuario>.GetInstance(); // instancia del servicio genérico, especificando el tipo 'Usuario'
            _bitacoraService = BitacoraService.GetInstance();
            _bitacoraDAO = new BitacoraDAO();
            _permisoDAO = new PermisoDAO();
        }

        public Usuario Login(string usernameTextBox, string passwordTextBox)
        {
            // 0. Validacion formularios

            if (string.IsNullOrWhiteSpace(usernameTextBox) || string.IsNullOrWhiteSpace(passwordTextBox))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }

            // 1. Hablamos con la DAO para obtener los datos crudos.

            DataTable tablaUsuario = usuarioDAO.ObtenerDatosCrudosPorNombre(usernameTextBox);

            if (tablaUsuario.Rows.Count == 0)
            {
                // --- REGISTRO EN BITÁCORA ---

                // Paso 1: Llamas al servicio para que cree el objeto del evento.
                IBitacora eventoUsuarioInexistente = _bitacoraService.CrearEvento(
                    NivelCriticidad.Advertencia,
                    $"Intento de login para un usuario inexistente: '{usernameTextBox}'.",
                    "Login"
                // Como el usuario no existe, no pasamos un ID de usuario.
                );

                // Paso 2: Creas el objeto 'Bitacora' que el DAO necesita,
                //         copiando los datos del objeto que te dio el servicio.
                var bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoUsuarioInexistente.Nivel,
                    Mensaje = eventoUsuarioInexistente.Mensaje,
                    Modulo = eventoUsuarioInexistente.Modulo,
                    UsuarioID = eventoUsuarioInexistente.UsuarioID
                };

                // Paso 3: Llamas al DAO para guardarlo en la base de datos.
                _bitacoraDAO.Guardar(bitacoraParaGuardar);



                return null;
            }

            // 2. Extraemos los datos necesarios del DataRow.
            DataRow filaUsuario = tablaUsuario.Rows[0];
            int intentos = Convert.ToInt32(filaUsuario["UsuarioIntentos"]);
            string contraseñaGuardada = filaUsuario["UsuarioContraseña"].ToString(); // <--  hash
            int usuarioId = Convert.ToInt32(filaUsuario["UsuarioID"]);

            // 3. REGLA DE NEGOCIO: ¿Cuenta bloqueada?
            if (intentos > 3)
            {
                throw new CuentaBloqueadaException("Su cuenta está bloqueada por exceso de intentos. Contactar con un administrador! ");
            }

            // 4. DELEGACIÓN: Le pasamos los datos puros al servicio para que valide.
            bool loginEsValido = loginservice.ValidarLogin(passwordTextBox, contraseñaGuardada);

            // 5. REGLA DE NEGOCIO: Decidir qué hacer.
            if (loginEsValido)
            {
                if (intentos > 0)
                {
                    usuarioDAO.ActualizarIntentos(usuarioId, 0);
                }



                // 1. Mapear el usuario como siempre
                Usuario usuario = UsuarioMapper.MapearDesdeDataRow(filaUsuario);

                // ✅ 2. ¡Paso Clave! Llenar la lista de permisos del usuario
                usuario.Permisos = _permisoDAO.ObtenerPermisosPorUsuario(usuario.IdUsuario);

                // 3. Guardar el objeto Usuario COMPLETO (con permisos) en la sesión
                _sessionService.Login(usuario);




                // --- REGISTRO EN BITÁCORA ---

                // Paso 1: Llamas al servicio para que cree el evento.
                IBitacora eventoLogin = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Inicio de sesión exitoso para el usuario '{usuario.NombreUsuario}'.",
                    "Login",
                    usuario.IdUsuario
                );

                // Paso 2: Creas el objeto 'Bitacora' que el DAO necesita.
                var bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoLogin.Nivel,
                    Mensaje = eventoLogin.Mensaje,
                    Modulo = eventoLogin.Modulo,
                    UsuarioID = eventoLogin.UsuarioID
                     

                };

                // Paso 3: Llamas al DAO para guardarlo.
                _bitacoraDAO.Guardar(bitacoraParaGuardar);


                return usuario;



            }
            else
            {
                usuarioDAO.ActualizarIntentos(usuarioId, intentos + 1);

                // --- REGISTRO DE LOGIN FALLIDO ---

                // Paso 1: Crear el evento.
                IBitacora eventoFallo = _bitacoraService.CrearEvento(
                    NivelCriticidad.Advertencia,
                    $"Intento de inicio de sesión fallido para el usuario con ID {usuarioId}.",
                    "Login",
                    usuarioId
                );

                // Paso 2: Mapear a la entidad.
                var bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoFallo.Nivel,
                    Mensaje = eventoFallo.Mensaje,
                    Modulo = eventoFallo.Modulo,
                    UsuarioID = eventoFallo.UsuarioID
                };

                // Paso 3: Guardar.
                _bitacoraDAO.Guardar(bitacoraParaGuardar);

                return null;
            }
        }
    }
}
