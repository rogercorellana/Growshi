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
        object UsuarioLogueado { get; }
        void Login(object usuario);
        void Logout();
    }
}
