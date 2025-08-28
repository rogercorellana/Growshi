using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public string usuarioId { get; set; }
        public string contraseña { get; set; }
        public string claveRecuperacion { get; set; }
        public int IntentosUsuario { get; set; }


    }
}
