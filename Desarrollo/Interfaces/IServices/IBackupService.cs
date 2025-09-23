using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IServices
{
    public interface IBackupService
    {
        /// <summary>
        /// Prepara la información para una nueva copia de seguridad, generando la ruta completa del archivo.
        /// </summary>
        /// <param name="rutaDestino">La carpeta donde se guardará el archivo.</param>
        /// <returns>La ruta completa y el nombre del archivo .bak a generar.</returns>
        string PrepararNuevoBackup(string rutaDestino);
    }
}
