using BE;
using DAL.Daos;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;

namespace BLL
{
    public class InicioUsuarioBLL
    {
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService;
        private readonly BitacoraDAO _bitacoraDAO;

        public InicioUsuarioBLL()
        {
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance();
            _bitacoraDAO = new BitacoraDAO();
        }


        public void CerrarSesion(Usuario usuario)
        {

            #region Evento en bitácora - Sesion Cerrada

            IBitacora eventoLogout = _bitacoraService.CrearEvento(
                NivelCriticidad.Info,
                $"Cierre de sesión para el usuario '{usuario.NombreUsuario}'.",
                "Sesión",
                usuario.IdUsuario
            );
            var bitacoraParaGuardar = new Bitacora
            {
                Nivel = eventoLogout.Nivel,
                Mensaje = eventoLogout.Mensaje,
                Modulo = eventoLogout.Modulo,
                UsuarioID = eventoLogout.UsuarioID
            };
            _bitacoraDAO.Guardar(bitacoraParaGuardar);
            _sessionService.Logout();

            #endregion



        }
    }
}