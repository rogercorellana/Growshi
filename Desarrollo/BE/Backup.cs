using System;

namespace BE
{
    public class Backup
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public string Nota { get; set; } // <-- NUEVA PROPIEDAD
        public Usuario Usuario { get; set; }
    }
}