using BE;
using Interfaces.IBE;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IServices
{
    public interface IBitacoraService
    {
        DataTable Registrar(string mensaje, int usuario);
    }
}
