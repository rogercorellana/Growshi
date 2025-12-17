using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL.Daos
{
    public class DatabaseAdminDAO
    {
        private readonly SqlHelper _sqlHelper;
        private readonly string _databaseName = "Growshi";

        public DatabaseAdminDAO()
        {
            _sqlHelper = SqlHelper.GetInstance();
        }

        /// <summary>
        /// Obtiene la ruta configurada en el servidor SQL para guardar backups.
        /// Soluciona el problema de hardcodear "C:\Program Files...".
        /// </summary>
        public string ObtenerRutaBackupPorDefecto()
        {
            // Consulta para obtener la ruta por defecto o la ruta de datos si la primera es nula
            string query = @"
                SELECT ISNULL(
                    CAST(SERVERPROPERTY('InstanceDefaultBackupPath') AS VARCHAR(MAX)), 
                    CAST(SERVERPROPERTY('InstanceDefaultDataPath') AS VARCHAR(MAX))
                ) AS Ruta";

            // Usamos ExecuteReader porque tu Helper devuelve un DataTable
            DataTable dt = _sqlHelper.ExecuteReader(query, null);

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                string ruta = dt.Rows[0][0].ToString();
                // Aseguramos que termine en backslash
                if (!ruta.EndsWith("\\")) ruta += "\\";
                return ruta;
            }

            // Fallback de emergencia: Carpeta temporal de Windows
            return Path.GetTempPath();
        }

        public void RealizarBackup(string rutaCompletaDestino)
        {
            // Usamos parámetros para evitar errores con espacios en la ruta
            string query = $@"
                BACKUP DATABASE [{_databaseName}] 
                TO DISK = @Ruta 
                WITH FORMAT, INIT, NAME = 'Growshi-Full Database Backup'";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Ruta", rutaCompletaDestino)
            };

            _sqlHelper.ExecuteNonQuery(query, parametros);
        }

        public void RealizarRestore(string rutaCompletaOrigen)
        {
            // El script para restaurar:
            // 1. Cambia a master para no bloquear la DB.
            // 2. Echa a todos los usuarios (SINGLE_USER).
            // 3. Restaura.
            // 4. Vuelve a MULTI_USER.
            string query = $@"
                USE master;
                
                ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                
                RESTORE DATABASE [{_databaseName}] 
                FROM DISK = @Ruta 
                WITH REPLACE;
                
                ALTER DATABASE [{_databaseName}] SET MULTI_USER;";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Ruta", rutaCompletaOrigen)
            };

            _sqlHelper.ExecuteNonQuery(query, parametros);
        }
    }
}