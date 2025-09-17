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
        // El nombre de la propiedad en tu clase Usuario es 'IdUsuario', 
        // pero es una buena práctica usar nombres genéricos como 'Id' en las interfaces.
        // La clase Usuario implementará esto sin problemas.
        int IdUsuario { get; set; }
        string NombreUsuario { get; set; }
    }
}
