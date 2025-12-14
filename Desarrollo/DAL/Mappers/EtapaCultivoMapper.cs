using System;
using System.Data;
using BE;

namespace DAL.Mappers
{
    public static class EtapaCultivoMapper
    {
        public static EtapaCultivo Map(DataRow row)
        {
            EtapaCultivo etapa = new EtapaCultivo();

            // 1. Identificadores y Datos Básicos
            etapa.EtapaCultivoID = Convert.ToInt32(row["EtapaCultivoID"]);
            etapa.PlanCultivoID = Convert.ToInt32(row["PlanCultivoID"]);
            etapa.Orden = Convert.ToInt32(row["Orden"]);

            // TRADUCCIÓN DE NOMBRES (BD -> BE)
            etapa.NombreEtapa = row["Nombre"].ToString();         // BD: Nombre -> BE: NombreEtapa
            etapa.Duracion = Convert.ToInt32(row["DuracionDias"]); // BD: DuracionDias -> BE: Duracion

            // 2. Variables Ambientales (Manejo de Nulos -> 0)

            // Temperatura
            etapa.TempMin = row["TempMinima"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TempMinima"]);
            etapa.TempMax = row["TempMaxima"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TempMaxima"]);

            // Humedad
            etapa.HumMin = row["HumedadMinima"] == DBNull.Value ? 0 : Convert.ToDecimal(row["HumedadMinima"]);
            etapa.HumMax = row["HumedadMaxima"] == DBNull.Value ? 0 : Convert.ToDecimal(row["HumedadMaxima"]);

            // pH
            etapa.PhMin = row["PHMinimo"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PHMinimo"]);
            etapa.PhMax = row["PHMaximo"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PHMaximo"]);

            // Electroconductividad (EC)
            etapa.EcMin = row["ECMinima"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ECMinima"]);
            etapa.EcMax = row["ECMaxima"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ECMaxima"]);


            etapa.HorasLuz = row["HorasLuz"] == DBNull.Value ? 0 : Convert.ToDecimal(row["HorasLuz"]);


            return etapa;
        }
    }
}