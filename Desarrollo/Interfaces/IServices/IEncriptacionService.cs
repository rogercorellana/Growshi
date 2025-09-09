using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IServices
{
    public interface IEncriptacionService
    {
        string Hashear(string texto);
        bool Verificar(string textoPlano, string textoHasheado);
    }
}
