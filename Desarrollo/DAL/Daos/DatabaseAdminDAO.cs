using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Daos
{
    /// <summary>
    /// DAO especializado para ejecutar comandos administrativos (BACKUP, RESTORE)
    /// que requieren un manejo especial de la conexión a la base de datos.
    /// </summary>
    public class DatabaseAdminDAO
    {
        private readonly string _databaseName = "Growshi";

        public void EjecutarBackup(string rutaCompleta)
        {
            // Para la operación BACKUP, se utiliza el SqlHelper estándar del proyecto.
            string comandoSql = $"BACKUP DATABASE [{_databaseName}] TO DISK = N'{rutaCompleta}' WITH NOFORMAT, NOINIT, NAME = N'{_databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
            SqlHelper.GetInstance().ExecuteNonQuery(comandoSql, null); // Se pasa null para los parámetros
        }

        public void EjecutarRestore(string rutaCompleta)
        {
            if (!File.Exists(rutaCompleta))
            {
                throw new FileNotFoundException("El archivo de backup no se encontró en la ruta especificada.", rutaCompleta);
            }


            // CASO ESPECIAL: Para RESTORE, es obligatorio conectarse a 'master'.
            // No podemos usar SqlHelper.GetInstance(), por lo que creamos una conexión temporal.
            string baseConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(baseConnectionString)
            {
                InitialCatalog = "master"
            };

            string comandoSetSingleUser = $"ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            string comandoRestore = $"RESTORE DATABASE [{_databaseName}] FROM DISK = N'{rutaCompleta}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5";
            string comandoSetMultiUser = $"ALTER DATABASE [{_databaseName}] SET MULTI_USER";

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                new SqlCommand(comandoSetSingleUser, connection).ExecuteNonQuery();
                new SqlCommand(comandoRestore, connection).ExecuteNonQuery();
                new SqlCommand(comandoSetMultiUser, connection).ExecuteNonQuery();
            }
        }
    }
}