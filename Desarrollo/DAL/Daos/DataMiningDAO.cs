using BE.DataMining; // Asegurate de tener los DTOs que creamos antes
using DAL.DAO;       // Para usar tu SqlHelper
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Daos
{
    public class DataMiningDAO
    {
        private readonly SqlHelper _sqlHelper;

        public DataMiningDAO()
        {
            // Reutilizamos la instancia única de conexión
            _sqlHelper = SqlHelper.GetInstance();
        }

        public List<MedicionDW> ObtenerHistorialReciente(int diasAtras)
        {
            var lista = new List<MedicionDW>();

            // TRUCO: Usamos [Growshi_DW].[dbo]... para consultar el Warehouse 
            // usando la conexión de la App principal.
            string query = @"
                SELECT 
                    T.Fecha, 
                    H.Hora, 
                    H.Minuto,
                    M.Temperatura, 
                    M.Humedad, 
                    M.Luminosidad
                FROM [Growshi_DW].[dbo].[Hecho_Medicion] M
                INNER JOIN [Growshi_DW].[dbo].[Dim_Tiempo] T ON M.FechaKey = T.FechaKey
                INNER JOIN [Growshi_DW].[dbo].[Dim_Hora] H ON M.HoraKey = H.HoraKey
                WHERE T.Fecha >= DATEADD(day, -@Dias, GETDATE())
                ORDER BY T.Fecha ASC, H.HoraKey ASC";

            try
            {
                // 1. Preparamos parámetros
                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Dias", diasAtras)
                };

                // 2. Ejecutamos usando tu SqlHelper
                DataTable tabla = _sqlHelper.ExecuteReader(query, parametros);

                // 3. Mapeo Manual (DataTable -> List<Object>)
                // Esto convierte las filas crudas en objetos para la BLL
                foreach (DataRow row in tabla.Rows)
                {
                    // Reconstruimos la fecha completa (Fecha + Hora + Minuto)
                    DateTime fechaBase = Convert.ToDateTime(row["Fecha"]);
                    int hora = Convert.ToInt32(row["Hora"]);
                    int minuto = Convert.ToInt32(row["Minuto"]);

                    DateTime fechaCompleta = new DateTime(
                        fechaBase.Year,
                        fechaBase.Month,
                        fechaBase.Day,
                        hora,
                        minuto,
                        0);

                    lista.Add(new MedicionDW
                    {
                        FechaHora = fechaCompleta,
                        Hora = hora, // Guardamos la hora sola para agrupar patrones
                        Temperatura = row["Temperatura"] != DBNull.Value ? Convert.ToDouble(row["Temperatura"]) : 0,
                        Humedad = row["Humedad"] != DBNull.Value ? Convert.ToDouble(row["Humedad"]) : 0,
                        Luminosidad = row["Luminosidad"] != DBNull.Value ? Convert.ToInt32(row["Luminosidad"]) : 0
                    });
                }
            }
            catch (Exception ex)
            {
                // En producción podrías loguear el error en la Bitácora
                // throw new Exception("Error al consultar Data Warehouse: " + ex.Message);

                // Por ahora retornamos lista vacía para que el Dashboard no explote si falla la conexión
                return new List<MedicionDW>();
            }

            return lista;
        }
    }
}