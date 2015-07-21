#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const int switchPin = 6;
const int greenLed = 7;
const int yellowLed = 8;
const int lampPin = 9;
const int servoPin = 10;
const int lightPin = A3;
const int tempPin = A4;
const int piezo = A2;
const int quiteKnock = 6;
const int loudKnock = 1000;
const int lightThreshold = 250;
int numberOfKnocks = 0;
int knockInterval = 600;
int switchState = 0;
int prevSwitchState = 0;
unsigned long previousTime = 0;
unsigned long currentTime = 0;
unsigned long buttonTime = 0;
unsigned long presentKnockTime = 0;
unsigned long lastKnockTime = 0;
unsigned long tempTime = 0;
int angle = 0;
int lightValue;
int scrollingSpeed = 300;
int gameSpeed = 200;
int gameStage = 1;   // 1 = welcome; 2 = gameover; 0 = play;
int score = 0;
int manPosition = 1;
int obstacleOnePosition = 10;
int obstacleTwoPosition = 16;
int turnYellowLedOff = 0;
String line1 = "Welcome to TimiX";
String line2 = "Press the button you have!!!";
String line3 = "To play again press the button!";
int stringStart, stringStop = 0;
int scrollCursor = 16;
boolean doSomething = false;
boolean isHigh = false;
boolean lampOn = false;
float temperature;
float tempArray[200];
float tempSum;
float temp;
int tempNumber = 200;
int counter = -1;
int tempUnits;
//int tempDecimal;
int action;


void setup()
{
  Serial.begin(9600);
  lcd.begin(16, 2);
  pinMode(switchPin, INPUT);
  pinMode(greenLed,  OUTPUT);
  pinMode(yellowLed, OUTPUT);
  pinMode(lampPin, OUTPUT);
  for (int i = 0; i < tempNumber; i++)
  {
    tempArray[i] = ((analogRead(tempPin)/1024.0)*5.0 - 0.5)*100;
    tempSum += tempArray[i];
  }
  temp = tempSum / tempNumber;
//  pinMode(8, OUTPUT);
//  
//  for (int i = 50; i <= 4000; i++)
//  {
//    tone(8, i, 50);
//    delay(50);
//  }
}
//do you see me?
void loop()
{
  switchState = digitalRead(switchPin);
  currentTime = millis();
  
  
  prevSwitchState = switchState;

  ////Temperature
 // float temperature = ((analogRead(tempPin) / 1024.0) * 5.0 - .5) * 100;
  temperature = ((analogRead(tempPin)/1024.0)*5.0 - 0.5)*100;
  if (counter > tempNumber - 1)
    counter = 0;
  else
    counter++;
   tempSum -= tempArray[counter];
   tempArray[counter] = temperature;
   tempSum += tempArray[counter];
   temp = tempSum / tempNumber;
   tempUnits = (int) temp;

  
  // Knocks
knocks(analogRead(piezo));

if (currentTime - presentKnockTime > knockInterval && numberOfKnocks == 2 && doSomething && gameStage != 0)
{
  //Serial.println("play");
  doSomething = false;
  digitalWrite(greenLed, HIGH);
  isHigh = true;
  action = 1;
  Serial.write(tempUnits);
  //Serial.write(tempDecimal);
  Serial.write(action);
  tempTime = currentTime;
}
else if (currentTime - presentKnockTime > knockInterval && numberOfKnocks == 3 && doSomething && gameStage != 0)
{
  //Serial.println("forward");
  doSomething = false;
  digitalWrite(greenLed, HIGH);
  isHigh = true;
  action = 2;
  Serial.write(tempUnits);
  //Serial.write(tempDecimal);
  Serial.write(action);
  tempTime = currentTime;
}
else if (currentTime - presentKnockTime > knockInterval && numberOfKnocks == 4 && doSomething && gameStage != 0)
{
  //Serial.println("backward");
  doSomething = false;
  digitalWrite(greenLed, HIGH);
  isHigh = true;
  action = 3;
  Serial.write(tempUnits);
  //Serial.write(tempDecimal);
  Serial.write(action);
  tempTime = currentTime;
}
else if (gameStage != 0 && currentTime - tempTime > 500)
{
  action = 0;
  Serial.write(tempUnits);
  //Serial.write(tempDecimal);
  Serial.write(action);
  tempTime = currentTime;
}


if (isHigh && currentTime - presentKnockTime > knockInterval + 500)
{
  digitalWrite(greenLed, LOW);
  isHigh = false; 
}
  
  if (currentTime - presentKnockTime > 30 && turnYellowLedOff == 1)
  {
      digitalWrite(yellowLed, LOW);
      turnYellowLedOff = 0;
  }
  
}

void knocks(int value) {
  if (value > quiteKnock && value < loudKnock && gameStage != 0){
    digitalWrite(yellowLed, HIGH);
    lastKnockTime = presentKnockTime;
    presentKnockTime = currentTime;
    turnYellowLedOff = 1;
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
