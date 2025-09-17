using Interfaces.IBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IServices
{
    public interface IBitacoraService
    {
        /// <summary>
        /// Crea un objeto de evento de bitácora estandarizado.
        /// </summary>
        /// <returns>Un objeto que cumple con el contrato IBitacora.</returns>
        IBitacora CrearEvento(NivelCriticidad nivel, string mensaje, string modulo = null, int? usuarioId = null);
    }
}
