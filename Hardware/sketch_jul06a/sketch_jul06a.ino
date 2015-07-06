int rightChannel;
int leftChannel;


void setup() {
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  Serial.begin(9600);

}

void loop() {
  rightChannel = analogRead(A0);
  leftChannel = analogRead(A1);
  Serial.println((rightChannel + leftChannel) / 2);
}
