#include "Red_HAL.h"

Red_HAL::Red_HAL(const char* ssid, const char* password) {
  _ssid = ssid;
  _password = password;
  _gmtOffset = -3 * 3600; // GMT-3 Argentina
}

void Red_HAL::conectar() {
  Serial.print("[DAL] Conectando a WiFi: ");
  Serial.println(_ssid);
  WiFi.begin(_ssid, _password);
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\n[DAL] Conectado!");
}

void Red_HAL::iniciarReloj() {
  configTime(_gmtOffset, 0, "pool.ntp.org", "time.nist.gov");
  struct tm timeinfo;
  if(!getLocalTime(&timeinfo)){
    Serial.println("[DAL] Error NTP inicial");
  }
}

String Red_HAL::obtenerFechaActual() {
  struct tm timeinfo;
  if(!getLocalTime(&timeinfo)) return "ErrorHora";
  char buffer[30];
  strftime(buffer, 30, "%Y-%m-%d %H:%M:%S", &timeinfo);
  return String(buffer);
}