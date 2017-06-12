#include "SPI.h"
#include "MCP2515.h"
#include "Arduino.h"
#include "SoftwareSerial.h"
#include "iCommunicate.hpp"
#include "AlcoholSensor.h"

const int buttonPinStartMeasurement = 1;

const int timeInterval = 1000;
const int sensorPin =  A0;
const int numberOfReadings = 20;
const int timeBetweenReadings = 100;

Alcohol alc(timeInterval, sensorPin, numberOfReadings, timeBetweenReadings);
CANMSG msg;
iCommunicate _com;

void setup() {
  Serial.begin(9600);
  while (!Serial); // Wait for Serial connection from PC
  SPI.setClockDivider(SPI_CLOCK_DIV8); // Setup SPI

  // Setup CAN
  if (!_com.Init()) {
    Serial.println("Setting up CAN failed");
  }

  _com.SetCallback(GetMessage); // Set callback

  //setting pinModes
  pinMode(buttonPinStartMeasurement, INPUT);

}

void loop()
{
  while (alc.warmingUp == true) alc.warmUp();
  if (alc.warmingUp == false) 
  {
    Serial.println(alc.measureBAC());
    SendMsg();
  }
}

// Gets called when message is recieved, msg.data contains the data.
void GetMessage(CANMSG msg) {
  for (uint8_t i = 0; i < msg.dataLength; i++) {
    Serial.print("Msg: ");
    Serial.print(i);
    Serial.print(" Data: ");
    Serial.println(msg.data[i]);
  }
}

void SendMsg() {
  msg.adrsValue = 0x60;
  msg.isExtendedAdrs = false;
  msg.rtr = false;
  msg.dataLength = 2;
  msg.data[0] = alc.getLastReading();
  msg.data[1] = alc.getState();
  msg.data[2] = 0;
  msg.data[3] = 0;
  msg.data[4] = 0;
  msg.data[5] = 0;
  msg.data[6] = 0;
  msg.data[7] = 0;

  if (_com.Write(msg)) {
    Serial.println("Wrote msg");
  }
  else {
    Serial.println("Writing went wrong");
  }
}

