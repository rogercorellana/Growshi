namespace BE
{
    public class EtapaCultivo
    {
        public int EtapaCultivoID { get; set; }
        public int PlanCultivoID { get; set; }
        public string NombreEtapa { get; set; }
        public int Orden { get; set; }

        // 
        public int Duracion { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
        public decimal HumMin { get; set; }
        public decimal HumMax { get; set; }
        public decimal PhMin { get; set; }
        public decimal PhMax { get; set; }
        public decimal EcMin { get; set; }
        public decimal EcMax { get; set; }
    }
}