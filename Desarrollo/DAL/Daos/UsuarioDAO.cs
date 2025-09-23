using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Mappers;
using Interfaces;
using Interfaces.IDAL;

namespace DAL
{
    public class UsuarioDAO : IABM<Usuario>
    {
        /// <summary>
        /// Obtiene la fila completa de un usuario, incluyendo datos sensibles como la contraseña.
        /// Su propósito es ser usado por la BLL solo para el proceso de validación.
        /// </summary>
        /// <returns>Un DataTable con la fila del usuario, o un DataTable vacío si no se encuentra.</returns>
        public DataTable ObtenerDatosCrudosPorNombre(string nombreUsuario)
        {
            // La consulta trae todas las columnas necesarias para la validación.
            string consulta = "SELECT * FROM Usuario WHERE UsuarioNombre = @nombre"; // Ajusta el nombre de la columna si es diferente
            var parametros = new List<SqlParameter> { new SqlParameter("@nombre", nombreUsuario) };

            return SqlHelper.GetInstance().ExecuteReader(consulta, parametros);
        }

        /// <summary>
        /// Actualiza el contador de intentos de login fallidos para un usuario.
        /// </summary>
        public void ActualizarIntentos(int usuarioId, int nuevosIntentos)
        {
            string consulta = "UPDATE Usuario SET UsuarioIntentos = @intentos WHERE UsuarioID = @id"; // Ajusta los nombres de las columnas
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@intentos", nuevosIntentos),
                new SqlParameter("@id", usuarioId)
            };

            SqlHelper helper = SqlHelper.GetInstance();
            // NOTA: Asegúrate de que tu SqlHelper tenga una versión de ExecuteNonQuery que acepte parámetros.
            helper.ExecuteNonQuery(consulta, parametros);
        }


        //

        public void ActualizarEstadoSesion(int usuarioId, bool estaLogueado)
        {
            string consulta = "UPDATE Usuario SET EstaLogueado = @logueado, UltimaActividad = @fecha WHERE UsuarioID = @id";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@logueado", estaLogueado),
                new SqlParameter("@fecha", DateTime.Now),
                new SqlParameter("@id", usuarioId)
            };

            SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
        }


        /// <summary>
        /// Obtiene un usuario completo a partir de su ID.
        /// </summary>
        /// <returns>Un objeto Usuario, o null si no se encuentra.</returns>
        public Usuario ObtenerPorId(int usuarioId)
        {
            // La consulta solo trae los datos públicos del usuario.
            string consulta = "SELECT * FROM Usuario WHERE UsuarioID = @id";
            var parametros = new List<SqlParameter> { new SqlParameter("@id", usuarioId) };

            var tabla = SqlHelper.GetInstance().ExecuteReader(consulta, parametros);

            if (tabla.Rows.Count > 0)
            {
                // Usamos el mapper para convertir la primera (y única) fila.
                return UsuarioMapper.MapearDesdeDataRow(tabla.Rows[0]);
            }

            return null; // No se encontró el usuario.
        }

        public void Alta(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerTodos()
        {
            throw new NotImplementedException();
        }









        #region codigo anterior 
        //public Usuario ObtenerPorNombre(string nombreUsuario)
        //{
        //    string consulta = "SELECT UsuarioID, NombreUsuario, Email, IntentosUsuario FROM Usuario WHERE NombreUsuario = @nombre";
        //    var parametros = new List<SqlParameter> { new SqlParameter("@nombre", nombreUsuario) };

        //    SqlHelper helper = SqlHelper.GetInstance();
        //    DataTable tabla = helper.ExecuteReader(consulta, parametros);

        //    if (tabla.Rows.Count > 0)
        //    {
        //        // La llamada es ahora más limpia y directa
        //        return UsuarioMapper.MapearDesdeDataRow(tabla.Rows[0]);
        //    }
        //    return null;
        //}

        //// EJEMPLO DE USO DEL NUEVO ExecuteNonQuery
        //public void ActualizarIntentos(int usuarioId, int nuevosIntentos)
        //{
        //    string consulta = "UPDATE Usuario SET IntentosUsuario = @intentos WHERE UsuarioID = @id";
        //    var parametros = new List<SqlParameter>
        //{
        //    new SqlParameter("@intentos", nuevosIntentos),
        //    new SqlParameter("@id", usuarioId)
        //};

        //    SqlHelper helper = SqlHelper.GetInstance();
        //    helper.ExecuteNonQuery(consulta, parametros);
        //}
        #endregion
    }
}
