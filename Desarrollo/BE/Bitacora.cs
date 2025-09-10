using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        // Puedes agregar más campos como Criticidad, Módulo, etc.
    }
}
