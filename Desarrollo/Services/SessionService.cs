using Interfaces.IBE;
using Interfaces.IServices;

namespace Services
{
    // Este es tu módulo de sesión 100% reutilizable.
    public sealed class SessionService<T> : ISessionService<T> where T : class, IUsuarioLogueado
    {
        private static readonly ISessionService<T> _instancia = new SessionService<T>();

        public T UsuarioLogueado { get; private set; }

        private SessionService() { }

        public static ISessionService<T> GetInstance() => _instancia;

        public void Login(T usuario)
        {
            UsuarioLogueado = usuario;
        }

        public void Logout()
        {
            UsuarioLogueado = null;
        }
    }
}