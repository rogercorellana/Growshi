using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration; // <--- NO OLVIDES AGREGAR ESTA REFERENCIA
using System.Windows.Forms; // Para el Path del ejecutable si fuera necesario

namespace DAL.DAO
{
    internal class SqlHelper
    {
        #region Singleton
        private static SqlHelper _instance;
        private string ConnString;

        // Constructor privado: Lee del App.Config
        private SqlHelper()
        {
            try
            {
                // Intenta leer la cadena llamada "MainCon"
                var connectionStringSettings = ConfigurationManager.ConnectionStrings["MainCon"];
                if (connectionStringSettings != null)
                {
                    this.ConnString = connectionStringSettings.ConnectionString;
                }
                else
                {
                    // Fallback por si no existe la key aún (evita crash inicial si está vacío)
                    this.ConnString = "";
                }
            }
            catch
            {
                this.ConnString = "";
            }
        }

        // Constructor manual (por si acaso)
        private SqlHelper(string connStr)
        {
            this.ConnString = connStr;
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

        #region Configuración Dinámica (NUEVO)

        // Método para validar conexión rápida (lo usas en el Login)
        public bool CheckConnection()
        {
            try
            {
                using (var conn = new SqlConnection(this.ConnString))
                {
                    conn.Open(); // Intenta abrir
                    return true; // Si llega aquí, todo ok
                }
            }
            catch
            {
                return false;
            }
        }

        public static void GuardarCadenaConexion(string servidor, string baseDatos)
        {
            // 1. Construir nueva cadena
            string nuevaCadena = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True";

            // 2. Abrir configuración
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 3. Borrar vieja y poner nueva
            config.ConnectionStrings.ConnectionStrings.Remove("MainCon");
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("MainCon", nuevaCadena, "System.Data.SqlClient"));

            // 4. Guardar
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

            // 5. IMPORTANTE: Resetear el Singleton para que recargue la nueva cadena
            _instance = null;
        }

        #endregion

        #region Variables y CRUD (Igual que antes)
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        DataTable table;

        public DataTable ExecuteReader(string query, List<SqlParameter> parametros)
        {
            table = new DataTable();
            using (connection = new SqlConnection(this.ConnString))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    if (parametros != null) command.Parameters.AddRange(parametros.ToArray());
                    using (reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            return table;
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            int rowsAffected = 0;
            using (connection = new SqlConnection(this.ConnString))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    if (parameters != null) command.Parameters.AddRange(parameters.ToArray());
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        #endregion
    }
}