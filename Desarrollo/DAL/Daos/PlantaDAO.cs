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
        INSERT INTO Planta (Nombre, PlanCultivoID) 
        VALUES (@nombre, @planId); 
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>
    {
        new System.Data.SqlClient.SqlParameter("@nombre", planta.Nombre),
        new System.Data.SqlClient.SqlParameter("@planId", planta.PlanCultivoID)
    };

   
            System.Data.DataTable table = sqlHelper.ExecuteReader(query, parametros);

            if (table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }

            return 0;
        }
    }
}