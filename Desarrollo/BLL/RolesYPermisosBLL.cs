using DAL.Daos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InicioUsuarioBLL
{
    public class RolesYPermisosBLL
    {

        RolesYPermisosDAO rolesYPermisosDAO = new RolesYPermisosDAO();

        public DataTable ListarFamiliaDeRoles()
        {
            return rolesYPermisosDAO.ListarFamiliaDeRoles();
        }

        public void ListarRolesAsociados()
        {

        }
        public DataTable ListarRolesDelSistema()
        {
            return rolesYPermisosDAO.ListarRolesDelSistema();

        }
    }
}
