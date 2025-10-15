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
        private readonly ISessionService<Usuario> _sessionService; 
        private readonly IBitacoraService _bitacoraService;
        private readonly BitacoraDAO _bitacoraDAO;
        private readonly PermisoDAO _permisoDAO; 


        public UsuarioBLL()
        {
            usuarioDAO = new UsuarioDAO();
            loginservice = new LoginService();

            _sessionService = SessionService<Usuario>.GetInstance(); 
            _bitacoraService = BitacoraService.GetInstance();
            _bitacoraDAO = new BitacoraDAO();
            _permisoDAO = new PermisoDAO();
        }

        public Usuario Login(string usernameTextBox, string passwordTextBox)
        {

            #region 1 - Validacion Formulario 

            if (string.IsNullOrWhiteSpace(usernameTextBox) || string.IsNullOrWhiteSpace(passwordTextBox))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }

            #endregion


            #region 2 - Armado de DataTable llamando a la DAO y validacion de Intentos




            DataTable tablaUsuario = usuarioDAO.ObtenerDatosCrudosPorNombre(usernameTextBox);

            #region --- REGISTRO EN BITÁCORA --- (Login - UsuarioInexistente)

            if (tablaUsuario.Rows.Count == 0)
            {
                
                IBitacora eventoUsuarioInexistente = _bitacoraService.CrearEvento(
                    NivelCriticidad.Advertencia,
                    $"Intento de login para un usuario inexistente: '{usernameTextBox}'.",
                    "Login"
                // Como el usuario no existe, no pasamos un ID de usuario.
                );

               
                Bitacora bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoUsuarioInexistente.Nivel,
                    Mensaje = eventoUsuarioInexistente.Mensaje,
                    Modulo = eventoUsuarioInexistente.Modulo,
                    UsuarioID = eventoUsuarioInexistente.UsuarioID
                };

                _bitacoraDAO.Guardar(bitacoraParaGuardar);



                return null;
            }

            #endregion

            DataRow filaUsuario = tablaUsuario.Rows[0];
            int intentos = Convert.ToInt32(filaUsuario["UsuarioIntentos"]);
            string contraseñaGuardada = filaUsuario["UsuarioContraseña"].ToString(); // <--  hash
            int usuarioId = Convert.ToInt32(filaUsuario["UsuarioID"]);

            if (intentos > 3)
            {
                throw new CuentaBloqueadaException("Su cuenta está bloqueada por exceso de intentos. Contactar con un administrador! ");
            }

            #endregion


            #region 3 - Validacion de contraseñas mediante servicio de Login y conclusiones

            bool loginEsValido = loginservice.ValidarLogin(passwordTextBox, contraseñaGuardada);

            if (loginEsValido)
            {
                if (intentos > 0)
                {
                    usuarioDAO.ActualizarIntentos(usuarioId, 0);
                }

                Usuario usuario = UsuarioMapper.MapearDesdeDataRow(filaUsuario);

                // Lleno la lista de permisos del usuario
                usuario.Permisos = _permisoDAO.ObtenerPermisosPorUsuario(usuario.IdUsuario);

                // Guardo el objeto Usuario COMPLETO (con permisos) en la sesión
                _sessionService.Login(usuario);




                #region --- REGISTRO EN BITÁCORA --- (Login - Login Exitoso)

                IBitacora eventoLogin = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Inicio de sesión exitoso para el usuario '{usuario.NombreUsuario}'.",
                    "Login",
                    usuario.IdUsuario
                );

                Bitacora bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoLogin.Nivel,
                    Mensaje = eventoLogin.Mensaje,
                    Modulo = eventoLogin.Modulo,
                    UsuarioID = eventoLogin.UsuarioID
                     

                };

                _bitacoraDAO.Guardar(bitacoraParaGuardar);

                #endregion

                return usuario;




            }
            else
            {
                usuarioDAO.ActualizarIntentos(usuarioId, intentos + 1);

                #region --- REGISTRO EN BITÁCORA --- (Login - Login Fallido)

                IBitacora eventoFallo = _bitacoraService.CrearEvento(
                    NivelCriticidad.Advertencia,
                    $"Intento de inicio de sesión fallido para el usuario con ID {usuarioId}.",
                    "Login",
                    usuarioId
                );

                Bitacora bitacoraParaGuardar = new Bitacora
                {
                    Nivel = eventoFallo.Nivel,
                    Mensaje = eventoFallo.Mensaje,
                    Modulo = eventoFallo.Modulo,
                    UsuarioID = eventoFallo.UsuarioID
                };

                _bitacoraDAO.Guardar(bitacoraParaGuardar);

            

                #endregion

                return null;


            }

            #endregion
        }
    }
}
