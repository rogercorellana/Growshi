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
            // Consulta para usar la tabla Permiso_Relacion
            string consulta = @"
            ;WITH UserPermissions AS (
                -- 1. Punto de partida: Permisos asignados directamente a los roles del usuario
                SELECT tup.PermisoID
            FROM Usuario_TipoUsuario utu
            JOIN TipoUsuario_Permiso tup ON utu.TipoUsuarioID = tup.TipoUsuarioID
            WHERE utu.UsuarioID = @UsuarioID

            UNION ALL

            -- 2. Parte recursiva: Busca los hijos usando la tabla de relación
            SELECT pr.HijoID   -- <-- SELECCIONAMOS EL HIJO
            FROM Permiso_Relacion pr -- <-- DESDE LA TABLA DE RELACION
            JOIN UserPermissions up ON pr.PadreID = up.PermisoID -- <-- DONDE EL PADRE es un permiso que ya tenemos
            )
            -- 3. Selección final: Devuelve TODOS los permisos (directos + recursivos)
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
