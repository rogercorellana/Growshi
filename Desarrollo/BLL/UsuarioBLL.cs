using BE;
using DAL;
using DAL.Mappers;
using Interfaces;
using Interfaces.IBLL;
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
    public class UsuarioBLL : IUsuarioBLL
    {

        private readonly UsuarioDAO usuarioDAO;
        private readonly LoginService loginservice;
        private readonly ISessionService _sessionService;


        public UsuarioBLL()
        {
            usuarioDAO = new UsuarioDAO();
            loginservice = new LoginService();
            _sessionService = SessionService.GetInstance();

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
                //si no existen registros devuelvo null y corto
                return null;
            }

            // si existen registros, es decir user existente en la DB

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
                // Si el login es válido, AHORA SÍ creamos el objeto Usuario completo para devolverlo.
                
                Usuario usuario = UsuarioMapper.MapearDesdeDataRow(filaUsuario);

                // La BLL, que sí conoce al Usuario, se lo pasa al servicio genérico.
                _sessionService.Login(usuario);

                return usuario;
                
            }
            else
            {
                usuarioDAO.ActualizarIntentos(usuarioId, intentos + 1);
                return null;
            }
        }



        }
}
