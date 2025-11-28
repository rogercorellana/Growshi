using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Daos
{
    public class GestionUsuariosDAO
    {
        

        //CREATE
        public void CrearUsuario(string nombreUsuario, string contraseñaUsuario, string contraseñaRespaldo)
        {
            string query = "INSERT INTO Usuario (UsuarioNombre, UsuarioContraseña, UsuarioClaveRecuperacion, UsuarioIntentos)" +
                   "VALUES (@nombreUsuario, @contraseñaUsuario, @contraseñaRespaldo, 0);";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nombreUsuario", nombreUsuario),
                new SqlParameter("@contraseñaUsuario", contraseñaUsuario),
                new SqlParameter("@contraseñaRespaldo", contraseñaRespaldo)

            };

            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                throw;
            }
        }

        public void DesactivarUsuario(int idParaDesactivar)
        {
            string query = "UPDATE Usuario SET EstaActivo = 0 " +
                       "WHERE UsuarioID = @idParaDesactivar;";

            try
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@idParaDesactivar", idParaDesactivar)
        };
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al desactivar el usuario: {ex.Message}");
                throw;
            }
        }

        public void ActivarUsuario(int idParaActivar)
        {
            string query = "UPDATE Usuario SET EstaActivo = 1 " +
                                   "WHERE UsuarioID = @idParaActivar;";

            try
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@idParaActivar", idParaActivar)
        };
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al activar el usuario: {ex.Message}");
                throw;
            }
        }


        //READ
        public DataTable ListarUsuarios()
        {
            string consulta = @"
            SELECT DISTINCT 
                *
            FROM 
                Usuario 
            ";

            return SqlHelper.GetInstance().ExecuteReader(consulta, null);
        }

        // UPDATE (MODIFICAR USUARIO) - NUEVO MÉTODO
        public void ActualizarUsuario(int usuarioId, string nuevoNombre, string passwordFinal, string nuevaRespaldo, int nuevosIntentos, int nuevoActivo)
        {
            string query = @"UPDATE Usuario 
                             SET UsuarioNombre = @nombre,
                                 UsuarioContraseña = @pass,
                                 UsuarioClaveRecuperacion = @respaldo,
                                 UsuarioIntentos = @intentos,
                                 EstaActivo = @activo
                             WHERE UsuarioID = @id;";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", usuarioId),
                new SqlParameter("@nombre", nuevoNombre),
                new SqlParameter("@pass", passwordFinal),
                new SqlParameter("@respaldo", nuevaRespaldo),
                new SqlParameter("@intentos", nuevosIntentos),
                new SqlParameter("@activo", nuevoActivo)
            };

            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                throw;
            }
        }
    }
}
