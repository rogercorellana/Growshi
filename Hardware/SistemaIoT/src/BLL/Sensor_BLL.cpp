#include "Sensor_BLL.h"

void Sensor_BLL::iniciar() {
  randomSeed(analogRead(0));
}

LecturaDTO Sensor_BLL::leerYProcesar() {
  LecturaDTO resultado;

  // 1. Simulación (Input)
  resultado.temperatura = random(200, 350) / 10.0;
  resultado.humedad = random(40, 90);

  // 2. Lógica (Regla de Negocio)
  // Si supera 30 grados, alerta = 0 (MAL)
  if (resultado.temperatura > 30.0) {
    resultado.alerta = 0; 
  } else {
    resultado.alerta = 1; 
  }

  return resultado;
}