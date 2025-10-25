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

        

        public void ListarRolesAsociados()
        {

        }
        public DataTable ListarTodosRolesDelSistema()
        {
            return rolesYPermisosDAO.ListarTodosRolesDelSistema();

        }
        public DataTable ListarRolesDelSistemaDisponibles(string idParaListarSusRolesDisponibles)
        {
            return rolesYPermisosDAO.ListarRolesDelSistemaDisponibles(idParaListarSusRolesDisponibles);

        }


        #region 1ER DATAGRID - FAMILIA DE ROLES
        //   

        //CREAR
        public void CrearFamiliaDeRoles(string permisoID, string nombreDescriptivo)
        {
            rolesYPermisosDAO.CrearFamiliaDeRoles(permisoID,nombreDescriptivo);
        }


        //LISTAR
        public DataTable ListarFamiliaDeRoles()
        {
            return rolesYPermisosDAO.ListarFamiliaDeRoles();
        }

        //BORRAR
        public void EliminarFamiliaDeRoles(string idParaBorrar)
        {
            rolesYPermisosDAO.EliminarFamiliaDeRoles(idParaBorrar);
        }

        //MODIFICAR
        public void ModificarFamiliaDeRoles(string idOriginal, string idModificado, string descripcionFinal)
        {
            rolesYPermisosDAO.ModificarFamiliaDeRoles(idOriginal,idModificado,descripcionFinal);
        }

        public DataTable ListarRolesAsociadosAfamilia(string idParaListarSuFamilia)
        {
            return rolesYPermisosDAO.ListarRolesAsociadosAfamilia(idParaListarSuFamilia);
        }

        #endregion

        //





        



        //agregar del 3er datagrid al 2do datagrid
        public void AgregarPermisoComponenteAFamilia(string idParaAgregar, string idFamiliaPadre)
        {
            rolesYPermisosDAO.AgregarPermisoComponenteAFamilia(idParaAgregar, idFamiliaPadre);
        }
    }
}
