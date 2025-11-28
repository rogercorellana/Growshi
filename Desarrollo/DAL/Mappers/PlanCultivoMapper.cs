using System;
using System.Data;
using BE;

namespace DAL.Mappers
{
    internal static class PlanCultivoMapper
    {
        public static PlanCultivo Map(DataRow row)
        {
            return new PlanCultivo
            {
                PlanCultivoID = Convert.ToInt32(row["PlanCultivoID"]),
                NombrePlan = row["NombrePlan"].ToString(),
                FechaInicio = Convert.ToDateTime(row["FechaInicio"]),
                Estado = row["Estado"].ToString()
            };
        }
    }
}