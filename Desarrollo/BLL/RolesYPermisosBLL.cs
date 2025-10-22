using DAL.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InicioUsuarioBLL
{
    public class RolesYPermisosBLL
    {

        RolesYPermisosDAO rolesYPermisosDAO = new RolesYPermisosDAO();

        public void ListarFamiliaDeRoles()
        {
            rolesYPermisosDAO.ListarFamiliaDeRoles();
        }

        public void ListarRolesAsociados()
        {

        }
        public void ListarRolesDelSistema()
        {

        }
    }
}
