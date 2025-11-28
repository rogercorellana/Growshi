using System;
using System.Collections.Generic;

namespace BE
{
    public class PlanCultivo
    {
        public int PlanCultivoID { get; set; }
        public string NombrePlan { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Estado { get; set; }
        public List<EtapaCultivo> Etapas { get; set; } = new List<EtapaCultivo>();
        public override string ToString()
        {
            return NombrePlan;
        }
    }
}