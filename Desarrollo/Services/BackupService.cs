using System;
using Interfaces.IBE;
using Interfaces.IServices;

namespace Services
{
    /// <summary>
    /// Implementa las herramientas de lógica de negocio para backups.
    /// Esta clase solo conoce interfaces y no tiene dependencias con DAL o BLL.
    /// </summary>
    public class BackupService : IBackupService
    {
        public string GenerarNombreDeArchivo()
        {
            // Lógica pura: crear un nombre basado en la fecha y hora.
            return $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        }

        public bool Validar(IBackup backup)
        {
            // Lógica pura: aplicar reglas de negocio.
            if (backup.Usuario == null)
            {
                throw new ArgumentException("El backup debe tener un usuario asociado.");
            }

            if (backup.Nota != null && backup.Nota.Length > 500)
            {
                throw new ArgumentException("La nota no puede exceder los 500 caracteres.");
            }

            return true;
        }
    }
}