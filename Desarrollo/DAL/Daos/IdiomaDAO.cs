using DAL;
using DAL.DAO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Daos
{
    public class IdiomaDAO
    {
        
        public DataTable ObtenerTraducciones(int idiomaId)
        {
            string query = @"SELECT Clave, Valor 
                           FROM Traduccion 
                           WHERE IdiomaID = @idiomaId";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@idiomaId", idiomaId)
            };

            return SqlHelper.GetInstance().ExecuteReader(query, parameters);
        }
    }
}