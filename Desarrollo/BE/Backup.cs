using Interfaces.IBE;
using System;

namespace BE
{
    public class Backup : IBackup
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public string Nota { get; set; } 
        public IUsuarioLogueado Usuario { get; set; }
    }
}