using System;

namespace BE
{
    public class Planta
    {
        public int PlantaID { get; set; }
        public string Nombre { get; set; }
        public int PlanCultivoID { get; set; }
        public string NombrePlan { get; set; }

        // --- AGREGADOS ---
        public DateTime FechaInicio { get; set; } // Lo que dijiste que faltaba
        public double? DiasTotalesPlan { get; set; }  // INDISPENSABLE para calcular la cosecha
    }
}