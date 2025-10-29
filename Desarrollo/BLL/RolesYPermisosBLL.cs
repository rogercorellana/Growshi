using System;
using System.Data;

namespace BLL.InicioUsuarioBLL
{
    public class RolesYPermisosBLL
    {
        RolesYPermisosDAO rolesYPermisosDAO = new RolesYPermisosDAO();

        public DataTable ListarRolesDelSistemaDisponibles(string idParaListarSusRolesDisponibles)
        {
            return rolesYPermisosDAO.ListarRolesDelSistemaDisponibles(idParaListarSusRolesDisponibles);
        }

        #region 1ER DATAGRID - FAMILIA DE ROLES

        public void CrearFamiliaDeRoles(string permisoID, string nombreDescriptivo)
        {
            rolesYPermisosDAO.CrearFamiliaDeRoles(permisoID, nombreDescriptivo);
        }

        public DataTable ListarFamiliaDeRoles()
        {
            return rolesYPermisosDAO.ListarFamiliaDeRoles();
        }

        public void EliminarFamiliaDeRoles(string idParaBorrar)
        {
            rolesYPermisosDAO.EliminarFamiliaDeRoles(idParaBorrar);
        }

        public void ModificarFamiliaDeRoles(string idOriginal, string idModificado, string descripcionFinal)
        {
            rolesYPermisosDAO.ModificarFamiliaDeRoles(idOriginal, idModificado, descripcionFinal);
        }

        public DataTable ListarRolesAsociadosAfamilia(string idParaListarSuFamilia)
        {
            return rolesYPermisosDAO.ListarRolesAsociadosAfamilia(idParaListarSuFamilia);
        }

        #endregion



        #region 2DO y 3ER DATAGRID - AGREGAR BORRAR PERMISOS a la familia
        public void AgregarPermisoComponenteAFamilia(string idPermisoHijo, string idFamiliaPadre)
        {
            if (idPermisoHijo == idFamiliaPadre)
            {
                throw new Exception("No puede agregarse un permiso a sí mismo.");
            }

            
            if (rolesYPermisosDAO.CheckearCircularidad(idPermisoHijo, idFamiliaPadre))
            {
                throw new Exception("Error de referencia circular: " +
                    "No se puede agregar una familia como hija de uno de sus propios descendientes.");
            }

            rolesYPermisosDAO.AgregarPermisoComponenteAFamilia(idPermisoHijo, idFamiliaPadre);
        }

        
        public void QuitarPermisoComponenteDeFamilia(string idPermisoHijo, string idFamiliaPadre)
        {
            rolesYPermisosDAO.QuitarPermisoComponenteDeFamilia(idPermisoHijo, idFamiliaPadre);
        }

        #endregion
    }
}