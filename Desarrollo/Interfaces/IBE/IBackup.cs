using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IBE
{
    public interface IBackup
    {

        int Id { get; set; }
        DateTime FechaHora { get; set; }
        string NombreArchivo { get; set; }
        string RutaArchivo { get; set; }
        string Nota { get; set; }
        IUsuarioLogueado Usuario { get; set; }
    }
}
