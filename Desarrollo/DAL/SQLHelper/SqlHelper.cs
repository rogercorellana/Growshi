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
            //PARA PC
            this.ConnString = "Data Source=./;Initial Catalog=Growshi;Integrated Security=True";

            //PARA MI LAPTOP
            //this.ConnString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Growshi;Integrated Security=True";
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
                    using (var reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            return table;
        }
        #endregion

        #region CUD(CREATE,UPDATE,DELETE) ExecuteNonQuery - Escribir datos (INSERT, UPDATE, DELETE) - Devuelve: int(filas afectadas)

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            int rowsAffected = 0;
            using (var connection = new SqlConnection(this.ConnString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        #endregion 


    }
}
