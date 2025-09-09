using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IBLL
{
    // El contrato que la UI usará para hablar con la BLL.
    public interface IUsuarioBLL
    {
        Usuario Login(string username, string password);
    }
}
