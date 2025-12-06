using System;
using System.Data;
using BE;

namespace DAL.Mappers
{
    public static class PlantaMapper
    {
        public static Planta Map(DataRow row)
        {
            // 1. Mapeamos primero los datos que SIEMPRE vienen (los obligatorios)
            var planta = new Planta
            {
                PlantaID = Convert.ToInt32(row["PlantaID"]),
                Nombre = row["Nombre"].ToString(),
                PlanCultivoID = Convert.ToInt32(row["PlanCultivoID"]),
                NombrePlan = row["NombrePlan"].ToString(),
                // Verificamos nulos en fecha por seguridad
                FechaInicio = row["FechaInicio"] != DBNull.Value
                              ? Convert.ToDateTime(row["FechaInicio"])
                              : DateTime.Now
            };

            // 2. EL TRUCO: Preguntamos si la columna existe antes de leerla
            if (row.Table.Columns.Contains("DiasTotalesPlan"))
            {
                // Si la columna existe (viene de ObtenerPorSlot), leemos el valor
                planta.DiasTotalesPlan = row["DiasTotalesPlan"] != DBNull.Value
                                         ? Convert.ToInt32(row["DiasTotalesPlan"])
                                         : 0;
            }
            else
            {
                // Si la columna NO existe (viene de Listar), ponemos 0 por defecto
                planta.DiasTotalesPlan = 0;
            }

            return planta;
        }
    }
}