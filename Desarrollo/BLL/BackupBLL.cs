using BE;
using DAL.Daos;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using System;
using System.Collections.Generic;
using System.IO; // Necesario para la lógica de eliminación de archivos

namespace BLL
{
    /// <summary>
    /// Orquesta todas las operaciones relacionadas con la gestión de copias de seguridad.
    /// Es el único que conoce e instancia las capas de Servicios y DAL.
    /// </summary>
    public class BackupBLL
    {
        // --- Sus Herramientas (los Servicios) ---
        private readonly IBackupService _backupService;

        // --- Sus Conexiones (a la DAL) ---
        private readonly DatabaseAdminDAO _databaseAdminDAO;
        private readonly BackupDAO _backupDAO;

        // --- Configuración ---
        private readonly string _rutaDeBackups = @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\";

        /// <summary>
        /// En el constructor, la BLL prepara todas las herramientas y conexiones que necesitará.
        /// </summary>
        public BackupBLL()
        {
            _backupService = new BackupService();
            _databaseAdminDAO = new DatabaseAdminDAO();
            _backupDAO = new BackupDAO();
        }

        /// <summary>
        /// Orquesta el caso de uso completo para "Crear una nueva copia de seguridad".
        /// </summary>
        /// <param name="nota">La nota opcional escrita por el usuario.</param>
        /// <param name="usuario">El usuario logueado que realiza la acción.</param>
        public void CrearCopiaDeSeguridad(string nota, IUsuarioLogueado usuario)
        {
            // 1. La BLL crea la entidad de negocio inicial.
            var nuevoBackup = new Backup
            {
                Nota = nota,
                FechaHora = DateTime.Now,

                Usuario = usuario,
                RutaArchivo = _rutaDeBackups
            };
            //esto hay en la clase de la BE Backup
            //public int Id { get; set; }
            //public DateTime FechaHora { get; set; }
            //public string NombreArchivo { get; set; }
            //public string RutaArchivo { get; set; }
            //public string Nota { get; set; }
            //public IUsuarioLogueado Usuario { get; set; }


            // 2. La BLL usa la HERRAMIENTA del servicio para validar la entidad.
            _backupService.Validar(nuevoBackup);

            // 3. La BLL usa OTRA HERRAMIENTA del servicio para obtener el nombre del archivo.
            nuevoBackup.NombreArchivo = _backupService.GenerarNombreDeArchivo();
            string rutaCompleta = _rutaDeBackups + nuevoBackup.NombreArchivo;

            // 4. La BLL da la ORDEN a la DAL para que cree el archivo físico.
            _databaseAdminDAO.RealizarBackup(rutaCompleta);

            // 5. La BLL da la ORDEN a la DAL para que guarde el registro en la tabla 'Backup'.
            _backupDAO.Guardar(nuevoBackup);
        }

        /// <summary>
        /// Obtiene el historial completo de backups.
        /// </summary>
        public List<IBackup> ObtenerHistorial()
        {
            // Simplemente le pide a la DAL los datos y los devuelve.
            return new List<IBackup>(_backupDAO.ListarTodos());
        }

        /// <summary>
        /// Orquesta la eliminación de una copia de seguridad.
        /// </summary>
        public void EliminarCopiaDeSeguridad(IBackup backup)
        {
            if (backup == null) throw new ArgumentNullException("No se ha seleccionado ningún backup para eliminar.");

            string rutaCompleta = backup.RutaArchivo + backup.NombreArchivo;

            // 1. La BLL da la ORDEN a la DAL para eliminar el registro de la base de datos.
            _backupDAO.Eliminar(backup.Id);

            // 2. La BLL se encarga de la lógica del sistema de archivos.
            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
        }

        /// <summary>
        /// Orquesta la restauración de una base de datos.
        /// </summary>
        public void RestaurarCopiaDeSeguridad(IBackup backup)
        {
            if (backup == null) throw new ArgumentNullException("No se ha seleccionado ningún backup para restaurar.");

            string rutaCompleta = backup.RutaArchivo + backup.NombreArchivo;

            if (!File.Exists(rutaCompleta))
            {
                throw new FileNotFoundException("El archivo de backup no se encontró en la ruta especificada.", rutaCompleta);
            }

            // La BLL le da la ORDEN a la DAL para que realice la restauración.
            _databaseAdminDAO.RealizarRestore(rutaCompleta);
        }
    }
}