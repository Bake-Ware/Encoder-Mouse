# This example is for the MacroPad,
# or any board with buttons that are connected to ground when pressed.

import storage
import board, digitalio
import json
# read in config values
cfgFs = open("config.json","r")
cfgJson = cfgFs.read()
print(cfgJson)
cfg = json.loads(cfgJson)
Button1Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin1"]))
Button2Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin2"]))
Button3Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin3"]))
Button4Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin4"]))
Button5Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin5"]))
Button6Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin6"]))
Button7Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin7"]))
Button8Pin = getattr(board,"GP"+str(cfg["Buttons"]["Pin8"]))
button_1 = digitalio.DigitalInOut(Button1Pin)
button_1.switch_to_input(pull=digitalio.Pull.UP)
button_2 = digitalio.DigitalInOut(Button2Pin)
button_2.switch_to_input(pull=digitalio.Pull.UP)
button_3 = digitalio.DigitalInOut(Button3Pin)
button_3.switch_to_input(pull=digitalio.Pull.UP)
button_4 = digitalio.DigitalInOut(Button4Pin)
button_4.switch_to_input(pull=digitalio.Pull.UP)
button_5 = digitalio.DigitalInOut(Button5Pin)
button_5.switch_to_input(pull=digitalio.Pull.UP)
button_6 = digitalio.DigitalInOut(Button6Pin)
button_6.switch_to_input(pull=digitalio.Pull.UP)
button_7 = digitalio.DigitalInOut(Button7Pin)
button_7.switch_to_input(pull=digitalio.Pull.UP)
button_8 = digitalio.DigitalInOut(Button8Pin)
button_8.switch_to_input(pull=digitalio.Pull.UP)


if button_1.value and button_2.value and button_3.value and button_4.value and button_5.value and button_6.value and button_7.value and button_8.value:
    storage.disable_usb_drive()
else:
    storage.enable_usb_drive()

