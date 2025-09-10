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
    // El contrato que define nuestro servicio de registro de eventos.
    // Es el "menú" que la BLL usará.
    public interface IBitacoraService
    {
        void Registrar(string mensaje, string criticidad);
    }
}
