using Interfaces.IServices;

namespace Services
{
    // Este es tu módulo de sesión 100% reutilizable.
    public sealed class SessionService : ISessionService
    {
        private static readonly ISessionService _instancia = new SessionService();
        public object UsuarioLogueado { get; private set; }
        private SessionService() { }
        public static ISessionService GetInstance() => _instancia;

        public void Login(object usuario)
        {
            UsuarioLogueado = usuario;
        }

        public void Logout()
        {
            UsuarioLogueado = null;
        }
    }
}