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
            string consulta = @"
                ;WITH UserPermissions AS (
                    SELECT tup.PermisoID
                    FROM Usuario_TipoUsuario utu
                    JOIN TipoUsuario_Permiso tup ON utu.TipoUsuarioID = tup.TipoUsuarioID
                    WHERE utu.UsuarioID = @UsuarioID
                    UNION ALL
                    SELECT child.PermisoID
                    FROM PermisoComponente child
                    JOIN UserPermissions up ON child.PadreID = up.PermisoID
                )
                SELECT DISTINCT pc.PermisoID
                FROM UserPermissions up
                JOIN PermisoComponente pc ON up.PermisoID = pc.PermisoID
                WHERE pc.EsFamilia = 0;";

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
