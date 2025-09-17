using Interfaces.IBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IServices
{
    /// <summary>
    /// Interfaz para un servicio de sesión genérico y con seguridad de tipos.
    /// La restricción "where" obliga a que el tipo 'T' que se use
    /// deba ser una clase que implemente IUsuarioLogueado.
    /// </summary>
    public interface ISessionService<T> where T : class, IUsuarioLogueado
    {
        T UsuarioLogueado { get; }
        void Login(T usuario);
        void Logout();
    }
}
