using DAL.DAO;
using System.Data.SqlClient; // Asegúrate de tener este 'using'

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

        // ... tu método RealizarBackup() no cambia ...
        public void RealizarBackup(string rutaCompletaDestino)
        {
            string comandoSql = $"BACKUP DATABASE [{_databaseName}] TO DISK = N'{rutaCompletaDestino}'";
            _sqlHelper.ExecuteNonQuery(comandoSql, null);
        }

        // --- MÉTODO CORREGIDO ---
        public void RealizarRestore(string rutaCompletaOrigen)
        {
            string sqlSetSingleUser = $"ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            string sqlRestore = $"RESTORE DATABASE [{_databaseName}] FROM DISK = N'{rutaCompletaOrigen}' WITH REPLACE";
            string sqlSetMultiUser = $"ALTER DATABASE [{_databaseName}] SET MULTI_USER";

            _sqlHelper.ExecuteNonQuery(sqlSetSingleUser, null);
            _sqlHelper.ExecuteNonQuery(sqlRestore, null);
            _sqlHelper.ExecuteNonQuery(sqlSetMultiUser, null);
        }
    }
}