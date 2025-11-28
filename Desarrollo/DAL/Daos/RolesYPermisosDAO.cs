using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class RolesYPermisosDAO
{
    #region CRUD - 1ER DATAGRID FAMILIA DE ROLES

    public void CrearFamiliaDeRoles(string permisoID, string nombreDescriptivo)
    {
        string query = "INSERT INTO PermisoComponente (PermisoID, NombreDescriptivo) " +
                       "VALUES (@permisoID, @nombreDescriptivo);";

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
            throw;
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
            ";

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
            throw;
        }
    }

    public void EliminarFamiliaDeRoles(string idParaBorrar)
    {
        // Esta consulta única ejecuta todo como una transacción:
        // 1. Borra el permiso de cualquier relación jerárquica (padre o hijo).
        // 2. Borra el permiso de la tabla principal 'PermisoComponente'.
        // 3. (Automático) La BD borrará las asignaciones en 'Usuario_Permiso'
        //    gracias al 'ON DELETE CASCADE'.
        string queryTransaccional = @"
    SET XACT_ABORT ON; -- Asegura que la transacción se revierta si hay un error
    BEGIN TRANSACTION;

    -- 1. Eliminar de la tabla de relaciones (no tiene ON DELETE CASCADE)
    DELETE FROM [dbo].[Permiso_Relacion]
    WHERE [PadreID] = @permisoID OR [HijoID] = @permisoID;
    
    -- 2. Eliminar de la tabla principal (esto dispara el CASCADE)
    DELETE FROM [dbo].[PermisoComponente]
    WHERE [PermisoID] = @permisoID;

    COMMIT TRANSACTION;
    ";

        try
        {
            // Solo necesitamos una lista de parámetros
            var parameters = new List<SqlParameter>
        {
            new SqlParameter("@permisoID", idParaBorrar)
        };

            // Ejecutamos la transacción completa en una sola llamada
            SqlHelper.GetInstance().ExecuteNonQuery(queryTransaccional, parameters);
        }
        catch (Exception ex)
        {
            // Si la transacción falla (BEGIN TRAN sin COMMIT), SQL Server
            // la revierte automáticamente al detectar el error (gracias a XACT_ABORT).
            Console.WriteLine($"Error al eliminar el permiso componente: {ex.Message}");
            throw; // Re-lanzar la excepción para que la capa superior se entere
        }
    }

    #endregion



    #region CRUD - 2DO Y 3ER DGV
    public DataTable ListarRolesAsociadosAfamilia(string idParaListarSuFamilia)
    {
        string query = "SELECT p.PermisoID, p.NombreDescriptivo " +
                       "FROM PermisoComponente p " +
                       "JOIN Permiso_Relacion r ON p.PermisoID = r.HijoID " +
                       "WHERE r.PadreID = @padreID;";

        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@padreID", idParaListarSuFamilia)
        };

        try
        {
            return SqlHelper.GetInstance().ExecuteReader(query, parameters);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar los roles asociados: {ex.Message}");
            return new DataTable();
        }
    }

   
    public DataTable ListarRolesDelSistemaDisponibles(string idParaListarSusRolesDisponibles)
    {
        string query =
            "WITH Descendientes (PermisoID) AS (" +
            "   SELECT HijoID " +
            "   FROM Permiso_Relacion " +
            "   WHERE PadreID = @idExcluir " +
            "   UNION ALL " +
            "   SELECT r.HijoID " +
            "   FROM Permiso_Relacion r " +
            "   INNER JOIN Descendientes d ON r.PadreID = d.PermisoID " +
            ") " +
            "SELECT PermisoID, NombreDescriptivo " +
            "FROM PermisoComponente " +
            "WHERE PermisoID NOT IN (SELECT PermisoID FROM Descendientes) " +
            "AND PermisoID <> @idExcluir;";

        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@idExcluir", idParaListarSusRolesDisponibles)
        };

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

    
    public void AgregarPermisoComponenteAFamilia(string idPermisoHijo, string idFamiliaPadre)
    {
        string query = "INSERT INTO Permiso_Relacion (PadreID, HijoID) " +
                       "VALUES (@idPadre, @idHijo);";

        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@idPadre", idFamiliaPadre),
            new SqlParameter("@idHijo", idPermisoHijo)
        };

        try
        {
            SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
        }
        catch (SqlException ex) when (ex.Number == 2627)
        {
            throw new Exception("Este permiso ya está asignado a la familia.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar permiso a la familia: {ex.Message}");
            throw;
        }
    }

    
    public void QuitarPermisoComponenteDeFamilia(string idPermisoHijo, string idFamiliaPadre)
    {
        string query = "DELETE FROM Permiso_Relacion " +
                       "WHERE PadreID = @idPadre AND HijoID = @idHijo;";

        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@idPadre", idFamiliaPadre),
            new SqlParameter("@idHijo", idPermisoHijo)
        };

        try
        {
            SqlHelper.GetInstance().ExecuteNonQuery(query, parameters);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al quitar permiso de la familia: {ex.Message}");
            throw;
        }
    }

    // (validación de circularidad que usa CTE)
    public bool CheckearCircularidad(string idHijo, string idPadre)
    {
        // Esta CTE "sube" por el árbol desde idPadre buscando a idHijo
        string query =
            "WITH Ancestros (AncestroID) AS (" +
            "   SELECT PadreID " +
            "   FROM Permiso_Relacion " +
            "   WHERE HijoID = @idPadre " +
            "   UNION ALL " +
            "   SELECT r.PadreID " +
            "   FROM Permiso_Relacion r " +
            "   INNER JOIN Ancestros a ON r.HijoID = a.AncestroID " +
            ") " +
            "SELECT 1 FROM Ancestros WHERE AncestroID = @idHijo;";

        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@idPadre", idPadre),
            new SqlParameter("@idHijo", idHijo)
        };

        try
        {
            DataTable dt = SqlHelper.GetInstance().ExecuteReader(query, parameters);
            // Si devuelve una fila, es que encontró un bucle.
            return (dt.Rows.Count > 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al chequear circularidad: {ex.Message}");
            throw;
        }
    }

    #endregion
}