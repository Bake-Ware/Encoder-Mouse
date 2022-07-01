# SPDX-FileCopyrightText: 2021 Tim C for Adafruit Industries
# SPDX-License-Identifier: MIT
import sys
import os
import microcontroller
import time
import storage
import usb_hid
from adafruit_hid.consumer_control import ConsumerControl
from adafruit_hid.consumer_control_code import ConsumerControlCode
from adafruit_hid.keyboard import Keyboard
from adafruit_hid.keyboard_layout_us import KeyboardLayoutUS
from adafruit_hid.keycode import Keycode
from adafruit_hid.mouse import Mouse
import rotaryio
import busio
import displayio
import terminalio
import adafruit_ssd1306
from adafruit_display_text import label
import adafruit_framebuf
import json
from test import *
from load_config import *
#i2c = busio.I2C (scl=board.GP1, sda=board.GP0) # This RPi Pico way to call I2C<br> 

cc = ConsumerControl(usb_hid.devices)
kb = Keyboard(usb_hid.devices)
m = Mouse(usb_hid.devices)

# read in config values
cfg = Config("config.json")

encoder1 = rotaryio.IncrementalEncoder(cfg.Encoder1Pin1, cfg.Encoder1Pin2,1)
encoder2 = rotaryio.IncrementalEncoder(cfg.Encoder2Pin1, cfg.Encoder2Pin2,1)

last_position1 = encoder1.position
last_position2 = encoder2.position
scrollMode = 0
slowmo = cfg.Slowmo
volmode = 0
arrowMode = 0
x = 0
y = 0
#display = adafruit_ssd1306.SSD1306_I2C(128,64,i2c)

#display.fill(1)
#display.text("SWIGGITY SWOOTY",22,28,0)
#display.show()

#PrintSysInfo()
Layer = 1
def SetLayer(value):
    print("Layer = "+str(value))
    Layer = value
def Act(actions):
    print(actions)
    exec(actions)
    #eval(actions,{"cc":cc,"kb":kb,"m":m,"Layer":Layer,"ConsumerControlCode":ConsumerControlCode,"Keycode":Keycode,"Mouse":Mouse})
    #time.sleep(0.01)
while True:
    for btn in cfg.Buttons:
        #button logic
        action = btn.actions["Layer"+str(Layer)]
        thisAction = ""
        if btn.pressed():
            thisAction = str(action["Down"])
            btn.isPressed = 1
        else:
            thisAction = str(action["Up"])
            btn.isPressed = 0
        if not btn.pressed() and btn.isPressed: #release hung buttons
            print("unfucked")
            thisAction = str(action["Up"])
            btn.isPressed = 0
            Act(thisAction)
        if btn.changed():
            Act(thisAction)
    #scrollMode = 1 if Layer == 2 else 0
    #volmode = 1 if Layer == 3 else 0
    #arrowMode = 1 if Layer == 4 else 0
    position1 = encoder1.position
    position2 = encoder2.position
    x = 0
    y = 0
    if position1 != last_position1:
        position_change1 = position1 - last_position1
        if slowmo:
            y= round(position_change1/2)
        else:
            y = position_change1
    last_position1 = position1

    if position2 != last_position2:
        position_change2 = position2 - last_position2
        if slowmo:
            x= round(position_change2/2)
        else:
            x = position_change2
    last_position2 = position2
    if x != 0 or y != 0:
        if Layer == 3:
            if y < -5:
                cc.send(ConsumerControlCode.VOLUME_INCREMENT)
            if y > 5:
                cc.send(ConsumerControlCode.VOLUME_DECREMENT)
            if x < 0:
                cc.send(ConsumerControlCode.REWIND)
            if x > 0:
                cc.send(ConsumerControlCode.FAST_FORWARD)
        elif Layer == 4:
            if y < 0:
                kb.send(Keycode.UP_ARROW)
            if y > 0:
                kb.send(Keycode.DOWN_ARROW)
            if x < 0:
                kb.send(Keycode.LEFT_ARROW)
            if x > 0:
                kb.send(Keycode.RIGHT_ARROW)
        elif Layer == 2:
            if y != 0:
                y=round(y/10) if y > 10 or y < -10 else 1 if y > 0 else -1
                sy = y
                if y>0:
                    m.move(0,0,sy*-1)
                elif y<0:
                    m.move(0,0,sy*-1)
            if x != 0:
                kb.press(Keycode.LEFT_SHIFT)
                sx = round(x/10)*-1 if x>10 else round(x/5)*-1
                m.move(0,0,sx)
                kb.release(Keycode.LEFT_SHIFT)
            time.sleep(0.05)
        else:
            m.move(x,y)
        text = f"x: {x} y: {y}"
        print(text)
        #display.fill(1)
        #display.text(text,32,25,0)
        #display.show()

#end of main loop
