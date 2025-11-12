using DAL.Daos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RolesYPermisosPorUsuarioBLL
    {
        public void AgregarPermisoAUsuario(string idParaAgregar, string idFamiliaPadre)
        {
            rolesYPermisosPorUsuarioDAO.AgregarPermisoAUsuario(idParaAgregar, idFamiliaPadre);
        }

        public DataTable ListarRolesAsociadosAlUsuario(string idUsuarioSeleccionado)
        {
            return rolesYPermisosPorUsuarioDAO.ListarRolesAsociadosAlUsuario(idUsuarioSeleccionado);
        }

        public DataTable ListarRolesDelSistemaDisponibles(string idUsuarioSeleccionado)
        {
            return rolesYPermisosPorUsuarioDAO.ListarRolesDelSistemaDisponibles(idUsuarioSeleccionado);
        }

        public DataTable ListarUsuarios()
        {
            return rolesYPermisosPorUsuarioDAO.ListarUsuarios();
        }

        public void QuitarPermisoAUsuario(string idParaQuitar, string idFamiliaPadre)
        {
            rolesYPermisosPorUsuarioDAO.QuitarPermisoAUsuario(idParaQuitar, idFamiliaPadre);
        }
    }
}
