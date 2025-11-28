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

        //ruta pc
        //private readonly string _rutaDeBackups = @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\";
        //ruta laptop
        private readonly string _rutaDeBackups = @"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\";


        public BackupBLL()
        {
            _backupService = new BackupService();
            _databaseAdminDAO = new DatabaseAdminDAO();
            _backupDAO = new BackupDAO();
        }

        #region "C" Crear COPIA DE SEGURIDAD
        public void CrearCopiaDeSeguridad(string nota, IUsuarioLogueado usuario)
        {


            Backup nuevoBackup = new Backup
            {
                //Id se crea automaticamente en la DB
                //NombreArchivo mas abajo

                FechaHora = DateTime.Now,
                RutaArchivo = _rutaDeBackups,
                Nota = nota,
                Usuario = usuario,
            };


            _backupService.Validar(nuevoBackup);

            nuevoBackup.NombreArchivo = _backupService.GenerarNombreDeArchivo();
            string rutaCompleta = _rutaDeBackups + nuevoBackup.NombreArchivo;

            _databaseAdminDAO.RealizarBackup(rutaCompleta);


            _backupDAO.Crear(nuevoBackup);





            //BITACORA - espacio para guardar evento 

        }

        #endregion

        #region "R" Leer Existencias en la base de datos 
        public List<IBackup> ObtenerHistorial()
        {
            return new List<IBackup>(_backupDAO.ObtenerTodos());



            //BITACORA - espacio para guardar evento 
        }
        #endregion

        #region "D" Borrar COPIA DE SEGURIDAD

        public void EliminarCopiaDeSeguridad(IBackup backup)
        {
            if (backup == null) throw new ArgumentNullException("No se ha seleccionado ningún backup para eliminar.");

            string rutaCompleta = backup.RutaArchivo + backup.NombreArchivo;

            _backupDAO.Eliminar(backup.Id);

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }

            //BITACORA - espacio para guardar evento 


        }
        #endregion


        #region Restaurar COPIA DE SEGURIDAD
        public void RestaurarCopiaDeSeguridad(IBackup backup)
        {
            if (backup == null) throw new ArgumentNullException("No se ha seleccionado ningún backup para restaurar.");

            string rutaCompleta = backup.RutaArchivo + backup.NombreArchivo;

            if (!File.Exists(rutaCompleta))
            {
                _backupDAO.Eliminar(backup.Id);

                throw new FileNotFoundException("El archivo de backup no se encontró en la ruta especificada.", rutaCompleta);



            }

            _databaseAdminDAO.RealizarRestore(rutaCompleta);
        }

        #endregion
    }
}