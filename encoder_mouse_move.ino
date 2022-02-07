
#include "PluggableUSBHID.h"
//#include "USBKeyboard.h"
#include "USBMouse.h"
#include "stdlib.h"
#include "hardware/gpio.h"
USBMouse Mouse;
//USBKeyboard Keyboard;
// Rotary Encoder Inputs
#define CLK 2
#define DT 3

#define CLK2 7
#define DT2 8

//switches
#define SW1 4
#define SW2 9
#define SW3 5
#define SW4 13
#define SW5 14
#define SW6 15
#define SW7 10
#define SW8 11

int counter = 0;
int currentStateCLK;
int lastStateCLK;
String currentDir ="";

bool isClicked = false;
bool scrollMode = false;
bool slowMo = true;

int counter2 = 0;
int currentStateCLK2;
int lastStateCLK2;
String currentDir2 ="";


int counterS = 1;
int counterF = 3;
int currentStateCLKS;
int lastStateCLKS;
String currentDirS ="";

unsigned long lastButtonPress1 = 0;
unsigned long lastButtonPress2 = 0;
unsigned long lastButtonPress3 = 0;
unsigned long lastButtonPress4 = 0;
unsigned long lastButtonPress5 = 0;
unsigned long lastButtonPress6 = 0;
unsigned long lastButtonPress7 = 0;
unsigned long lastButtonPress8 = 0;

int lastButtonState1;
int lastButtonState2;
int lastButtonState3;
int lastButtonState4;
int lastButtonState5;
int lastButtonState6;
int lastButtonState7;
int lastButtonState8;

int scrollCounter = 0;

int xCount = 0;
int yCount = 0;

void setup() {
  digitalWrite(LED_BUILTIN, HIGH);
  // Set encoder pins as inputs
  pinMode(CLK,INPUT);
  pinMode(DT,INPUT);
  //attachInterrupt(digitalPinToInterrupt(CLK), updateX, RISING);

  //gpio_set_irq_enabled_with_callback(CLK, GPIO_IRQ_EDGE_RISE | GPIO_IRQ_EDGE_FALL, true, &updateX);
  

  pinMode(CLK2,INPUT);
  pinMode(DT2,INPUT);
  
  //setup keys
  pinMode(SW1, INPUT_PULLUP);
  pinMode(SW2, INPUT_PULLUP);
  pinMode(SW3, INPUT_PULLUP);
  pinMode(SW4, INPUT_PULLUP);
  pinMode(SW5, INPUT_PULLUP);
  pinMode(SW6, INPUT_PULLUP);
  pinMode(SW7, INPUT_PULLUP);
  pinMode(SW8, INPUT_PULLUP);

//  irq_set_exclusive_handler(CLK, updateX);
//  irq_set_enabled(CLK, true);
//  irq_set_exclusive_handler(CLK2, updateY);
//  irq_set_enabled(CLK2, true);
  // Setup Serial Monitor
  Serial.begin(9600);

  // Read the initial state of CLK
  lastStateCLK = digitalRead(CLK);
  lastStateCLK2 = digitalRead(CLK2);

  lastButtonState1 = digitalRead(SW1);
  lastButtonState2 = digitalRead(SW2);
  lastButtonState3 = digitalRead(SW3);
  lastButtonState4 = digitalRead(SW4);
  lastButtonState5 = digitalRead(SW5);
  lastButtonState6 = digitalRead(SW6);
  lastButtonState7 = digitalRead(SW7);
  lastButtonState8 = digitalRead(SW8);
}

int getCursorSpeed()
{
  return slowMo ? counterS : counterF;
}

void doScroll(int pos)
{
  scrollCounter += pos;
  if(scrollCounter == 15)  
  {
    Mouse.scroll(1);  
    scrollCounter = 0;
  }
  if(scrollCounter == -15)  
  {
    Mouse.scroll(-1);  
    scrollCounter = 0;
  }
}

void updateY() {
  if ((currentStateCLK2 != lastStateCLK2  && currentStateCLK2 == 1))
  {
    if (digitalRead(DT2) != currentStateCLK2) {
      if(scrollMode)
      {
        doScroll(1);
      } else {
        Mouse.move(0,getCursorSpeed());
      }
    } else {
      if(scrollMode)
      {
        doScroll(-1);
      } else {
        Mouse.move(0,0-getCursorSpeed());
      }
    }
  }
}
//void updateX(uint gpio, uint32_t events) {
void updateX() {
  if (currentStateCLK != lastStateCLK  && currentStateCLK == 1){
    (digitalRead(DT) != currentStateCLK) ? Mouse.move(getCursorSpeed(),0) : Mouse.move(0-getCursorSpeed(),0);
  }
}

void loop() {
  
  currentStateCLK = digitalRead(CLK); 
  currentStateCLK2 = digitalRead(CLK2); 
  updateX();
  updateY();
  lastStateCLK = currentStateCLK;
  lastStateCLK2 = currentStateCLK2;


  // Read the button state
  int btnState1 = digitalRead(SW1);
  int btnState2 = digitalRead(SW2);
  int btnState3 = digitalRead(SW3);
  int btnState4 = digitalRead(SW4);
  int btnState5 = digitalRead(SW5);
  int btnState6 = digitalRead(SW6);
  int btnState7 = digitalRead(SW7);
  int btnState8 = digitalRead(SW8);

  //If we detect LOW signal, button is pressed
  
  if (btnState1 != lastButtonState1) {
    if (millis() - lastButtonPress1 > 50) {
      btnState1 == LOW ? Mouse.press(MOUSE_MIDDLE) : Mouse.release(MOUSE_MIDDLE);  
      Serial.write("1");
      lastButtonState1 = btnState1;
    }
    lastButtonPress1 = millis();
  }
  if (btnState2 != lastButtonState2) {
    if (millis() - lastButtonPress2 > 50) {
      scrollMode = btnState2 == LOW;  
      Serial.write("2");
      lastButtonState2 = btnState2;
    }
    lastButtonPress2 = millis();
  }
  if (btnState3 != lastButtonState3) {
    if (millis() - lastButtonPress3 > 50) {
      slowMo = btnState3 != LOW;
      Serial.write("3");
      lastButtonState3 = btnState3;
    }
    lastButtonPress3 = millis();
  }
  if (btnState4 != lastButtonState4) {
    if (millis() - lastButtonPress4 > 50) {
      slowMo = btnState4 != LOW;
      Serial.write("4");
      lastButtonState4 = btnState4;
    }
    lastButtonPress4 = millis();
  }
  if (btnState5 != lastButtonState5) {
    if (millis() - lastButtonPress5 > 50) {
      slowMo = btnState5 != LOW;
      Serial.write("5");
      lastButtonState5 = btnState5;
    }
    lastButtonPress5 = millis();
  }
  if (btnState6 != lastButtonState6) {
    if (millis() - lastButtonPress6 > 50) {
      btnState6 == LOW ? Mouse.press(MOUSE_RIGHT) : Mouse.release(MOUSE_RIGHT);  
      Serial.write("6");
      lastButtonState6 = btnState6;
    }
    lastButtonPress6 = millis();
  }
  if (btnState7 != lastButtonState7) {
    if (millis() - lastButtonPress7 > 50) {
      btnState7 == LOW ? Mouse.press(MOUSE_LEFT) : Mouse.release(MOUSE_LEFT);  
      Serial.write("7");
      lastButtonState7 = btnState7;
    }
    lastButtonPress7 = millis();
  }
  if (btnState8 != lastButtonState8) {
    if (millis() - lastButtonPress8 > 50) {
      slowMo = btnState8 != LOW;
      Serial.write("8");
      lastButtonState8 = btnState8;
    }
    lastButtonPress8 = millis();
  }
  // Put in a slight delay to help debounce the reading
  //delay(5);
}
