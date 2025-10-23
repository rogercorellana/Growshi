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
    public class RolesYPermisosDAO
    {

        #region CRUD - 1ER DATAGRID FAMILIA DE ROLES 
        public void CrearFamiliaDeRoles(string permisoID, string nombreDescriptivo)
        {
            
            string query = "INSERT INTO PermisoComponente (PermisoID, NombreDescriptivo, EsFamilia) " +
                           "VALUES (@permisoID, @nombreDescriptivo, 1);";

            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@permisoID", permisoID),
            new SqlParameter("@nombreDescriptivo", nombreDescriptivo)
            };

            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error al crear la familia de roles: {ex.Message}");
                
            }

        }

        public DataTable ListarFamiliaDeRoles()
        {
            string consulta = @"
            SELECT DISTINCT 
                PermisoID,
                NombreDescriptivo
            FROM 
                PermisoComponente 
            WHERE 
                EsFamilia = 1";

            return SqlHelper.GetInstance().ExecuteReader(consulta, null);
        }

        public void ModificarFamiliaDeRoles(string idOriginal, string nuevoPermisoID, string nuevoNombreDescriptivo)
        {

            string query = "UPDATE PermisoComponente " +
                           "SET PermisoID = @nuevoPermisoID, NombreDescriptivo = @nuevoNombreDescriptivo " +
                           "WHERE PermisoID = @idOriginal;";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@nuevoPermisoID", nuevoPermisoID),
                new SqlParameter("@nuevoNombreDescriptivo", nuevoNombreDescriptivo),
                new SqlParameter("@idOriginal", idOriginal)
            };

            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar la familia de roles: {ex.Message}");
            }
        }

        public void EliminarFamiliaDeRoles(string idParaBorrar)
        {
            
            string query = "DELETE FROM PermisoComponente WHERE PermisoID = @permisoID;";

            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@permisoID", idParaBorrar)
            };

            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la familia de roles: {ex.Message}");
                
            }
        }

        #endregion




        public DataTable ListarTodosRolesDelSistema()
        {
            string consulta = @"
            SELECT DISTINCT 
                PermisoID,
                NombreDescriptivo
            FROM 
                PermisoComponente 
            ";

            return SqlHelper.GetInstance().ExecuteReader(consulta, null);
        }

        public DataTable ListarRolesAsociadosAfamilia(string idParaListarSuFamilia)
        {
            // 1. Define la consulta SQL de selección.
            // Selecciona solo las columnas pedidas donde el PadreID coincida.
            string query = "SELECT PermisoID, NombreDescriptivo " +
                           "FROM PermisoComponente " +
                           "WHERE PadreID = @padreID;";

            // 2. Crea la lista de parámetros SQL.
            var parameters = new List<SqlParameter>
            {
            // Asigna el ID recibido al parámetro de la consulta.
            new SqlParameter("@padreID", idParaListarSuFamilia)
            };

            // 3. Ejecuta la consulta (ExecuteReader) y devuelve los resultados.
            try
            {
                // Asumo que llamas al ExecuteReader a través de tu helper,
                // igual que hiciste con ExecuteNonQuery.
                return SqlHelper.GetInstance().ExecuteReader(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar los roles asociados: {ex.Message}");
                // Si ocurre un error, devuelve una tabla vacía para evitar
                // que el programa se caiga si no se maneja la excepción más arriba.
                return new DataTable();

                // O si prefieres que la capa superior sepa del error:
                // throw;
            }
        }

        // VERSIÓN MEJORADA (Incluye los que tienen PadreID = NULL)
        public DataTable ListarRolesDelSistemaDisponibles(string idParaListarSusRolesDisponibles)
        {
            // 1. Define la consulta SQL.
            // Condición: Donde PadreID es distinto AL ID que pasamos,
            // O (OR) donde PadreID es NULL.
            string query = "SELECT PermisoID, NombreDescriptivo " +
                           "FROM PermisoComponente " +
                           "WHERE (PadreID <> @idExcluir OR PadreID IS NULL);";

            // 2. Crea la lista de parámetros SQL.
            var parameters = new List<SqlParameter>
        {
            new SqlParameter("@idExcluir", idParaListarSusRolesDisponibles)
        };

            // 3. Ejecuta la consulta.
            try
            {
                return SqlHelper.GetInstance().ExecuteReader(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar roles disponibles: {ex.Message}");
                return new DataTable();
            }
        }
    }
}
