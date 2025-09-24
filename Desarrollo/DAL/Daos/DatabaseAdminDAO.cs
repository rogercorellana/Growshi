using DAL.DAO;
using System.Data.SqlClient;

namespace DAL.Daos
{
    /// <summary>
    /// Ejecuta comandos de administración sobre la base de datos, como Backups y Restores.
    /// </summary>
    public class DatabaseAdminDAO
    {
        private readonly SqlHelper _sqlHelper;
        private readonly string _databaseName = "Growshi"; // El nombre de tu base de datos

        public DatabaseAdminDAO()
        {
            _sqlHelper = SqlHelper.GetInstance();
        }

        public void RealizarBackup(string rutaCompletaDestino)
        {
            // Este comando no usa parámetros SQL estándar, la ruta se concatena directamente.
            // La seguridad se garantiza porque la BLL construye esta ruta, no el usuario final.
            string comandoSql = $"BACKUP DATABASE [{_databaseName}] TO DISK = N'{rutaCompletaDestino}'";
            _sqlHelper.ExecuteNonQuery(comandoSql, null);
        }

        public void RealizarRestore(string rutaCompletaOrigen)
        {
            // Para restaurar, es crucial poner la BD en modo de usuario único primero
            // y luego devolverla a modo multi-usuario.
            string sqlSetSingleUser = $"ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            string sqlRestore = $"RESTORE DATABASE [{_databaseName}] FROM DISK = N'{rutaCompletaOrigen}' WITH REPLACE";
            string sqlSetMultiUser = $"ALTER DATABASE [{_databaseName}] SET MULTI_USER";

            _sqlHelper.ExecuteNonQuery(sqlSetSingleUser, null);
            _sqlHelper.ExecuteNonQuery(sqlRestore, null);
            _sqlHelper.ExecuteNonQuery(sqlSetMultiUser, null);
        }
    }
}