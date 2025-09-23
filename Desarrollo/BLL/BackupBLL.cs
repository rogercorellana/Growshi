using BE;
using DAL;
using DAL.Daos;
using Interfaces.IServices;
using Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace BLL
{
    /// <summary>
    /// Orquesta todas las operaciones de la gestión de Backups.
    /// Es la única capa que conoce al Servicio y a los DAOs, y dirige el flujo entre ellos.
    /// </summary>
    public class BackupBLL
    {
        private readonly IBackupService _backupService;
        private readonly BackupDAO _backupDAO;
        private readonly DatabaseAdminDAO _dbAdminDAO;
        private readonly UsuarioDAO _usuarioDAO;

        public BackupBLL()
        {
            // La BLL es responsable de instanciar sus dependencias.
            _backupService = new BackupService();
            _backupDAO = new BackupDAO();
            _dbAdminDAO = new DatabaseAdminDAO();
            _usuarioDAO = new UsuarioDAO();
        }

        /// <summary>
        /// Orquesta el proceso completo para crear una copia de seguridad y registrarla.
        /// </summary>
        public void RealizarBackup(string rutaDestino, Usuario usuarioLogueado)
        {
            // 1. Llama al servicio para aplicar su lógica y preparar la ruta.
            string rutaCompleta = _backupService.PrepararNuevoBackup(rutaDestino);

            // 2. Llama al DAO administrativo para crear el archivo .bak físico.
            _dbAdminDAO.EjecutarBackup(rutaCompleta);

            // 3. La BLL ensambla el objeto de negocio con toda la información.
            var nuevoRegistro = new Backup
            {
                FechaHora = DateTime.Now,
                NombreArchivo = Path.GetFileName(rutaCompleta),
                RutaArchivo = rutaCompleta,
                Usuario = usuarioLogueado
            };

            // 4. Llama al DAO de negocio para guardar el registro en el catálogo.
            _backupDAO.CrearRegistro(nuevoRegistro);
        }

        /// <summary>
        /// Orquesta el proceso de restauración y las acciones de negocio posteriores.
        /// </summary>
        public void RestaurarBackup(Backup backupARestaurar)
        {
            if (backupARestaurar == null)
                throw new ArgumentNullException(nameof(backupARestaurar), "Se debe seleccionar un backup para restaurar.");

            // 1. Llama a la DAL para ejecutar la operación de restauración.
            _dbAdminDAO.EjecutarRestore(backupARestaurar.RutaArchivo);

            // 2. Lógica de negocio crítica: La sesión actual ya no es válida y debe cerrarse


            ISessionService<Usuario> _sessionService = SessionService<Usuario>.GetInstance(); 
            _sessionService.Logout();
            // Asumiendo que SessionService es accesible aquí.
        }

        /// <summary>
        /// Obtiene el catálogo de backups y enriquece los datos para la UI.
        /// </summary>
        public List<Backup> ObtenerCatalogoCompleto()
        {
            // 1. Obtiene la lista básica desde la DAL.
            var catalogo = _backupDAO.ObtenerCatalogo();

            // 2. Lógica de negocio: enriquecer cada registro con los datos completos del usuario.
            foreach (var backup in catalogo)
            {
                // Asumiendo que UsuarioDAO tiene un método GetById.
                backup.Usuario = _usuarioDAO.ObtenerPorId(backup.Usuario.Id);
            }
            return catalogo;
        }
    }
}