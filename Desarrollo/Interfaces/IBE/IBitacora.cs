using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IBE
{
    /// <summary>
    /// Define los niveles de criticidad estandarizados.
    /// Se ubica en 'Interfaces' para ser accesible por todas las capas sin acoplamiento.
    /// </summary>
    public enum NivelCriticidad
    {
        Info,
        Advertencia,
        Error,
        Critico
    }

    /// <summary>
    /// Define el contrato para una entidad de Bitácora.
    /// </summary>
    public interface IBitacora
    {
        int BitacoraID { get; set; }
        int? UsuarioID { get; set; }
        DateTime FechaHora { get; set; }
        NivelCriticidad Nivel { get; set; }
        string Modulo { get; set; }
        string Mensaje { get; set; }
    }
}
