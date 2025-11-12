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
    public class rolesYPermisosPorUsuarioDAO
    {
        public static void AgregarPermisoAUsuario(string idParaAgregar, string idFamiliaPadre)
        {
            string permisoId = idParaAgregar;
            string usuarioNombre = idFamiliaPadre;

            if (string.IsNullOrWhiteSpace(permisoId))
            {
                throw new ArgumentException("El ID del permiso no puede estar vacío.", nameof(idParaAgregar));
            }
            if (string.IsNullOrWhiteSpace(usuarioNombre))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(idFamiliaPadre));
            }

            
            string consulta = @"
            INSERT INTO dbo.Usuario_Permiso (UsuarioID, PermisoID)
            SELECT
                u.UsuarioID,       -- El ID numérico del usuario
                @PermisoIDParam    -- El ID del permiso que pasamos
            FROM
                dbo.Usuario u
            WHERE
                u.UsuarioNombre = @UsuarioNombreParam -- Filtramos por el nombre

                -- Y SÓLO si la relación no existe ya (evita duplicados)
                AND NOT EXISTS (
                    SELECT 1
                    FROM dbo.Usuario_Permiso up
                    WHERE up.UsuarioID = u.UsuarioID
                      AND up.PermisoID = @PermisoIDParam
                );
        ";

            var parametros = new List<SqlParameter>
        {
            new SqlParameter("@PermisoIDParam", permisoId),
            new SqlParameter("@UsuarioNombreParam", usuarioNombre)
        };

            
            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
            }
            catch (SqlException sqlEx)
            {
                
                Console.WriteLine($"Error de SQL al agregar permiso: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado al agregar permiso: {ex.Message}");
                throw;
            }
        }

        public static DataTable ListarRolesAsociadosAlUsuario(string idUsuarioSeleccionado)
        {
            string usuarioNombre = idUsuarioSeleccionado;

            if (string.IsNullOrWhiteSpace(usuarioNombre))
            {
                Console.WriteLine("Error: El nombre de usuario no puede estar vacío.");
                return new DataTable("ErrorNombreVacio"); 
            }

            
            string consulta = @"
            SELECT
                pc.PermisoID,
                pc.NombreDescriptivo
            FROM
                dbo.Usuario u
            JOIN
                dbo.Usuario_Permiso up ON u.UsuarioID = up.UsuarioID
            JOIN
                dbo.PermisoComponente pc ON up.PermisoID = pc.PermisoID
            WHERE
                u.UsuarioNombre = @UsuarioNombreParam;
        ";

            var parametros = new List<SqlParameter> {
            new SqlParameter("@UsuarioNombreParam", usuarioNombre)
        };

            try
            {
                DataTable tabla = SqlHelper.GetInstance().ExecuteReader(consulta, parametros);
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar los roles asociados a {usuarioNombre}: {ex.Message}");
                throw;
            }
        }

        public static DataTable ListarRolesDelSistemaDisponibles(string idParaListarSusRolesDisponibles)
        {
            string usuarioNombre = idParaListarSusRolesDisponibles;

            if (string.IsNullOrWhiteSpace(usuarioNombre))
            {
                Console.WriteLine("Error: El nombre de usuario no puede estar vacío.");
                return new DataTable("ErrorNombreVacio"); 
            }

            
            string consulta = @"
        SELECT
            pc.PermisoID,
            pc.NombreDescriptivo
        FROM
            dbo.PermisoComponente pc
        WHERE
            NOT EXISTS (
                -- Subconsulta: Busca si existe una fila que vincule
                -- este permiso (pc.PermisoID) con el usuario dado (@UsuarioNombreParam).
                SELECT 1
                FROM dbo.Usuario_Permiso up
                JOIN dbo.Usuario u ON up.UsuarioID = u.UsuarioID
                WHERE
                    u.UsuarioNombre = @UsuarioNombreParam
                    AND up.PermisoID = pc.PermisoID
            );
    ";

            var parametros = new List<SqlParameter> {
        new SqlParameter("@UsuarioNombreParam", usuarioNombre)
    };

            try
            {
                DataTable tabla = SqlHelper.GetInstance().ExecuteReader(consulta, parametros);
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar los roles disponibles para {usuarioNombre}: {ex.Message}");
                throw;
            }
        }

        public static DataTable ListarUsuarios()
        {
            string consulta = @"
            SELECT DISTINCT 
                UsuarioNombre
            FROM 
                Usuario 
            ";

            return SqlHelper.GetInstance().ExecuteReader(consulta, null);
        }

        public static void QuitarPermisoAUsuario(string idParaQuitar, string idFamiliaPadre)
        {
            string permisoId = idParaQuitar.Trim();
            string usuarioNombre = idFamiliaPadre.Trim();

            if (string.IsNullOrWhiteSpace(permisoId))
            {
                throw new ArgumentException("El ID del permiso no puede estar vacío.", nameof(idParaQuitar));
            }
            if (string.IsNullOrWhiteSpace(usuarioNombre))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(idFamiliaPadre));
            }

          
            string consulta = @"
        DECLARE @UserID_INT int;

        -- Paso 1: Obtener el ID del usuario de forma segura
        SELECT @UserID_INT = u.UsuarioID
        FROM dbo.Usuario u
        WHERE TRIM(u.UsuarioNombre) = @UsuarioNombreParam;

        -- Paso 2: Borrar usando el ID numérico y el PermisoID
        IF @UserID_INT IS NOT NULL
        BEGIN
            DELETE FROM dbo.Usuario_Permiso
            WHERE UsuarioID = @UserID_INT
              AND TRIM(PermisoID) = @PermisoIDParam;
        END;
    ";

            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@PermisoIDParam", permisoId)
        {
            SqlDbType = SqlDbType.NVarChar,
            Size = 100
        },
        
        new SqlParameter("@UsuarioNombreParam", usuarioNombre)
        {
            SqlDbType = SqlDbType.VarChar,
            Size = 50
        }
    };

            try
            {
                SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de SQL al quitar permiso: {ex.Message}");
                throw;
            }
        }
    }
}
