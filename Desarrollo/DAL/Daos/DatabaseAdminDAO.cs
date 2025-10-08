using DAL.DAO;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public void RealizarBackup(string rutaCompletaDestino)
        {
            string comandoSql = $"BACKUP DATABASE [{_databaseName}] TO DISK = N'{rutaCompletaDestino}'";
            _sqlHelper.ExecuteNonQuery(comandoSql, null);
        }

        

        public void RealizarRestore(string rutaCompletaOrigen)
        {

           string query = $@"
                USE master;

                -- Forzar modo single_user y cerrar conexiones activas
                ALTER DATABASE Growshi SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

                -- Restaurar base desde el archivo .bak
                RESTORE DATABASE Growshi 
                FROM DISK = @ruta
                WITH REPLACE;

                -- Volver a multi_user
                ALTER DATABASE Growshi SET MULTI_USER;
            ";


            var parametros = new List<SqlParameter> {
            new SqlParameter("@ruta", rutaCompletaOrigen)
            };

            _sqlHelper.ExecuteNonQuery(query, parametros);
        }




    }
}