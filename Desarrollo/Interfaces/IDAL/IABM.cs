using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IABM<T> where T : class
    {
        void Alta(T entidad);
        void Modificacion(T entidad);
        void Baja(int id);
        List<T> ObtenerTodos();
    }
}
