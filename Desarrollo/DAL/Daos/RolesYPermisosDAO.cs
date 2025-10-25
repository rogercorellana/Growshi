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
            // Condición: Donde PadreID es distinto AL ID que pasamos (O es NULL)
            // Y ADEMÁS (AND), donde el propio PermisoID sea distinto al ID que pasamos.
            string query = "SELECT PermisoID, NombreDescriptivo " +
                           "FROM PermisoComponente " +
                           "WHERE (PadreID <> @idExcluir OR PadreID IS NULL) " + // Excluye a los hijos
                           "AND (PermisoID <> @idExcluir);";                     // Excluye a sí mismo

            // 2. Crea la lista de parámetros SQL.
            var parameters = new List<SqlParameter>
            {
            // El parámetro @idExcluir ahora se usa en dos partes del WHERE
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


        //
        // Asumo que esta clase es tu RolesYPermisosBLL

        // MÉTODO PRINCIPAL
        public void AgregarPermisoComponenteAFamilia(string idPermisoHijo, string idFamiliaPadre)
        {
            // --- 1. VALIDACIÓN DE BUCLE INFINITO ---
            // (Esta es la validación que recordamos hacer)
            if (ValidarCircularidad(idPermisoHijo, idFamiliaPadre))
            {
                // Si es true, hay un bucle. Detenemos la operación.
                throw new Exception("Error de referencia circular: " +
                    "No se puede agregar un rol/familia como hijo de uno de sus propios descendientes.");
            }

            // --- 2. SI LA VALIDACIÓN PASA, EJECUTAMOS LA ACTUALIZACIÓN ---

            // La consulta es un UPDATE para asignar el nuevo PadreID
            string query = "UPDATE PermisoComponente " +
                           "SET PadreID = @idPadre " +
                           "WHERE PermisoID = @idHijo;";

            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@idPadre", idFamiliaPadre),
            new SqlParameter("@idHijo", idPermisoHijo)
            };

            try
            {
                // Usamos ExecuteNonQuery porque es un UPDATE
                SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar permiso a la familia: {ex.Message}");
                // Relanzamos la excepción para que la capa de UI (el formulario) la vea
                throw;
            }
        }


        // --- MÉTODOS PRIVADOS DE VALIDACIÓN ---

        /// <summary>
        /// Valida si se está intentando crear un bucle.
        /// Sube por el árbol de ancestros del 'idPadre' para ver si 'idHijo' es uno de ellos.
        /// </summary>
        /// <param name="idHijo">El permiso que se quiere agregar (ej: Permisos_Nivel3)</param>
        /// <param name="idPadre">La familia a la que se quiere agregar (ej: MenuStrip_configuracionMenuItem)</param>
        /// <returns>True si hay un bucle, False si es seguro.</returns>
        private bool ValidarCircularidad(string idHijo, string idPadre)
        {
            string ancestroActual = idPadre;

            // Usamos un bucle 'while' para "subir" por el árbol
            // mientras el ancestro no sea null (es decir, no lleguemos a la raíz).
            while (ancestroActual != null)
            {
                // El bucle se detecta si el permiso que queremos agregar (idHijo)
                // es igual a uno de los ancestros del padre.
                if (ancestroActual == idHijo)
                {
                    return true; // ¡Bucle detectado!
                }

                // Si no hay bucle, "subimos" al siguiente nivel
                // pidiéndole el PadreID al ancestro actual.
                ancestroActual = GetPadreID(ancestroActual);
            }

            // Si salimos del bucle (llegamos a un PadreID null), no hay bucle.
            return false;
        }

        /// <summary>
        /// Método helper que usa ExecuteReader para obtener el PadreID de un componente.
        /// </summary>
        private string GetPadreID(string idComponente)
        {
            string query = "SELECT PadreID FROM PermisoComponente WHERE PermisoID = @id;";

            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@id", idComponente)
            };

            try
            {
                // Usamos ExecuteReader porque es un SELECT
                DataTable dt = SqlHelper.GetInstance().ExecuteReader(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Verificamos si el PadreID es NULL en la base de datos
                    if (dt.Rows[0]["PadreID"] != DBNull.Value)
                    {
                        return dt.Rows[0]["PadreID"].ToString();
                    }
                }

                // Si no tiene padre o no se encontró, devuelve null.
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener PadreID para validación: {ex.Message}");
                // En caso de error, es más seguro asumir que hay un problema y relanzar
                throw;
            }
        }
    }
}
