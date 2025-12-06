using BE;
using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using DAL.Mappers;

namespace DAL.Daos
{
    public class PlantaDAO
    {
        private SqlHelper sqlHelper = SqlHelper.GetInstance();

        public List<Planta> Listar()
        {
            List<Planta> lista = new List<Planta>();

            string query = @"
                SELECT 
                    P.PlantaID, 
                    P.Nombre, 
                    P.PlanCultivoID,
                    P.FechaInicio,
                    PC.NombrePlan 
                FROM Planta P
                INNER JOIN PlanCultivo PC ON P.PlanCultivoID = PC.PlanCultivoID";

            DataTable table = sqlHelper.ExecuteReader(query, null);

            foreach (DataRow row in table.Rows)
            {
                lista.Add(PlantaMapper.Map(row));
            }

            return lista;
        }




        public int Insertar(Planta planta)
        {
            string query = @"
        INSERT INTO Planta (Nombre, PlanCultivoID, FechaInicio) 
        VALUES (@nombre, @planId, @fechaInicio); 
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>
    {
        new System.Data.SqlClient.SqlParameter("@nombre", planta.Nombre),
        new System.Data.SqlClient.SqlParameter("@planId", planta.PlanCultivoID),
        new System.Data.SqlClient.SqlParameter("@fechaInicio", DateTime.Now)

    };

   
            System.Data.DataTable table = sqlHelper.ExecuteReader(query, parametros);

            if (table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }

            return 0;
        }



        public Planta ObtenerPorSlot(int slotId)
        {
            // 1. La Query Mágica con el cálculo de días totales
            string query = @"
        SELECT 
            P.PlantaID, 
            P.Nombre, 
            P.PlanCultivoID, 
            P.FechaInicio,
            PC.NombrePlan,
            -- ESTO ES LO QUE TE FALTA PARA PODER CALCULAR EN LA UI:
            ISNULL((SELECT SUM(DuracionDias) FROM EtapaCultivo WHERE PlanCultivoID = P.PlanCultivoID), 0) AS DiasTotalesPlan
        FROM Slot S
        INNER JOIN Planta P ON S.PlantaAsociada = P.PlantaID
        INNER JOIN PlanCultivo PC ON P.PlanCultivoID = PC.PlanCultivoID
        WHERE S.SlotID = @SlotID"; // Filtramos por el Slot que recibes en el Form

            // 2. Pasamos el parámetro
            var parametros = new List<System.Data.SqlClient.SqlParameter>
    {
        new System.Data.SqlClient.SqlParameter("@SlotID", slotId)
    };

            // 3. Ejecutamos
            DataTable table = sqlHelper.ExecuteReader(query, parametros);

            if (table.Rows.Count > 0)
            {
                // Reusamos tu Mapper
                return PlantaMapper.Map(table.Rows[0]);
            }

            return null; // Slot vacío
        }



    }
}