using System;

namespace BE
{
    public class Medicion
    {
        public int MedicionID { get; set; }
        public int SlotID { get; set; }
        public DateTime FechaHora { get; set; }

        public decimal Temperatura { get; set; }
        public decimal Humedad { get; set; }

        // El BIT de SQL se mapea a bool en C#
        public bool LuzEncendida { get; set; }

        // Propiedad calculada útil para mostrar en Grillas o Textos
        public string EstadoLuzTexto => LuzEncendida ? "ON" : "OFF";
    }
}