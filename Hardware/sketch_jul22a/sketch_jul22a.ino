#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const int tempPin = A4;
const int controlPin = 6;
const int hoursPin = 7;
const int minutesPin = 8;
const int greenLed = 9;
const int yellowLed = 10;
const int piezo = A2;
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
unsigned long presentKnockTime;
unsigned long lastKnockTime = 0;
int currentControlState;
int currentHoursState;
int currentMinutesState;
int prevHoursState;
int prevMinutesState;
int action;
boolean turnYellowLedOff = false;
boolean greenLedIsHigh = false;
boolean doSomething = false;
const int quiteKnock = 6;
const int loudKnock = 1000;
int numberOfKnocks = 0;
int knockInterval = 600;

byte inputByte_0;

byte inputByte_1;

byte inputByte_2;

byte inputByte_3;

byte inputByte_4;

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
  
  currentControlState = digitalRead(controlPin);
  currentHoursState = digitalRead(hoursPin);
  currentMinutesState = digitalRead(minutesPin);
  
  
  
  if (currentHoursState != prevHoursState)
  {
    if(currentHoursState == HIGH && currentControlState == HIGH)
      hours++;
    
    prevHoursState = currentHoursState; 

  }
  
  if (currentMinutesState != prevMinutesState)
  {
    if (currentMinutesState == HIGH && currentControlState == HIGH)
    {
      minutes++;
      seconds = 0;
    }
    prevMinutesState = currentMinutesState;
  }
  if(currentControlState == LOW && currentHoursState == HIGH && currentMinutesState == HIGH)  //Let the PC detect the serial port
  {
    if (Serial.available() == 5) 
  {
    //Read buffer
    inputByte_0 = Serial.read();
    delay(100);    
    inputByte_1 = Serial.read();
    delay(100);      
    inputByte_2 = Serial.read();
    delay(100);      
    inputByte_3 = Serial.read();
    delay(100);
    inputByte_4 = Serial.read();   
  }
    if(inputByte_0 == 16)
  {       
       //Detect Command type
       if (inputByte_1 == 128) 
       {
          Serial.write("Hello budie!");
            
        } 
        //Clear Message bytes
        inputByte_0 = 0;
        inputByte_1 = 0;
        inputByte_2 = 0;
        inputByte_3 = 0;
        inputByte_4 = 0;
  }
knocks(analogRead(piezo));
  digitalWrite(greenLed, HIGH);
  digitalWrite(yellowLed, HIGH);

if (currentTime - presentKnockTime > knockInterval && numberOfKnocks == 2 && doSomething)
{
  //Serial.println("play");
  doSomething = false;
  digitalWrite(greenLed, HIGH);
  greenLedIsHigh = true;
  action = 1;
  Serial.write(action);
}
else if (currentTime - presentKnockTime > knockInterval && numberOfKnocks == 3 && doSomething)
{
  //Serial.println("forward");
  doSomething = false;
  digitalWrite(greenLed, HIGH);
  greenLedIsHigh = true;
  action = 2;
  Serial.write(action);
}
else if (currentTime - presentKnockTime > knockInterval && numberOfKnocks == 4 && doSomething)
{
  //Serial.println("backward");
  doSomething = false;
  digitalWrite(greenLed, HIGH);
  greenLedIsHigh = true;
  action = 3;
  Serial.write(action);
}


if (greenLedIsHigh && currentTime - presentKnockTime > knockInterval + 500)
{
  digitalWrite(greenLed, LOW);
  greenLedIsHigh = false; 
}
  
  if (currentTime - presentKnockTime > 30 && turnYellowLedOff == true)
  {
      digitalWrite(yellowLed, LOW);
      turnYellowLedOff = false;
  }
    
  }
}



void knocks(int value) {
  if (value > quiteKnock && value < loudKnock){
    digitalWrite(yellowLed, HIGH);
    lastKnockTime = presentKnockTime;
    presentKnockTime = currentTime;
    turnYellowLedOff = true;
    if (presentKnockTime - lastKnockTime < knockInterval)
      {
        numberOfKnocks++;
        doSomething = true;
        //Serial.println(numberOfKnocks);
      }
    else
      numberOfKnocks = 1;
     delay(50);
  }
}
