#include <FastLED.h>

#define DATA_PIN 6
#define LED_TYPE TM1803
#define COLOR_ORDER GBR
#define NUM_LEDS 10
CRGB leds[NUM_LEDS];
#define BRIGHTNESS 50

// A string to hold incoming Serial Data
String inString;
int ledNumber = 10;

void setup() {

	// 3 second delay for recovery
	delay(3000);

	// LED Strip Init
	FastLED.addLeds<LED_TYPE, DATA_PIN, COLOR_ORDER>(leds, NUM_LEDS);

	// Set Brightness
	FastLED.setBrightness(BRIGHTNESS);

	// Start Serial
	Serial.begin(9600);

	// for (int i = 0; i < )

}


void loop() {

	if (Serial.available() > 0) {
		int hpLvl = Serial.parseInt();

		for (int i = 0; i < ledNumber; i++) {
			if (i < hpLvl) {
				leds[i] = CRGB::Green;
			}
			else {
				leds[i] = CRGB::Black;
			}
		}
	}

	/*
	// Read serial input:
	while (Serial.available() > 0) {
		int inChar = Serial.read();
		if (isDigit(inChar)) {
			// convert the incoming byte to a char and add it to the string:
			inString += (char)inChar;
			inString.trim();
		}
		// if you get a newline, print the string, then the string's value:
		if (inChar == '>') {
			// Set amount of LEDS to light up based on number
			for (int i = 0; i < ledNumber; i++) {
				if (i < inString.toInt()) {
					leds[i] = CRGB(255, 0, 0);
				}else if (i >= inString.toInt()){
					leds[i] = CRGB(0, 0, 0);
				}
				
			}
		}
	}
	*/
	FastLED.show();
	delay(500);
}

