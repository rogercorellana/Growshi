using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DataMining
{
    public class PronosticoItem
    {
        public DateTime FechaHora { get; set; }
        public double TempPredicha { get; set; }
        public double HumedadPredicha { get; set; }
        public bool EsAnomalia { get; set; }
    }
}
