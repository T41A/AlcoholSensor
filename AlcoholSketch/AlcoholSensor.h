/*
  AlcoholSensor.h - Class for Alcohol measurement.
  Created by Rick v Boxtel, May 22, 2017.
*/
#ifndef AlcoholSensor_h
#define AlcoholSensor_h

#include "Arduino.h"

class Alcohol
{
  public:
    Alcohol(int timeInterval, int sensorPin, int numberOfReadings, int timeBetweenReadings);
    void warmUp();
    double measureBAC();
    void resetValues();
    bool warmingUp = true;


  private:
    long timeInterval; // wait 5 minutes
    int alcoholSensorPin;
    int numberOfMeasurementReadings;
    int timeBetweenMeasurementReadings;
    unsigned long previousMillis = 0;
};

Alcohol::Alcohol(int _timeInterval, int _alcoholSensorPin, int _numberOfMeasurementReadings, int _timeBetweenMeasurementReadings)
{
  timeInterval = _timeInterval;
  alcoholSensorPin = _alcoholSensorPin;
  numberOfMeasurementReadings = _numberOfMeasurementReadings;
  timeBetweenMeasurementReadings = _timeBetweenMeasurementReadings;
}

void Alcohol::warmUp()
{
  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis >= timeInterval)
  {
    previousMillis = currentMillis;
    warmingUp = false;
  }
}

double Alcohol::measureBAC() //double terug returnen
{
  double highestReading;
  for (int i = 0; i < numberOfMeasurementReadings; i++)
  {
    int readAlcoholSensor = analogRead(alcoholSensorPin);
    double calculatedBAC = (readAlcoholSensor * 0.08) / 450;
    if (highestReading < calculatedBAC)
    {
      highestReading = calculatedBAC;
      delay(timeBetweenMeasurementReadings);
    }
  }
  resetValues();
  return highestReading;
}

void Alcohol::resetValues()
{
  unsigned long currentMillis = millis();
  previousMillis = currentMillis;
  warmingUp = true;
}

#endif
