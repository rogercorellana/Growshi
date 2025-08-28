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
        //R(READ) ExecuteReader

        // Ado Conectado - Con Query
      
        //traigo una fila de la DB, y se la asigno a un Datatable usando una consulta query

        //lo uso de la forma donde lee en la DB y carga a un Datatable todo. 
        //DataTable usuarios = miSqlHelper.ExecuteReader("SELECT * FROM Usuarios");

        
        public DataTable ExecuteReader(string query)
        {

            table = new DataTable();

            try
            {
                using (connection = new SqlConnection(this.ConnString))
                {
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    connection.Open();

                    reader = command.ExecuteReader();
                    table.Load(reader);

                    connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return table;
        }



        public DataTable ExecuteTable(string StoreProcedureName, List<SqlParameter> parameters)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dt = new DataSet();

            try
            {
                using (connection = new SqlConnection(this.ConnString))
                {
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = StoreProcedureName;

                    adapter.SelectCommand = command;

                    adapter.Fill(dt);

                    return dt.Tables[0];

                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public bool ExecuteNonQuery(string StoreProcedure, List<SqlParameter> parameters)
        {
            bool returnValue = false;


            using (connection = new SqlConnection(this.ConnString))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = StoreProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                connection.Open();

                if (command.ExecuteNonQuery() > 0)
                {
                    returnValue = true;
                }

            }

            return returnValue;


        }

        // ADO Conectado - Con Store Procedure
        public DataTable ExecuteReader(string StoreProcedureName, List<SqlParameter> parameters)
        {
            table = new DataTable();

            try
            {
                using (connection = new SqlConnection(this.ConnString))
                {
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = StoreProcedureName;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    connection.Open();

                    reader = command.ExecuteReader();
                    table.Load(reader);

                    connection.Close();

                    return table;

                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
