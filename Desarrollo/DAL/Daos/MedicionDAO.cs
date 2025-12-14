using BE;
using DAL.DAO; // Aquí está tu SqlHelper
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class MedicionDAO
    {
        public int Insertar(Medicion obj)
        {
            // 1. Definir la consulta SQL (Coincide con tu script de DB)
            string query = @"INSERT INTO Medicion 
                            (PlantaID, FechaRegistro, Temperatura, Humedad, Luminosidad, 
                             AlertaTemperatura, AlertaHumedad, AlertaLuz) 
                            VALUES 
                            (@PlantaID, @FechaRegistro, @Temperatura, @Humedad, @Luminosidad, 
                             @AlertaTemp, @AlertaHum, @AlertaLuz)";

            // 2. Preparar los parámetros para el SqlHelper
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@PlantaID", obj.PlantaID),
                new SqlParameter("@FechaRegistro", obj.FechaRegistro),
                new SqlParameter("@Temperatura", obj.Temperatura),
                new SqlParameter("@Humedad", obj.Humedad),
                new SqlParameter("@Luminosidad", obj.Luminosidad),
                
                // SQL Server maneja bool como BIT automáticamente
                new SqlParameter("@AlertaTemp", obj.AlertaTemperatura),
                new SqlParameter("@AlertaHum", obj.AlertaHumedad),
                new SqlParameter("@AlertaLuz", obj.AlertaLuz)
            };

            // 3. Ejecutar usando tu Helper Singleton
            // Esto devuelve el número de filas afectadas (debería ser 1)
            return SqlHelper.GetInstance().ExecuteNonQuery(query, parametros);
        }
    }
}