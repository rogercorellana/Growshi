using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    internal class SqlHelper
    {

        #region Singleton
        private SqlHelper(string connStr)
        {
            this.ConnString = connStr;

        }

        private SqlHelper()
        {
            this.ConnString = "Data Source=./;Initial Catalog=Growshi;Integrated Security=True";

        }

        private static SqlHelper _instance;
        private string ConnString;

        public static SqlHelper GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new SqlHelper(connectionString);
            }
            return _instance;
        }

        public static SqlHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SqlHelper();
            }
            return _instance;
        }

        #endregion


        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        DataTable table;

        //CRUD

        #region R(READ) ExecuteReader - Lee filas y columnas  - Devuelve: DataTable o SqlDataReader

       
        //string consulta = "SELECT * FROM Usuario WHERE NombreUsuario = @nombre";

        public DataTable ExecuteReader(string query, List<SqlParameter> parametros)
        {
            var table = new DataTable();
            using (var connection = new SqlConnection(this.ConnString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    // Línea clave: los parámetros se añaden de forma segura
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros.ToArray());
                    }
                    var reader = command.ExecuteReader();
                    table.Load(reader);
                }
            }
            return table;
        }
        #endregion



        #region CUD(CREATE,UPDATE,DELETE) ExecuteNonQuery - Escribir datos (INSERT, UPDATE, DELETE) - Devuelve: int(filas afectadas)

        //EJEMPLO DE USO
        //int resultado = miSqlHelper.ExecuteNonQuery("DELETE FROM Usuarios WHERE Activo = 0");

        public int ExecuteNonQuery(string query)
        {
            int filasAfectadas = 0;
            using (connection = new SqlConnection(this.ConnString))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    filasAfectadas = command.ExecuteNonQuery();
                }
            }
            return filasAfectadas;
        }

        #endregion 


    }
}
