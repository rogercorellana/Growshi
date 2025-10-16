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
        /// <summary>
        /// Obtiene la lista final de todos los PermisoID que un usuario tiene.
        /// </summary>
        public List<string> ObtenerPermisosPorUsuario(int usuarioId)
        {
            // Consulta corregida: se eliminó el filtro "WHERE pc.EsFamilia = 0"
            string consulta = @"
            ;WITH UserPermissions AS (
            -- 1. Punto de partida: Permisos asignados directamente a los roles del usuario
            SELECT tup.PermisoID
            FROM Usuario_TipoUsuario utu
            JOIN TipoUsuario_Permiso tup ON utu.TipoUsuarioID = tup.TipoUsuarioID
            WHERE utu.UsuarioID = @UsuarioID

            UNION ALL

            -- 2. Parte recursiva: Busca los hijos de los permisos ya encontrados
            SELECT child.PermisoID
            FROM PermisoComponente child
            JOIN UserPermissions up ON child.PadreID = up.PermisoID
            )
            -- 3. Selección final: Devuelve TODOS los permisos encontrados, sin filtrar.
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
