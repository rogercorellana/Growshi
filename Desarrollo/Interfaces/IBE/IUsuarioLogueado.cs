using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IBE
{
    /// <summary>
    /// Define el contrato mínimo para una entidad que puede iniciar sesión.
    /// Esto permite que el SessionService sea agnóstico al tipo concreto de Usuario.
    /// </summary>
    public interface IUsuarioLogueado
    {
      
        int IdUsuario { get; set; }
        string NombreUsuario { get; set; }
        int IdiomaPreferidoID { get; set; }

        List<string> Permisos { get; set; }

    }
}
