using BE;
using DAL.DAO; // Para acceder a tu SqlHelper
using System;
using System.Collections.Generic;
using System.Data; // Necesario para DataTable y DataRow
using System.Data.SqlClient;

namespace DAL
{
    public class MedicionDAO
    {
        #region Métodos de Escritura (Insertar)

        public int Insertar(Medicion obj)
        {
            // 1. Definir la consulta SQL
            string query = @"INSERT INTO Medicion 
                            (PlantaID, FechaRegistro, Temperatura, Humedad, Luminosidad, 
                             AlertaTemperatura, AlertaHumedad, AlertaLuz) 
                            VALUES 
                            (@PlantaID, @FechaRegistro, @Temperatura, @Humedad, @Luminosidad, 
                             @AlertaTemp, @AlertaHum, @AlertaLuz)";

            // 2. Preparar los parámetros
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@PlantaID", obj.PlantaID),
                new SqlParameter("@FechaRegistro", obj.FechaRegistro),
                new SqlParameter("@Temperatura", obj.Temperatura),
                new SqlParameter("@Humedad", obj.Humedad),
                new SqlParameter("@Luminosidad", obj.Luminosidad),
                new SqlParameter("@AlertaTemp", obj.AlertaTemperatura),
                new SqlParameter("@AlertaHum", obj.AlertaHumedad),
                new SqlParameter("@AlertaLuz", obj.AlertaLuz)
            };

            // 3. Ejecutar usando tu SqlHelper
            return SqlHelper.GetInstance().ExecuteNonQuery(query, parametros);
        }

        #endregion

        #region Métodos de Lectura (Consultas para Reportes)

        public List<Medicion> ListarPorRango(int plantaID, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Medicion> lista = new List<Medicion>();

            // 1. Consulta SQL filtrando por Planta y Fechas
            string query = @"SELECT MedicionID, PlantaID, FechaRegistro, Temperatura, Humedad, Luminosidad, 
                                    AlertaTemperatura, AlertaHumedad, AlertaLuz
                             FROM Medicion 
                             WHERE PlantaID = @PlantaID 
                             AND FechaRegistro BETWEEN @FechaDesde AND @FechaHasta 
                             ORDER BY FechaRegistro ASC";

            // 2. Parámetros para el filtro
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@PlantaID", plantaID),
                new SqlParameter("@FechaDesde", fechaDesde),
                new SqlParameter("@FechaHasta", fechaHasta)
            };

            // 3. Obtener DataTable del Helper
            DataTable tabla = SqlHelper.GetInstance().ExecuteReader(query, parametros);

            // 4. Mapeo: Convertir cada fila del DataTable a un objeto Medicion
            foreach (DataRow row in tabla.Rows)
            {
                Medicion medicion = new Medicion();

                medicion.MedicionID = Convert.ToInt32(row["MedicionID"]);
                medicion.PlantaID = Convert.ToInt32(row["PlantaID"]);
                medicion.FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]);

                // Conversiones seguras según tu DB (Decimal 5,2)
                medicion.Temperatura = (float)Convert.ToDecimal(row["Temperatura"]);
                medicion.Humedad = (float)Convert.ToDecimal(row["Humedad"]);
                medicion.Luminosidad = Convert.ToInt32(row["Luminosidad"]);

                // Conversión de BIT (SQL) a bool (C#)
                medicion.AlertaTemperatura = Convert.ToBoolean(row["AlertaTemperatura"]);
                medicion.AlertaHumedad = Convert.ToBoolean(row["AlertaHumedad"]);
                medicion.AlertaLuz = Convert.ToBoolean(row["AlertaLuz"]);

                lista.Add(medicion);
            }

            return lista;
        }

        #endregion
    }
}