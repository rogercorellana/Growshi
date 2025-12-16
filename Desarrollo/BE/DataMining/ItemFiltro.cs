using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DataMining
{
   

    // Clase interna para el dropdown de filtros
    public class ItemFiltro
    {
        public string Clave { get; set; }
        public string Texto { get; set; }
        public override string ToString() => Texto;
    }
}
