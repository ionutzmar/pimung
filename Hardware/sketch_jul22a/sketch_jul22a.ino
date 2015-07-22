#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const int tempPin = A4;
float temperature; //ACTUAL temperature
float tempArray[200];  //An array of the last 200 temperatures
float tempSum = 0;  // the sum of the last 200 temperatures
float temp; //the average of the last 200 temperatures
int tempNumber = 200;
int counter = -1;
int tempUnits;
int hours = 0;
int minutes = 0;
int seconds;
unsigned long lastTime;
unsigned long currentTime;


byte grade[8] = {
  B01110,
  B10001,
  B10001,
  B01110,
  B00000,
  B00000,
  B00000,
};

void setup() {
  Serial.begin(9600);
  lcd.begin(16, 2);
  for (int i = 0; i < tempNumber; i++)
  {
    tempArray[i] = ((analogRead(tempPin)/1024.0)*5.0 - 0.5)*100;
    tempSum += tempArray[i];
  }
  
  temp = tempSum / tempNumber;
  
  pinMode(6, INPUT);
  pinMode(7, INPUT);
  pinMode(8, INPUT);
  
  lcd.createChar(0, grade);
  lastTime = millis();
  
  
}

void loop() {
  
    temperature = ((analogRead(tempPin)/1024.0)*5.0 - 0.5)*100;
  if (counter > tempNumber - 1)
    counter = 0;
  else
    counter++;
   tempSum -= tempArray[counter];
   tempArray[counter] = temperature;
   tempSum += tempArray[counter];
   temp = tempSum / tempNumber;
   tempUnits = (int) temp;      /////////////////////////// TempUnits
  //Serial.println(tempUnits);
 
 currentTime = millis();
  
  if (currentTime - lastTime >= 1000)
  {
    lastTime += 1000;
    seconds++;
  }
  if (seconds > 59)
  {
    seconds = 0;
    minutes++;
  }
  if (minutes > 59)
  {
    minutes = 0;
    hours++;
  }
   
  if (hours > 23)
  hours = 0;
  
  
  
  lcd.setCursor(0, 0);
  lcd.print(hours);
  lcd.print(":");
  lcd.print(minutes);
  lcd.print(":");
  lcd.print(seconds);
  
  lcd.setCursor(0,1);
  lcd.print(temp);
  lcd.print(" ");
  lcd.write(byte(0));
  lcd.print("C");
  
 Serial.print(hours);
 Serial.print(":");
 Serial.print(minutes);
 Serial.print(":");
 Serial.println(seconds);
 Serial.print("Pin 6 is: ");
 Serial.println(digitalRead(6));
 Serial.print("Pin 7 is: ");
 Serial.print(digitalRead(7));
 Serial.print("Pin 8 is: ");
 Serial.print(digitalRead(8));
 Serial.print("Analog value: ");
 Serial.println(analogRead(A2));
 
 
}
