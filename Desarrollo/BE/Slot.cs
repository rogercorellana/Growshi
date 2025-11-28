using System;

namespace BE
{
    public class Slot
    {
        public int SlotID { get; set; }

        // true = PRENDIDO (Funciona)
        // false = APAGADO (Roto/Mantenimiento)
        public bool SlotEstado { get; set; }

        // Si es null = Vacío. Si tiene numero = Ocupado.
        public int? PlantaAsociadaID { get; set; }

        // Propiedades Visuales
        public int NumeroVisual { get; set; }
        public string NombrePlanta { get; set; }
    }
}