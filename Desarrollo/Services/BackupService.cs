using System;
using Interfaces.IBE;
using Interfaces.IServices;

namespace Services
{
 
    public class BackupService : IBackupService
    {

        /// <summary>
        /// Genera el nombre del archivo .bak
        /// </summary>
        public string GenerarNombreDeArchivo()
        {
            return $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        }


        /// <summary>
        /// Valida que exista un usuario asociado y que el textbox de nota no exceda los 100 caracteres
        /// </summary>
        public bool Validar(IBackup backup)
        {
            if (backup.Usuario == null)
            {
                throw new ArgumentException("El backup debe tener un usuario asociado.");
            }

            if (backup.Nota != null && backup.Nota.Length > 100)
            {
                throw new ArgumentException("La nota no puede exceder los 100 caracteres.");
            }

            return true;
        }
    }
}