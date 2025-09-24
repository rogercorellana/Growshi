using System;
using Interfaces.IBE;

namespace Interfaces.IServices
{
    /// <summary>
    /// Define un contrato para un servicio con lógica de negocio pura y reutilizable relacionada con backups.
    /// Este servicio no realiza operaciones de I/O (base de datos, archivos), solo procesa datos.
    /// </summary>
    public interface IBackupService
    {
        /// <summary>
        /// Genera un nombre de archivo estandarizado y único para una nueva copia de seguridad.
        /// </summary>
        /// <returns>Un string con el nombre del archivo, ej: "backup_20250923_153000.bak".</returns>
        string GenerarNombreDeArchivo();

        /// <summary>
        /// Valida si una entidad de backup cumple con las reglas de negocio para ser creada.
        /// </summary>
        /// <param name="backup">La entidad a validar.</param>
        /// <returns>True si es válida, de lo contrario lanza una excepción.</returns>
        bool Validar(IBackup backup);
    }
}