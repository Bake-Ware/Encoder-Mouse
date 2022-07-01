import board
import json
import digitalio
class Button:
  def __init__(self,button_pin,buttonName,actions):
    self.name = buttonName
    self.actions = actions
    self.io = digitalio.DigitalInOut(button_pin)
    self.io.switch_to_input(pull=digitalio.Pull.UP)
    self.last = self.io.value
    self.value = self.io.value
    self.ispressed = 0
    print(self.name)
  def pressed(self):
      return not self.io.value
  def val(self):
      return self.io.value
  def changed(self):
    haschanged = self.val() != self.last
    #print(haschanged)
    if haschanged:
        self.last = self.val()
    return haschanged
class Config:
  def __init__(self, file):
    self.file = file

    # read in config values
    cfgFs = open(self.file,"r")
    cfgJson = cfgFs.read()
    print(cfgJson)
    cfg = json.loads(cfgJson)

    self.Encoder1Pin1 = getattr(board,"GP"+str(cfg["Pins"]["Encoder1"]["Pin1"]))
    self.Encoder1Pin2 = getattr(board,"GP"+str(cfg["Pins"]["Encoder1"]["Pin2"]))
    self.Encoder2Pin1 = getattr(board,"GP"+str(cfg["Pins"]["Encoder2"]["Pin1"]))
    self.Encoder2Pin2 = getattr(board,"GP"+str(cfg["Pins"]["Encoder2"]["Pin2"]))
    self.Button1Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin1"]))
    self.Button2Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin2"]))
    self.Button3Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin3"]))
    self.Button4Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin4"]))
    self.Button5Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin5"]))
    self.Button6Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin6"]))
    self.Button7Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin7"]))
    self.Button8Pin = getattr(board,"GP"+str(cfg["Pins"]["Buttons"]["Pin8"]))
    self.Slowmo = cfg["Pins"]["Slowmo"]
 #button array
    self.Buttons = []
    self.Buttons.append(Button(self.Button1Pin,"Button 1",cfg["Actions"]["Button1"]))
    self.Buttons.append(Button(self.Button2Pin,"Button 2",cfg["Actions"]["Button2"]))
    self.Buttons.append(Button(self.Button3Pin,"Button 3",cfg["Actions"]["Button3"]))
    self.Buttons.append(Button(self.Button4Pin,"Button 4",cfg["Actions"]["Button4"]))
    self.Buttons.append(Button(self.Button5Pin,"Button 5",cfg["Actions"]["Button5"]))
    self.Buttons.append(Button(self.Button6Pin,"Button 6",cfg["Actions"]["Button6"]))
    self.Buttons.append(Button(self.Button7Pin,"Button 7",cfg["Actions"]["Button7"]))
    self.Buttons.append(Button(self.Button8Pin,"Button 8",cfg["Actions"]["Button8"]))
    