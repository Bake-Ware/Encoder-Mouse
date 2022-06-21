#include "PluggableUSBHID.h"
#include "USBKeyboard.h"
#include "stdlib.h"
#include "hardware/gpio.h"

USBKeyboard Keyboard;

#define CLK 2
#define DT 3

#define SW1 5
#define SW2 6
#define SW3 7
#define SW4 8
#define SW5 9
#define SW6 4

int currentStateCLK;
int lastStateCLK;
String currentDir ="";

unsigned long lastButtonPress1 = 0;
unsigned long lastButtonPress2 = 0;
unsigned long lastButtonPress3 = 0;
unsigned long lastButtonPress4 = 0;
unsigned long lastButtonPress5 = 0;
unsigned long lastButtonPress6 = 0;
unsigned long lastMoveTime = 0;
int millsThreshold = 25;
int lastButtonState1;
int lastButtonState2;
int lastButtonState3;
int lastButtonState4;
int lastButtonState5;
int lastButtonState6;
  
void setup() {
  digitalWrite(LED_BUILTIN, HIGH);
  // Set encoder pins as inputs
  pinMode(CLK,INPUT);
  pinMode(DT,INPUT);
  
  //setup keys
  pinMode(SW1, INPUT_PULLUP);
  pinMode(SW2, INPUT_PULLUP);
  pinMode(SW3, INPUT_PULLUP);
  pinMode(SW4, INPUT_PULLUP);
  pinMode(SW5, INPUT_PULLUP);
  pinMode(SW6, INPUT_PULLUP);

  Serial.begin(9600);

  // Read the initial state of CLK
  lastStateCLK = digitalRead(CLK);

  lastButtonState1 = digitalRead(SW1);
  lastButtonState2 = digitalRead(SW2);
  lastButtonState3 = digitalRead(SW3);
  lastButtonState4 = digitalRead(SW4);
  lastButtonState5 = digitalRead(SW5);
  lastButtonState6 = digitalRead(SW6);
}

void SendMachine(int machine)
{
  Keyboard.send(207);
  Keyboard.send(207);
  Keyboard.send(340+machine);
  Keyboard.send(340);
}

void loop() {
  delay(1);
  currentStateCLK = digitalRead(CLK); 
  lastStateCLK = currentStateCLK;

  int btnState1 = digitalRead(SW1);
  int btnState2 = digitalRead(SW2);
  int btnState3 = digitalRead(SW3);
  int btnState4 = digitalRead(SW4);
  int btnState5 = digitalRead(SW5);
  int btnState6 = digitalRead(SW6);
/*
220 '\334' Keypad / 
221 '\335' Keypad * 
222 '\336' Keypad - 
223 '\337' Keypad + 
224 '\340' Keypad ENTER 
225 '\341' Keypad 1 and End 
226 '\342' Keypad 2 and Down Arrow 
227 '\343' Keypad 3 and PageDn 
228 '\344' Keypad 4 and Left Arrow 
229 '\345' Keypad 5 
230 '\346' Keypad 6 and Right Arrow 
231 '\347' Keypad 7 and Home 
232 '\350' Keypad 8 and Up Arrow 
233 '\351' Keypad 9 and PageUp 
234 '\352' Keypad 0 and Insert 
235 '\353' Keypad . and Delete
*/
  if (currentStateCLK != lastStateCLK){
    Serial.println("changed");
    if(digitalRead(DT) != currentStateCLK) { 
        Serial.println("left");
      }
    else { 
      Serial.println("right");
      }
  }
  if (btnState1 != lastButtonState1) {
    if (millis() - lastButtonPress1 > millsThreshold) {
     if(btnState1 == 0)
     {
        Serial.println("1");
        SendMachine(4);
     }
     lastButtonState1 = btnState1;
    }
    lastButtonPress1 = millis();
  }
  if (btnState2 != lastButtonState2) {
    if (millis() - lastButtonPress2 > millsThreshold) {
     if(btnState2 == 0)
     {
      Serial.println("2");
      SendMachine(3);
     }
     lastButtonState2 = btnState2;
    }
    lastButtonPress2 = millis();
  }
  if (btnState3 != lastButtonState3) {
    if (millis() - lastButtonPress3 > millsThreshold) {
      if(btnState3 == 0)
      {
        Serial.println("3");
        SendMachine(2);
      }
      lastButtonState3 = btnState3;
    }
    lastButtonPress3 = millis();
  }
  if (btnState4 != lastButtonState4) {
    if (millis() - lastButtonPress4 > millsThreshold) {
      if(btnState4 == 0)
      {
        Serial.println("4");
        SendMachine(1);
      }
      lastButtonState4 = btnState4;
    }
    lastButtonPress4 = millis();
  }
  if (btnState5 != lastButtonState5) {
    if (millis() - lastButtonPress5 > millsThreshold) {
      if(btnState5 == 0)
      {
        Serial.println("5");
      }
      lastButtonState5 = btnState5;
    }
    lastButtonPress5 = millis();
  }
  if (btnState6 != lastButtonState6) {
    if (millis() - lastButtonPress6 > millsThreshold) {
      if(btnState6 == 0)
      {
        Serial.println("6");
        Keyboard.send("0x7F");
      }
      lastButtonState6 = btnState6;
    }
    lastButtonPress6 = millis();
  }
}
