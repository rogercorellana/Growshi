using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Daos
{
    public class PermisoDAO
    {

        public List<string> ObtenerPermisosPorUsuario(int usuarioId)
        {
            // Consulta (CTE) actualizada para usar la nueva tabla Usuario_Permiso
            string consulta = @"
    ;WITH UserPermissions AS (
        -- 1. Punto de partida: Permisos asignados directamente al usuario
        --    Buscamos en la nueva tabla 'Usuario_Permiso'.
        SELECT up.PermisoID
        FROM dbo.Usuario_Permiso up
        WHERE up.UsuarioID = @UsuarioID

        UNION ALL

        -- 2. Parte recursiva: Busca los hijos usando la tabla de relación (Esta lógica no cambia)
        SELECT pr.HijoID   -- <-- SELECCIONAMOS EL HIJO
        FROM dbo.Permiso_Relacion pr
        JOIN UserPermissions up_cte ON pr.PadreID = up_cte.PermisoID -- <-- DONDE EL PADRE es un permiso que ya tenemos
    )
    -- 3. Selección final: Devuelve TODOS los permisos (directos + recursivos) sin duplicados
    SELECT DISTINCT PermisoID
    FROM UserPermissions;";

            var parametros = new List<SqlParameter> {
        new SqlParameter("@UsuarioID", usuarioId)
    };

            var tabla = SqlHelper.GetInstance().ExecuteReader(consulta, parametros);

            var permisos = new List<string>();
            foreach (DataRow fila in tabla.Rows)
            {
                permisos.Add(fila["PermisoID"].ToString());
            }

            return permisos;
        }
    }
}
