
using System;

namespace BE
{
    public class Medicion
    {
        // 1. AGREGADO: El ID único de la tabla (Primary Key)
        // Lo necesitas para consultar datos históricos después.
        public int MedicionID { get; set; }

        // 2. CORREGIDO: Mayúscula inicial para coincidir con SQL y el resto del código
        public int PlantaID { get; set; }

        public DateTime FechaRegistro { get; set; }

        // Valores
        // Nota: En SQL pusiste Decimal(5,2). Float en C# funciona, 
        // pero ten en cuenta que puede haber una micro diferencia de precisión. 
        // Para sensores está perfecto usar float.
        public float Temperatura { get; set; }
        public float Humedad { get; set; }
        public int Luminosidad { get; set; }

        // Alertas
        public bool AlertaTemperatura { get; set; }
        public bool AlertaHumedad { get; set; }
        public bool AlertaLuz { get; set; }

        public Medicion()
        {
            FechaRegistro = DateTime.Now;
        }
    }
}