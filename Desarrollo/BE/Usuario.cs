using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Representa a un usuario autenticado dentro de la aplicación.
    /// Esta clase es un DTO seguro que no contiene datos sensibles.
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IntentosUsuario { get; set; }


    }
}
