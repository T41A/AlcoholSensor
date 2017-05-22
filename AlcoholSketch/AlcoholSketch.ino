#include "Arduino.h"
#include "AlcoholSensor.h"

const int buttonPinStartMeasurement = 1;
const int buttonPinGetLastMeasurement = 2;

Alcohol alc(300000, A0, 20, 100);

void setup() {
  Serial.begin(9600);
  pinMode(buttonPinStartMeasurement, INPUT);
  pinMode(buttonPinGetLastMeasurement, INPUT);
}

void loop()
{
  double _BACreading = 0;
  while (alc.warmingUp == true) alc.warmUp();
  if (buttonPinStartMeasurement) _BACreading = alc.measureBAC();
  if (buttonPinGetLastMeasurement) Serial.println(_BACreading);
}
