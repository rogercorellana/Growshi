using BE;
using DAL.Daos;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace BLL
{
    public class BackupBLL
    {
        private readonly BackupService _backupService;
        private readonly DatabaseAdminDAO _databaseAdminDAO;
        private readonly BackupDAO _backupDAO;

        // YA NO HAY RUTAS HARDCODEADAS AQUÍ
        // La ruta se obtiene dinámicamente en tiempo de ejecución.

        public BackupBLL()
        {
            _backupService = new BackupService();
            _databaseAdminDAO = new DatabaseAdminDAO();
            _backupDAO = new BackupDAO();
        }

        #region "C" Crear COPIA DE SEGURIDAD
        public void CrearCopiaDeSeguridad(string nota, IUsuarioLogueado usuario)
        {
            // 1. Obtener la ruta dinámica desde SQL Server
            string directorioBase = _databaseAdminDAO.ObtenerRutaBackupPorDefecto();

            // Asegurarnos que el directorio existe (por si acaso el fallback es una ruta local)
            if (!Directory.Exists(directorioBase))
            {
                // Si es una ruta de red o del sistema, CreateDirectory podría fallar por permisos,
                // pero si es la ruta por defecto de SQL, ya debería existir.
                try { Directory.CreateDirectory(directorioBase); } catch { /* Ignorar si no tenemos permiso, confiamos en SQL */ }
            }

            // 2. Preparar el objeto
            Backup nuevoBackup = new Backup
            {
                FechaHora = DateTime.Now,
                Nota = nota,
                Usuario = usuario,
                RutaArchivo = directorioBase // Guardamos DÓNDE se hizo
            };

            _backupService.Validar(nuevoBackup);

            // 3. Generar nombre y ruta completa
            nuevoBackup.NombreArchivo = _backupService.GenerarNombreDeArchivo(); // Ej: "Growshi_20251025.bak"

            // Path.Combine es más seguro que concatenar strings con "+"
            string rutaCompleta = Path.Combine(directorioBase, nuevoBackup.NombreArchivo);

            // 4. Realizar el Backup Físico (Si falla aquí, explota y no guarda en BD)
            try
            {
                _databaseAdminDAO.RealizarBackup(rutaCompleta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error crítico del motor SQL al generar el archivo en '{directorioBase}': {ex.Message}", ex);
            }

            // 5. Guardar registro en la Base de Datos (Solo si el físico funcionó)
            _backupDAO.Crear(nuevoBackup);

            // BITACORA - (Aquí iría tu llamada al servicio de bitácora)
        }
        #endregion

        #region "R" Leer Historial
        public List<IBackup> ObtenerHistorial()
        {
            return new List<IBackup>(_backupDAO.ObtenerTodos());
        }
        #endregion

        #region "D" Eliminar COPIA DE SEGURIDAD
        public void EliminarCopiaDeSeguridad(IBackup backup)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup), "No se ha seleccionado ningún backup para eliminar.");

            // 1. Eliminar registro de la base de datos primero (Integridad referencial)
            _backupDAO.Eliminar(backup.Id);

            // 2. Intentar eliminar el archivo físico
            try
            {
                string rutaCompleta = Path.Combine(backup.RutaArchivo, backup.NombreArchivo);

                if (File.Exists(rutaCompleta))
                {
                    File.Delete(rutaCompleta);
                }
            }
            catch (Exception)
            {
                // Si no se puede borrar el archivo físico (permisos, bloqueado, o ya no existe),
                // no detenemos el proceso porque ya lo borramos de la base de datos (lógico).
                // Podrías loguear este error silencioso en la bitácora técnica.
            }

            // BITACORA - (Aquí iría tu llamada al servicio de bitácora)
        }
        #endregion

        #region Restaurar COPIA DE SEGURIDAD
        public void RestaurarCopiaDeSeguridad(IBackup backup)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup), "No se ha seleccionado ningún backup para restaurar.");

            // Armar ruta segura
            string rutaCompleta = Path.Combine(backup.RutaArchivo, backup.NombreArchivo);

            // Verificación básica de existencia (Solo funciona si App y DB están en el mismo servidor/PC)
            if (!File.Exists(rutaCompleta))
            {
                // Opcional: Marcar en BD que el archivo se perdió, o borrarlo de la lista.
                // _backupDAO.Eliminar(backup.Id); 
                throw new FileNotFoundException($"El archivo físico no se encuentra en: {rutaCompleta}. Es posible que haya sido movido o eliminado manualmente.");
            }

            // Ejecutar Restore
            try
            {
                _databaseAdminDAO.RealizarRestore(rutaCompleta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error crítico al restaurar la base de datos: {ex.Message}", ex);
            }

            // BITACORA - (Aquí iría tu llamada al servicio de bitácora)
        }
        #endregion
    }
}