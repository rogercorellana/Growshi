using DAL.Daos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class GestionUsuariosBLL
    {

        GestionUsuariosDAO gestionUsuariosDAO = new GestionUsuariosDAO();

        
        public DataTable ListarUsuarios()
        {
            return gestionUsuariosDAO.ListarUsuarios();
        }


        public void CrearUsuario(string nombreUsuario, string contraseñaUsuario, string contraseñaRespaldo)
        {
            gestionUsuariosDAO.CrearUsuario(nombreUsuario, contraseñaUsuario, contraseñaRespaldo);
        }

        public void DesactivarUsuario(int idParaDesactivar)
        {
            gestionUsuariosDAO.DesactivarUsuario(idParaDesactivar);
        }

        public void ActivarUsuario(int idParaActivar)
        {
            gestionUsuariosDAO.ActivarUsuario(idParaActivar);
        }

        public void ActualizarUsuario(int usuarioId, string nuevoNombre, string passwordFinal, string nuevaRespaldo, int nuevosIntentos, int nuevoActivo)
        {
            gestionUsuariosDAO.ActualizarUsuario(usuarioId, nuevoNombre, passwordFinal, nuevaRespaldo, nuevosIntentos, nuevoActivo);
        }
    }
}
