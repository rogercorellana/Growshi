using BE;
using DAL;
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

        public UsuarioBLL()
        {
            usuarioDAO = new UsuarioDAO();
        }


        public Usuario ValidarLogin(string nombreUsuario, string contraseñaIngresada)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contraseñaIngresada))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }

            DataTable tablaUsuario = usuarioDAO.ObtenerDatosCrudosPorNombre(nombreUsuario);

            if (tablaUsuario.Rows.Count == 0)
            {
                // Usuario no existe. Devolvemos null para que la UI dé un mensaje genérico.
                return null;
            }

            //cargo dataTable
            DataRow filaUsuario = tablaUsuario.Rows[0];
            int intentos = Convert.ToInt32(filaUsuario["UsuarioIntentos"]);
            int usuarioId = Convert.ToInt32(filaUsuario["UsuarioID"]);
            string contraseñaGuardada = filaUsuario["UsuarioContraseña"].ToString();

            //Regla de Negocio: ¿La cuenta está bloqueada?

            if (intentos >= 3)
            {
                throw new CuentaBloqueadaException("La cuenta está bloqueada por exceso de intentos.");
            }

            //Regla de Negocio: ¿La contraseña es correcta?

            if (contraseñaIngresada == contraseñaGuardada) // Recordar usar HASHES aquí
            {
                if (intentos > 0)
                {
                    usuarioDAO.ActualizarIntentos(usuarioId, 0);
                }
                // Usamos el Mapper y devolvemos el objeto Usuario seguro.
                return DAL.Mappers.UsuarioMapper.MapearDesdeDataRow(filaUsuario);
            }
            else
            {
                // Contraseña incorrecta. Incrementamos intentos.
                usuarioDAO.ActualizarIntentos(usuarioId, intentos + 1);
                // Si este fue el TERCER intento fallido, la próxima vez entrará en el if de arriba.
                return null;
            }
        }




        }
}
