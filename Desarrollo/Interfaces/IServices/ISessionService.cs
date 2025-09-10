using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IServices
{
    public interface ISessionService
    {
        Usuario UsuarioLogueado { get; }
        void Login(Usuario usuario);
        void Logout();
    }
}
