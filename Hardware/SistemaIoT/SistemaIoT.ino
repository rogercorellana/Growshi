#include <ArduinoJson.h>

// --- IMPORTACIÓN DE CAPAS (Rutas explícitas) ---
// Como están en carpetas, debemos indicar la ruta desde 'src'
#include "src/HAL/Red_HAL.h"
#include "src/BLL/Sensor_BLL.h"
#include "src/Models/Lectura_DTO.h"

// --- INYECCIÓN DE DEPENDENCIAS ---
// Configuramos el Wi-Fi aquí (Capa Superior)
Red_HAL red("ARNEZ-WIFI", "blackpink");

// Instanciamos la lógica
Sensor_BLL sensor;

void setup() {
  Serial.begin(115200);
  delay(500);
  
  Serial.println("--- SISTEMA POR CAPAS INICIADO ---");

  // Iniciamos Hardware
  red.conectar();
  red.iniciarReloj();

  // Iniciamos Lógica
  sensor.iniciar();
}

void loop() {
  // 1. Capa DAL: Obtener infraestructura (Fecha)
  String fecha = red.obtenerFechaActual();

  // 2. Capa BLL: Obtener negocio (Datos procesados)
  LecturaDTO datos = sensor.leerYProcesar();

  // 3. Capa Presentación: Armar JSON
  JsonDocument doc;

  doc["SlotID"] = "Slot1";
  doc["tipoDispositivo"] = "sensor_ambiente";
  doc["fecha_registro"] = fecha;

  JsonObject valores = doc["valores"].to<JsonObject>();
  valores["temp_c"] = datos.temperatura;
  valores["hum_rel"] = datos.humedad;

  // Array de enteros [1] o [0]
  JsonArray alertas = doc["alertas"].to<JsonArray>();
  alertas.add(datos.alerta);

  // 4. Envío
  serializeJson(doc, Serial);
  Serial.println(); 

  delay(10000);
}