using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DataMining
{
    // DTO para traer datos crudos del SQL
    public class MedicionDW
    {
        public DateTime FechaHora { get; set; }
        public int Hora { get; set; } // 0-23
        public double Temperatura { get; set; }
        public double Humedad { get; set; }
        public int Luminosidad { get; set; }
    }
}
