using BE;
using DAL;
using Newtonsoft.Json;
using System;

namespace BLL
{
    public class MedicionBLL
    {
        private MedicionDAO medicionDAO = new MedicionDAO();

        // ¡OJO! Al ser 'static', esta variable se comparte entre TODAS las plantas.
        // Si tienes la Planta 1 y la Planta 2, y se guarda la 1, la 2 tendrá que esperar 5 min.
        // Para arreglar esto rápido sin complicar, quítale el 'static' si quieres que cada ventana tenga su propio temporizador.
        private DateTime _ultimaGuardada = DateTime.MinValue;

        // DTOs Privados
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

        public Medicion InterpretarDatosSensor(string jsonRaw, int slotEsperado, int plantaId)
        {
            try
            {
                // Limpieza básica por si llega basura antes o después del JSON
                if (string.IsNullOrEmpty(jsonRaw)) return null;

                // A veces el puerto serie manda " 25.4 }" incompleto. Validamos llaves.
                int inicio = jsonRaw.IndexOf('{');
                int fin = jsonRaw.LastIndexOf('}');

                if (inicio == -1 || fin == -1 || inicio >= fin) return null;

                // Extraemos solo la parte JSON válida
                string jsonLimpio = jsonRaw.Substring(inicio, (fin - inicio) + 1);

                var paquete = JsonConvert.DeserializeObject<PaqueteSensorDTO>(jsonLimpio);

                if (paquete == null) return null;

                // --- CORRECCIÓN IMPORTANTE: VALIDAR SLOT ---
                // Si el dato viene del Slot 2 y esta ventana es del Slot 1, IGNORAR.
                if (paquete.SlotID != slotEsperado) return null;

                return new Medicion
                {
                    PlantaID = plantaId,
                    FechaRegistro = DateTime.Now,
                    Temperatura = paquete.valores.temp_c,
                    Humedad = paquete.valores.hum_rel,
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

            // Si le quitas el 'static' arriba, este tiempo es por ventana abierta.
            //bool pasoTiempoSuficiente = (DateTime.Now - _ultimaGuardada).TotalMinutes >= 1;
            bool pasoTiempoSuficiente = (DateTime.Now - _ultimaGuardada).TotalSeconds >= 5;


            if (hayAlerta || pasoTiempoSuficiente)
            {
                medicionDAO.Insertar(medicion);
                _ultimaGuardada = DateTime.Now;
            }
        }
    }
}