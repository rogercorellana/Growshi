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

        public DataTable ListarFamiliaDeRoles()
        {
            // Se usa DISTINCT para evitar duplicados
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

        public DataTable ListarRolesDelSistema()
        {
            // Se usa DISTINCT para evitar duplicados
            string consulta = @"
            SELECT DISTINCT 
                PermisoID,
                NombreDescriptivo
            FROM 
                PermisoComponente 
            ";

            return SqlHelper.GetInstance().ExecuteReader(consulta, null);
        }
    }
}
