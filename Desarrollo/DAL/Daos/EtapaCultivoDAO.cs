using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;
using DAL.DAO;
using DAL.Mappers;

namespace DAL
{
    public class EtapaCultivoDAO
    {
        // Instancia Singleton de tu Helper
        private SqlHelper sqlHelper = SqlHelper.GetInstance();

        public List<EtapaCultivo> ListarPorPlan(int idPlan)
        {
            List<EtapaCultivo> lista = new List<EtapaCultivo>();

            // Consulta SQL
            string query = "SELECT * FROM EtapaCultivo WHERE PlanCultivoID = @idPlan ORDER BY Orden ASC";

            // Parámetros
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idPlan", idPlan));

            try
            {
                // Ejecutar consulta
                DataTable tabla = sqlHelper.ExecuteReader(query, parametros);

                // Recorrer y Mapear
                foreach (DataRow row in tabla.Rows)
                {
                    lista.Add(EtapaCultivoMapper.Map(row));
                }
            }
            catch (Exception)
            {
                // Manejo de errores o re-throw (lanzar hacia arriba)
                throw;
            }

            return lista;
        }
    }
}