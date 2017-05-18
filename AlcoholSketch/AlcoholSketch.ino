const long interval = 300000; // wait 5 minutes
const int sensorPin = A0;
const int buttonPinStartMeasurement = 1;
const int buttonPinGetLastMeasurement = 2;
const int numberOfReadings = 20;
const int timeBetweenReadings = 100;
unsigned long previousMillis = 0;
double highestReading = 0;
double lastReading = 0;
bool warmingUp = true;

void setup() {
  Serial.begin(9600);
  pinMode(buttonPinStartMeasurement, INPUT);
  pinMode(buttonPinGetLastMeasurement, INPUT);
}

void loop()
{
  while (warmingUp == true) warmUp();
  if (buttonPinStartMeasurement) measureBAC();
  if (buttonPinGetLastMeasurement) Serial.println(lastReading);
}

void warmUp()
{
  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis >= interval)
  {
    previousMillis = currentMillis;
    warmingUp = false;
  }
}

void measureBAC()
{
  for (int i = 0; i < numberOfReadings; i++)
  {
    int readAlcoholSensor = analogRead(sensorPin);
    double calculatedBAC = (readAlcoholSensor * 0.08) / 450;
    if (highestReading < calculatedBAC)
    {
      highestReading = calculatedBAC;
      delay(timeBetweenReadings);
    }
  }
  lastReading = highestReading;
  resetValues();
}

void resetValues()
{
  highestReading = 0;
  resetTimer();
  warmingUp = true;
}

void resetTimer()
{
  unsigned long currentMillis = millis();
  previousMillis = currentMillis;
}

