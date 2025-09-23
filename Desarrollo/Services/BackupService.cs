using Interfaces.IServices;
using System;
using System.IO;

namespace Services
{
    /// <summary>
    /// Implementa la lógica de negocio pura para la preparación de backups.
    /// No accede a datos y su única dependencia es con el proyecto 'Interfaces'.
    /// </summary>
    public class BackupService : IBackupService
    {
        private readonly string _databaseName = "Growshi";

        public string PrepararNuevoBackup(string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino) || !Directory.Exists(rutaDestino))
            {
                throw new DirectoryNotFoundException("La carpeta de destino para el backup no es válida o no existe.");
            }

            // Lógica de negocio pura: crear un nombre de archivo estandarizado.
            string nombreArchivo = $"{_databaseName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string rutaCompleta = Path.Combine(rutaDestino, nombreArchivo);

            return rutaCompleta;
        }
    }
}