#ifndef SENSOR_BLL_H
#define SENSOR_BLL_H

#include <Arduino.h>
// IMPORTANTE: Referencia relativa para buscar el Modelo en la carpeta vecina
#include "src/Models/Lectura_DTO.h"

class Sensor_BLL {
  public:
    void iniciar();
    LecturaDTO leerYProcesar();
};

#endif