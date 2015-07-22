#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const int tempPin = A4;
const int controlPin = 6;
const int hoursPin = 7;
const int minutesPin = 8;
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
int prevControlState;
int prevHoursState;
int prevMinutesState;

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
  
  pinMode(controlPin, INPUT);
  pinMode(hoursPin, INPUT);
  pinMode(minutesPin, INPUT);
  
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
  
  
  
  lcd.setCursor(4, 0);
  if(hours / 10 == 0)
  {
    lcd.print(0);
    lcd.print(hours);
  }
  else
    lcd.print(hours);
  lcd.print(":");
  if (minutes / 10 == 0)
  {
    lcd.print(0);
    lcd.print(minutes);
  }
  else
    lcd.print(minutes);
  lcd.print(":");
  if (seconds / 10 == 0)
  {
    lcd.print(0);
    lcd.print(seconds);
  }
  else
    lcd.print(seconds);
  
  lcd.setCursor(4,1);
  lcd.print(temp);
  lcd.print(" ");
  lcd.write(byte(0));
  lcd.print("C");
  

 
 
}
