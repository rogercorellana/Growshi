using BE;
using DAL.DAO;
using DAL.Mappers;
using Interfaces;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class UsuarioDAO : IABM<Usuario>
    {
        
        public DataTable ObtenerDatosCrudosPorNombre(string nombreUsuario)
        {
            // La consulta trae todas las columnas necesarias para la validación.
            string consulta = "SELECT * FROM Usuario WHERE UsuarioNombre = @nombre"; 
            var parametros = new List<SqlParameter> { new SqlParameter("@nombre", nombreUsuario) };

            return SqlHelper.GetInstance().ExecuteReader(consulta, parametros);
        }

        
        public void ActualizarIntentos(int usuarioId, int nuevosIntentos)
        {
            string consulta = "UPDATE Usuario SET UsuarioIntentos = @intentos WHERE UsuarioID = @id";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@intentos", nuevosIntentos),
                new SqlParameter("@id", usuarioId)
            };

            SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
        }


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


       
        public Usuario ObtenerPorId(int usuarioId)
        {
            string consulta = "SELECT * FROM Usuario WHERE UsuarioID = @id";
            var parametros = new List<SqlParameter> { new SqlParameter("@id", usuarioId) };

            var tabla = SqlHelper.GetInstance().ExecuteReader(consulta, parametros);

            if (tabla.Rows.Count > 0)
            {
                return UsuarioMapper.MapearDesdeDataRow(tabla.Rows[0]);
            }

            return null; 
        }




        public void Crear(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public void ActualizarIdioma(int idUsuario, int nuevoIdiomaId)
        {
            string query = "UPDATE Usuario SET IdiomaPreferidoID = @idiomaId " +
                           "WHERE UsuarioID = @usuarioId;";

            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@idiomaId", nuevoIdiomaId),
        new SqlParameter("@usuarioId", idUsuario)
    };

            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el idioma en la BD: {ex.Message}");
                throw;
            }
        }

        public bool ValidarConexion()
        {
            // Usamos el método CheckConnection que devuelve true/false sin lanzar excepción
            bool conectado = SqlHelper.GetInstance().CheckConnection();

            return conectado;
        }

        public void GuardarCadenaConexion(string v1, string v2)
        {

            SqlHelper.GuardarCadenaConexion(v1, v2);
        }
    }
}
