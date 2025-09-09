using BE;
using DAL;
using DAL.Mappers;
using Interfaces;
using Interfaces.IBLL;
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
        //#region Patron Singleton 
        //private static UsuarioBLL _instancia;
        //private UsuarioBLL() { }
        //public static UsuarioBLL GetInstance
        //{
        //    get
        //    {
        //        if (_instancia == null)
        //        {
        //                    _instancia = new UsuarioBLL();

        //        }
        //        return _instancia;
        //    }
        //}
        //#endregion



        private readonly UsuarioDAO usuarioDAO;
        private readonly LoginService loginservice;


        public UsuarioBLL()
        {
            usuarioDAO = new UsuarioDAO();
            loginservice = new LoginService();
        }

        public Usuario Login(string username, string password)
        {
            // 0. Validacion formularios
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }

            // 1. Hablamos con la DAO para obtener los datos crudos.
            DataTable tablaUsuario = usuarioDAO.ObtenerDatosCrudosPorNombre(username);

            if (tablaUsuario.Rows.Count == 0)
            {
                //si no existen registros devuelvo null y corto
                return null;
            }

            // si si existen registros, es decir user existente en la DB
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
            bool loginEsValido = loginservice.ValidarLogin(password, contraseñaGuardada);

            // 5. REGLA DE NEGOCIO: Decidir qué hacer.
            if (loginEsValido)
            {
                if (intentos > 0)
                {
                    usuarioDAO.ActualizarIntentos(usuarioId, 0);
                }
                // Si el login es válido, AHORA SÍ creamos el objeto Usuario completo para devolverlo.
                return UsuarioMapper.MapearDesdeDataRow(filaUsuario);
            }
            else
            {
                usuarioDAO.ActualizarIntentos(usuarioId, intentos + 1);
                return null;
            }
        }



        }
}
