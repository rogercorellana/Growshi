using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DataMining
{
    public class AnalisisLuz
    {
        public string Dia { get; set; }
        public double PromedioLuz { get; set; } // 0 a 100%
        public double MetaLuz { get; set; }     // Debería ser 100% si está encendida
        public string Estado { get; set; }      // "Correcto", "Fallo Lámpara"
    }
}
