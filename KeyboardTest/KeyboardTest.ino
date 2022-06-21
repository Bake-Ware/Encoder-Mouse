#include "PluggableUSBHID.h"
#include "USBKeyboard.h"
//
USBKeyboard Keyboard;

#define SW1 9

int millsThreshold = 25;
unsigned long lastButtonPress1 = 0;
int lastButtonState1;


void setup() {
  // put your setup code here, to run once:
  pinMode(SW1, INPUT_PULLUP);
  lastButtonState1 = digitalRead(SW1);

}

void loop() {
    int btnState1 = digitalRead(SW1);
  if (btnState1 != lastButtonState1) {
    if (millis() - lastButtonPress1 > millsThreshold) {
      if(btnState1 == LOW) 
{ Keyboard.printf("Hello world\n\r"); }  
      Serial.write("1");
      lastButtonState1 = btnState1;
    }
    lastButtonPress1 = millis();
  }
}
