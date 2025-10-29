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

        
    }
}
