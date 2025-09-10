using BE;
using Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public sealed class SessionManager : ISessionService
    {
        private static readonly ISessionService _instancia = new SessionManager();

        public Usuario UsuarioLogueado { get; private set; }

        private SessionManager() { }

        // método estático para obtener la instancia a través de la interfaz.
        public static ISessionService GetInstance()
        {
            return _instancia;
        }

        public void Login(Usuario usuario)
        {
            UsuarioLogueado = usuario;
        }

        public void Logout()
        {
            UsuarioLogueado = null;
        }
    }
}
