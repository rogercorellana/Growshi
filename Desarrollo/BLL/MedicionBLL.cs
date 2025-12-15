using BE;
using DAL;
using DAL.Daos; // Asegúrate de que apunte a tus DAOs
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class MedicionBLL
    {
        private MedicionDAO medicionDAO = new MedicionDAO();

        // Variable para controlar el spam de guardado (sin static para que sea por instancia)
        private DateTime _ultimaGuardada = DateTime.MinValue;

        #region DTOs Privados (Para interpretación del Sensor)
        private class PaqueteSensorDTO
        {
            public int SlotID { get; set; }
            public ValoresDataDTO valores { get; set; }
            public int[] alertas { get; set; }
        }
        private class ValoresDataDTO
        {
            public float temp_c { get; set; }
            public float hum_rel { get; set; }
            public int luz_pct { get; set; }
        }
        #endregion

        #region Lógica IoT (Sensores y Guardado)

        public Medicion InterpretarDatosSensor(string jsonRaw, int slotEsperado, int plantaId)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonRaw)) return null;

                // Validación y limpieza de JSON
                int inicio = jsonRaw.IndexOf('{');
                int fin = jsonRaw.LastIndexOf('}');

                if (inicio == -1 || fin == -1 || inicio >= fin) return null;

                string jsonLimpio = jsonRaw.Substring(inicio, (fin - inicio) + 1);

                var paquete = JsonConvert.DeserializeObject<PaqueteSensorDTO>(jsonLimpio);

                if (paquete == null) return null;

                // Validación de seguridad: Que el dato venga del slot correcto
                if (paquete.SlotID != slotEsperado) return null;

                return new Medicion
                {
                    PlantaID = plantaId,
                    FechaRegistro = DateTime.Now,
                    // Conversión explicita de float (sensor) a decimal (base de datos)
                    Temperatura = (float)(decimal)paquete.valores.temp_c,
                    Humedad = (float)(decimal)paquete.valores.hum_rel,
                    Luminosidad = paquete.valores.luz_pct,
                    AlertaTemperatura = paquete.alertas[0] == 1,
                    AlertaHumedad = paquete.alertas[1] == 1,
                    AlertaLuz = paquete.alertas[2] == 1
                };
            }
            catch
            {
                return null;
            }
        }

        public void Guardar(Medicion medicion)
        {
            if (medicion == null || medicion.PlantaID <= 0) return;

            bool hayAlerta = medicion.AlertaTemperatura || medicion.AlertaHumedad || medicion.AlertaLuz;

            // Lógica de frecuencia: Guardar si hay alerta O si pasaron 5 segundos
            bool pasoTiempoSuficiente = (DateTime.Now - _ultimaGuardada).TotalSeconds >= 5;

            if (hayAlerta || pasoTiempoSuficiente)
            {
                medicionDAO.Insertar(medicion);
                _ultimaGuardada = DateTime.Now;
            }
        }

        #endregion

        #region Lógica de Reportes (Nueva funcionalidad)

        public List<Medicion> ObtenerHistorial(int plantaID, string claveFiltro)
        {
            DateTime fechaHasta = DateTime.Now;
            DateTime fechaDesde;

            // 1. Traducir el "filtro" del usuario a fechas reales
            switch (claveFiltro)
            {
                case "semana":
                case "filtro_ultima_semana":
                    fechaDesde = fechaHasta.AddDays(-7);
                    break;

                case "mes":
                case "filtro_ultimo_mes":
                    fechaDesde = fechaHasta.AddMonths(-1);
                    break;

                case "todo":
                case "filtro_todo_historial":
                    fechaDesde = new DateTime(2000, 1, 1); // Fecha base arbitraria
                    break;

                default:
                    fechaDesde = fechaHasta.AddDays(-7); // Por defecto, última semana
                    break;
            }

            // 2. Llamar a la DAL con el rango calculado
            return medicionDAO.ListarPorRango(plantaID, fechaDesde, fechaHasta);
        }

        #endregion
    }
}