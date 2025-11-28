#ifndef RED_HAL_H
#define RED_HAL_H

#include <Arduino.h>
#include <WiFi.h>
#include <time.h>

class Red_HAL {
  private:
    const char* _ssid;
    const char* _password;
    long _gmtOffset;

  public:
    Red_HAL(const char* ssid, const char* password);
    void conectar();
    void iniciarReloj();
    String obtenerFechaActual();
};

#endif