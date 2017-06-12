#define LDRpin A1 // pin where we connected the LDR and the resistor

int LDRValue = 0;     // result of reading the analog pin
bool DigiLDRValue = false;
void setup() {
  Serial.begin(9600); // sets serial port for communication
}

void loop() {
  LDRValue = analogRead(LDRpin); // read the value from the LDR
  DigiLDRValue = digitalRead(LDRpin);
  //Serial.println(LDRValue);      // print the value to the serial port
  Serial.println(DigiLDRValue);
  delay(100);                    // wait a little
}
