using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILoginService
    {
        bool ValidarLogin(string passwordIngresada, string hashTraido);
    }
}
