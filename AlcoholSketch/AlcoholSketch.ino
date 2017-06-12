#include "Arduino.h"
#include "AlcoholSensor.h"

const int buttonPinStartMeasurement = 1;
const int buttonPinGetLastMeasurement = 2;

Alcohol alc(1000, A0, 20, 100); // Wat is A0? en de andere magische cijfers

void setup() {
  Serial.begin(9600);
  pinMode(buttonPinStartMeasurement, INPUT);
  pinMode(buttonPinGetLastMeasurement, INPUT);
}

void loop()
{
  while (alc.warmingUp == true) alc.warmUp();
  Serial.println(alc.measureBAC());
}
