#include <WiFi.h>
#include <time.h>
#include <ArduinoJson.h>
#include "DHT.h"
#include <LittleFS.h>
#include <WiFiManager.h> 

// ==========================================
// 1. CONFIGURACIÓN
// ==========================================
#define PIN_DHT 4       
#define TIPO_DHT DHT22  
#define PIN_LDR 36      

#define INTERVALO_SEGUNDOS 10 

const long  gmtOffset_sec = -3 * 3600; 
const int   daylightOffset_sec = 0; 

// ==========================================
// 2. OBJETOS
// ==========================================
DHT dht(PIN_DHT, TIPO_DHT);
float tempReal; 
float humReal; 
int luzPct;    

// ==========================================
// 3. FUNCIONES AUXILIARES
// ==========================================

void iniciarWiFi() {
  if (WiFi.status() == WL_CONNECTED) return;

  WiFiManager wm;
  // wm.resetSettings(); // Descomentar solo si necesitas borrar red guardada

  Serial.println("--- Iniciando WiFi Manager ---");
  wm.setConfigPortalTimeout(120); 

  bool res = wm.autoConnect("Growshi-Config"); 

  if(!res) {
    Serial.println("⚠️ Timeout WiFi. Modo OFFLINE activado.");
  } else {
    Serial.println("✅ WiFi Conectado.");
  }
}

void sincronizarHoraInternet() {
  if (WiFi.status() != WL_CONNECTED) return;
  configTime(gmtOffset_sec, daylightOffset_sec, "pool.ntp.org", "time.nist.gov");
  struct tm timeinfo;
  getLocalTime(&timeinfo); 
}

String obtenerFechaActual() {
  struct tm timeinfo;
  char fechaString[30];
  if(getLocalTime(&timeinfo)){
    if(timeinfo.tm_year + 1900 < 2020) return "OFFLINE_DATE"; 
    strftime(fechaString, 30, "%Y-%m-%d %H:%M:%S", &timeinfo);
    return String(fechaString);
  } else {
    return "OFFLINE_DATE";
  }
}

// ==========================================
// 4. GESTIÓN OFFLINE
// ==========================================
void guardarEnFlash(String datos) {
  File fCheck = LittleFS.open("/offline_data.txt", "r");
  if (fCheck) {
    if (fCheck.size() > 50000) { fCheck.close(); return; }
    fCheck.close();
  }
  File file = LittleFS.open("/offline_data.txt", FILE_APPEND);
  if(file){
    file.println(datos);
    file.close();
  }
}

void procesarDatosGuardados() {
  if (!LittleFS.exists("/offline_data.txt")) return;
  
  File fileCount = LittleFS.open("/offline_data.txt", "r");
  int totalLineas = 0;
  while(fileCount.available()){
    fileCount.readStringUntil('\n');
    totalLineas++;
  }
  fileCount.close();
  if (totalLineas == 0) return;

  time_t ahora;
  time(&ahora); 
  File fileRead = LittleFS.open("/offline_data.txt", "r");
  int lineaActual = 0;

  Serial.println("--- SINCRONIZANDO HISTORIAL ---");
  while(fileRead.available()){
    String jsonLinea = fileRead.readStringUntil('\n');
    if(jsonLinea.length() > 5) {
      long segundosAtras = (totalLineas - lineaActual) * INTERVALO_SEGUNDOS;
      time_t tiempoCalculado = ahora - segundosAtras;
      struct tm * timeinfo;
      timeinfo = localtime(&tiempoCalculado);
      char fechaReconstruida[30];
      strftime(fechaReconstruida, 30, "%Y-%m-%d %H:%M:%S", timeinfo);
      jsonLinea.replace("OFFLINE_DATE", String(fechaReconstruida));

      Serial.println(">>> RECONSTRUIDO:");
      Serial.println(jsonLinea);
      lineaActual++;
      delay(100); 
    }
  }
  fileRead.close();
  LittleFS.remove("/offline_data.txt");
  Serial.println("✅ Historial enviado.");
}

// ==========================================
// 5. SETUP Y LOOP
// ==========================================
void setup() {
  Serial.begin(115200);
  dht.begin();
  LittleFS.begin(true);

  iniciarWiFi();

  if(WiFi.status() == WL_CONNECTED) sincronizarHoraInternet();
}

void loop() {
  delay(INTERVALO_SEGUNDOS * 1000); 

  if(WiFi.status() != WL_CONNECTED) {
    WiFi.reconnect();
  } else {
    if(obtenerFechaActual() == "OFFLINE_DATE") sincronizarHoraInternet();
  }

  // --- LECTURAS ---
  float t = dht.readTemperature();
  float h = dht.readHumidity();
  tempReal = (isnan(t) || isnan(h)) ? 0.0 : t;
  humReal = (isnan(t) || isnan(h)) ? 0.0 : h;

  int lecturaRaw = analogRead(PIN_LDR); 

  // --- LUZ (CALIBRADA) ---
  // 0 (Flash) -> 100%
  // 4095 (Oscuridad) -> 0%
  // Ajustamos el rango a 0-100 invertido
  luzPct = constrain(map(lecturaRaw, 0, 4095, 100, 0), 0, 100);

  // --- JSON ---
  JsonDocument doc;
  doc["SlotID"] = 1; 
  doc["fecha_lectura"] = obtenerFechaActual(); 
  
  doc["valores"]["temp_c"] = tempReal;
  doc["valores"]["hum_rel"] = humReal;
  doc["valores"]["luz_pct"] = luzPct;
  
  // --- ALERTAS [Temp, Hum, Luz] ---
  // 0 = OK, 1 = ALERTA
  JsonArray alertas = doc["alertas"].to<JsonArray>();
  alertas.add(tempReal > 30 ? 1 : 0); 
  alertas.add((humReal < 20 || humReal > 80) ? 1 : 0);
  alertas.add(luzPct < 15 ? 1 : 0); // Alerta si hay menos de 15% de luz

  String jsonString;
  serializeJson(doc, jsonString);

  // --- ENVIO ---
  if(WiFi.status() == WL_CONNECTED && obtenerFechaActual() != "OFFLINE_DATE") {
    procesarDatosGuardados(); 
    Serial.println("📡 ENVIANDO LIVE:");
    Serial.println(jsonString);
  } else {
    Serial.println("⚠️ OFFLINE:"); 
    guardarEnFlash(jsonString);
  }
}