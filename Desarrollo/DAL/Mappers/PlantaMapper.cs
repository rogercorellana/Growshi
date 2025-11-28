using System;
using System.Data;
using BE;

namespace DAL.Mappers
{
    internal static class PlantaMapper
    {
        public static Planta Map(DataRow row)
        {
            return new Planta
            {
                PlantaID = Convert.ToInt32(row["PlantaID"]),
                Nombre = row["Nombre"].ToString(),
                PlanCultivoID = Convert.ToInt32(row["PlanCultivoID"]),

             
                NombrePlan = row["NombrePlan"].ToString()
            };
        }
    }
}