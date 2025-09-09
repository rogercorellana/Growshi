using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILoginService
    {
        // El servicio recibe la contraseña en texto plano Y el usuario que la BLL ya buscó en la BD.
        // Devuelve 'true' si el login es válido.
        bool ValidarLogin(string passwordIngresada, string hashTraido);
    }
}
