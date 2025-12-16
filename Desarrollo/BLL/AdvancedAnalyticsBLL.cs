using BE.DataMining; // Referencia a los DTOs que creamos antes
using DAL;           // Referencia para conectar con la BD
using DAL.Daos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class AdvancedAnalyticsBLL
    {
        // Instancia del Acceso a Datos (El puente al SQL)
        private readonly DataMiningDAO _dao;

        public AdvancedAnalyticsBLL()
        {
            _dao = new DataMiningDAO();
        }

        #region 1. Pronóstico Climático (Time Series / Series Temporales)

        /// <summary>
        /// Algoritmo de Minería: "Pattern Recognition" (Reconocimiento de Patrones)
        /// 1. Lee la historia reciente.
        /// 2. Aprende el comportamiento promedio de cada hora (00:00 a 23:00).
        /// 3. Proyecta ese comportamiento hacia el futuro.
        /// </summary>
        public List<PronosticoItem> ObtenerPronosticoExtendido()
        {
            // PASO 1: Obtener Datos Reales del Data Warehouse (Últimos 7 días)
            // Esto nos da una base estadística sólida.
            var historial = _dao.ObtenerHistorialReciente(7);

            // Validación: Si el DW está vacío (recién instalado), devolvemos lista vacía para no romper la UI.
            if (historial == null || historial.Count == 0) return new List<PronosticoItem>();

            // PASO 2: Aprendizaje (Mining)
            // Agrupamos por HORA para aprender el "Perfil Diario" de tu cultivo.
            // Ejemplo: "A las 14:00, la temperatura promedio suele ser 26°C".
            var patronesHorarios = historial
                .GroupBy(x => x.Hora)
                .Select(g => new {
                    Hora = g.Key,
                    TempPromedio = g.Average(x => x.Temperatura),
                    HumPromedio = g.Average(x => x.Humedad)
                })
                .ToDictionary(k => k.Hora, v => v);

            // PASO 3: Proyección (Forecasting)
            var listaPrediccion = new List<PronosticoItem>();
            DateTime inicio = DateTime.Now;

            // Generamos 72 horas a futuro
            for (int i = 0; i < 72; i++)
            {
                DateTime t = inicio.AddHours(i);

                // Valores por defecto si no hay datos para esa hora
                double tempBase = 22;
                double humBase = 60;

                // Si aprendimos algo sobre esta hora, usamos ese conocimiento
                if (patronesHorarios.ContainsKey(t.Hour))
                {
                    tempBase = patronesHorarios[t.Hour].TempPromedio;
                    humBase = patronesHorarios[t.Hour].HumPromedio;
                }

                // Factor de Caos: Agregamos una pequeña variación aleatoria
                // porque el clima real nunca es una línea recta perfecta.
                Random rnd = new Random(i + t.Hour);
                double variacion = (rnd.NextDouble() * 1.5) - 0.75;

                double tempFinal = Math.Round(tempBase + variacion, 1);
                double humFinal = Math.Round(humBase - (variacion * 1.2), 1); // La humedad suele bajar si sube la temp

                // Detección de Anomalías (Regla de Negocio)
                // Si la predicción supera límites seguros, marcamos la bandera para la UI.
                bool esPeligroso = tempFinal > 30 || humFinal < 35;

                listaPrediccion.Add(new PronosticoItem
                {
                    FechaHora = t,
                    TempPredicha = tempFinal,
                    HumedadPredicha = humFinal,
                    EsAnomalia = esPeligroso
                });
            }

            return listaPrediccion;
        }
        #endregion

        #region 2. Análisis de VPD (Métrica Calculada)

        /// <summary>
        /// Calcula el Déficit de Presión de Vapor (VPD) basado en el pronóstico.
        /// El VPD indica si la planta está transpirando correctamente.
        /// </summary>
        public List<AnalisisVPD> ObtenerRiesgoVPD()
        {
            var lista = new List<AnalisisVPD>();

            // Reutilizamos el pronóstico que acabamos de calcular
            var pronostico = ObtenerPronosticoExtendido().Take(12); // Solo nos interesan las próximas 12hs

            foreach (var p in pronostico)
            {
                // FÓRMULA DE VPD (Arrhenius equation approximation)
                // SVP = Presión de Vapor de Saturación
                double svp = 0.61078 * Math.Exp((17.27 * p.TempPredicha) / (p.TempPredicha + 237.3));

                // VPD = SVP * (1 - Humedad Relativa/100)
                double vpd = Math.Round(svp * (1 - (p.HumedadPredicha / 100)), 2);

                // Clasificación de Riesgo (Data Mining simple: Clasificación)
                string zona = "Optimo"; // 0.4 a 1.6 kPa
                if (vpd < 0.4) zona = "Riesgo Hongo"; // Muy húmedo, la planta no transpira
                if (vpd > 1.6) zona = "Estrés Hídrico"; // Muy seco, la planta cierra estomas

                lista.Add(new AnalisisVPD
                {
                    Hora = p.FechaHora.ToString("HH:00"),
                    ValorVPD = vpd,
                    ZonaRiesgo = zona
                });
            }
            return lista;
        }
        #endregion

        #region 3. Análisis de Calidad de Luz (Consistencia)

        /// <summary>
        /// Analiza si la iluminación fue consistente en los últimos días.
        /// Detecta fallas en lámparas o cortes de luz basándose en promedios diarios.
        /// </summary>
        public List<AnalisisLuz> ObtenerAnalisisIluminacion()
        {
            var historial = _dao.ObtenerHistorialReciente(5); // Últimos 5 días
            var lista = new List<AnalisisLuz>();

            if (historial == null || historial.Count == 0) return lista;

            // Agregación de Datos:
            // 1. Filtramos solo horas donde DEBERÍA haber luz (ej. 06:00 a 18:00)
            // 2. Agrupamos por Día.
            // 3. Calculamos el promedio.
            var analisisDiario = historial
                .Where(x => x.Hora >= 6 && x.Hora <= 19) // Asumimos fotoperiodo diurno
                .GroupBy(x => x.FechaHora.Date)
                .Select(g => new {
                    Fecha = g.Key,
                    PromedioLuz = g.Average(x => x.Luminosidad)
                })
                .OrderBy(x => x.Fecha)
                .ToList();

            foreach (var dia in analisisDiario)
            {
                double prom = Math.Round(dia.PromedioLuz, 1);

                // Evaluación de Estado
                string estado = "OK";
                if (prom < 50) estado = "Fallo Leve";
                if (prom < 20) estado = "Fallo Crítico"; // Posible foco quemado

                lista.Add(new AnalisisLuz
                {
                    Dia = dia.Fecha.ToString("ddd"), // Lun, Mar, Mie...
                    PromedioLuz = prom,
                    MetaLuz = 60, // Meta ideal (casi 100%)
                    Estado = estado
                });
            }

            return lista;
        }
        #endregion

        #region 4. Generación de Insights Avanzados (NUEVO Y MEJORADO)

        /// <summary>
        /// Motor de Inferencia: Analiza todas las dimensiones y prioriza alertas.
        /// </summary>
        public string GenerarResumenEjecutivo()
        {
            // 1. Recopilar toda la inteligencia
            var pronostico = ObtenerPronosticoExtendido();
            var analisisLuz = ObtenerAnalisisIluminacion();
            var analisisVPD = ObtenerRiesgoVPD();

            if (pronostico.Count == 0) return "SISTEMA EN ESPERA: Recopilando datos del Data Warehouse...";

            // 2. Variables de decisión
            double maxTemp = pronostico.Max(x => x.TempPredicha);
            double minHum = pronostico.Min(x => x.HumedadPredicha);
            bool hayRiesgoHongo = analisisVPD.Any(x => x.ZonaRiesgo == "Riesgo Hongo");
            bool falloLuzReciente = analisisLuz.Any(x => x.Estado.Contains("Fallo"));

            // 3. Constructor de mensaje inteligente
            // Usamos una lista de alertas para unirlas elegantemente
            List<string> alertas = new List<string>();

            // Prioridad 1: Clima Extremo (Vida o Muerte)
            if (maxTemp > 30)
                alertas.Add($"🔥 CALOR EXTREMO: Se prevén {maxTemp}°C en las próximas 48hs.");

            if (minHum < 35)
                alertas.Add($"💧 SEQUEDAD: Humedad peligrosamente baja ({minHum}%). Riesgo de deshidratación.");

            // Prioridad 2: Enfermedades (VPD)
            if (hayRiesgoHongo)
                alertas.Add($"🍄 ALERTA BIOLÓGICA: El VPD bajará demasiado. Condiciones ideales para hongos.");

            // Prioridad 3: Infraestructura (Luz)
            if (falloLuzReciente)
            {
                var diaFallo = analisisLuz.LastOrDefault(x => x.Estado.Contains("Fallo"))?.Dia ?? "recientemente";
                alertas.Add($"💡 FALLO TÉCNICO: Se detectó baja potencia lumínica el {diaFallo}. Revisar focos.");
            }

            // 4. Decisión Final
            if (alertas.Count > 0)
            {
                // Si hay problemas, mostramos hasta 2 para no saturar, separados por guión
                return "⚠️ ATENCIÓN REQUERIDA: " + string.Join("  |  ", alertas.Take(2));
            }
            else
            {
                // Mensaje positivo con un "Dato Curioso" variable para que no sea aburrido
                double promTemp = Math.Round(pronostico.Average(x => x.TempPredicha), 1);
                return $"✅ CULTIVO ÓPTIMO: Todos los parámetros estables. Temperatura promedio proyectada: {promTemp}°C.";
            }
        }
        #endregion
    }
}