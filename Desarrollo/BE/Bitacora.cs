using Interfaces.IBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora : IBitacora 
    {
        public int BitacoraID { get; set; }
        public DateTime FechaHora { get; set; }

        public NivelCriticidad Nivel { get; set; }
        public string Mensaje { get; set; }
        public string Modulo { get; set; }
        public int? UsuarioID { get; set; }
    }
}
