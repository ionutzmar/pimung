#include "fix_fft.h"

const int colPins[] = {2, 3, 4, 5, 6, 7, 8, 9};  // LED matrix columns are assigned to digital pins
const int clockPin = 10;  // Connects to 4017 decade counter Clock pin 14
const int resetPin = 11;  // Connects to 4017 decade counter Reset pin 15
const int audioPin = A0;  // Left or right channel audio positive lead connects here
const int maxExpectedAudio = 20;  // Change this value to adjust the sensitivity

char data[128], im[128], data_avgs[8];  // FFT array variables
int i, j, x, y;

void setup() {
  // Enable pins we will be using
  for (int i = 0; i < 8; i++)
    pinMode(colPins[i], OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(resetPin, OUTPUT);
}

void loop() {
  // Build table of audio samples
  for (i = 0; i < 128; i++) {
    data[i] = analogRead(audioPin);
    im[i] = 0;
  }

  fix_fft(data, im, 7, 0);  // FFT processing

  for (i = 0; i < 64; i++)
    data[i] = sqrt(data[i] * data[i] + im[i] * im[i]); // Make values positive

  for (i = 0; i < 8; i++) {
    // Average values
    j = i << 3;
    data_avgs[i] = data[j] + data[j + 1] + data[j + 2] + data[j + 3]
      + data[j + 4] + data[j + 5] + data[j + 6] + data[j + 7];
    if (i == 0)
      data_avgs[i] >>= 1;  // KK: De-emphasize first audio band (too sensitive)
    data_avgs[i] = map(data_avgs[i], 0, maxExpectedAudio, 0, 7); // Map for output to 8x8 display
  }

  digitalWrite(resetPin, HIGH);  // Move to top row
  digitalWrite(resetPin, LOW);
  for (y = 0; y < 8; y++) {
    for (x = 0; x < data_avgs[y]; x++)
      digitalWrite(colPins[x], HIGH);  // Light appropriate column LEDs
    delayMicroseconds(500);  // Wait a bit, or else they'll be too dim
    for (x = 0; x < data_avgs[y]; x++)
      digitalWrite(colPins[x], LOW);  // Turn off LEDs that were previously lit
    digitalWrite(clockPin, HIGH);  // Move to next row and repeat for all eight rows
    digitalWrite(clockPin, LOW);
  }
}

