using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface IABM<T> where T : class
    {
        void Crear(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
    }
}
