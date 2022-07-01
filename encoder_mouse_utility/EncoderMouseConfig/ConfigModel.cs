using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoderMouseConfig
{
    public partial class Form1
    {
            //this.cbL1Button1.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL1Button2.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL1Button3.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL1Button4.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL1Button5.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL1Button6.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL1Button7.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL1Button8.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button1.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button2.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button3.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button4.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button5.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button6.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button7.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL2Button8.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button1.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button2.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button3.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button4.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button5.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button6.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button7.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL3Button8.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button1.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button2.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button3.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button4.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button8.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button5.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button6.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button7.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL4Button8.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button1.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button2.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button3.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button4.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button8.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button5.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button6.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button7.DataSource = new BindingSource(ActionsBindings, null);
            //this.cbL5Button8.DataSource = new BindingSource(ActionsBindings, null);
        public static Dictionary<string, ActionsModel.ButtonModel.UpDownModel> ActionsBindings = new Dictionary<string, ActionsModel.ButtonModel.UpDownModel>
            {
              {"Nothing", new ActionsModel.ButtonModel.UpDownModel(0){Down = "", Up = "Layer = 1" }},
              {"--- Mouse ---", new ActionsModel.ButtonModel.UpDownModel(1){Down = "", Up = "Layer = 1" } },
              {"Left Click", new ActionsModel.ButtonModel.UpDownModel(2){Down = "m.press(Mouse.LEFT_BUTTON)", Up = "m.release(Mouse.LEFT_BUTTON)" } },
              {"Right Click", new ActionsModel.ButtonModel.UpDownModel(3){Down = "m.press(Mouse.RIGHT_BUTTON)", Up = "m.release(Mouse.RIGHT_BUTTON)" } },
              {"Middle Click", new ActionsModel.ButtonModel.UpDownModel(4){Down = "m.press(Mouse.MIDDLE_BUTTON)", Up = "m.release(Mouse.MIDDLE_BUTTON)" } },
              {"Browser Back", new ActionsModel.ButtonModel.UpDownModel(5){Down = "cc.send(0x0224)", Up = "" } },
              {"Browser Forward", new ActionsModel.ButtonModel.UpDownModel(6){Down = "cc.send(0x0225)", Up = "" } },
              {"--- Layers ---", new ActionsModel.ButtonModel.UpDownModel(7){Down = "", Up = "Layer = 1" } },
              {"Layer 1", new ActionsModel.ButtonModel.UpDownModel(8){Down = "Layer = 1", Up = "Layer = 1" } },
              {"Layer 2", new ActionsModel.ButtonModel.UpDownModel(9){Down = "Layer = 2", Up = "Layer = 1" } },
              {"Layer 3", new ActionsModel.ButtonModel.UpDownModel(10){Down = "Layer = 3", Up = "Layer = 1" } },
              {"Layer 4", new ActionsModel.ButtonModel.UpDownModel(11){Down = "Layer = 4", Up = "Layer = 1" } },
              {"Layer 5", new ActionsModel.ButtonModel.UpDownModel(12){Down = "Layer = 5", Up = "Layer = 1" } },
              {"--- Clipboard ---", new ActionsModel.ButtonModel.UpDownModel(13){Down = "", Up = "Layer = 1" } },
              {"Copy", new ActionsModel.ButtonModel.UpDownModel(14){Down = "kb.send(Keycode.CONTROL,Keycode.C)", Up = "" } },
              {"Paste", new ActionsModel.ButtonModel.UpDownModel(15){Down = "kb.send(Keycode.CONTROL,Keycode.V)", Up = "" } },
              {"--- Arrow Keys ---", new ActionsModel.ButtonModel.UpDownModel(16){Down = "", Up = "Layer = 1" } },
              {"Arrow Up", new ActionsModel.ButtonModel.UpDownModel   (17){Down = "kb.press(Keycode.UP_ARROW)", Up = "kb.release(Keycode.UP_ARROW)" } },
              {"Arrow Down", new ActionsModel.ButtonModel.UpDownModel (18){Down = "kb.press(Keycode.DOWN_ARROW)", Up = "kb.release(Keycode.DOWN_ARROW)" } },
              {"Arrow Left", new ActionsModel.ButtonModel.UpDownModel (19){Down = "kb.press(Keycode.LEFT_ARROW)", Up = "kb.release(Keycode.LEFT_ARROW)" } },
              {"Arrow Right", new ActionsModel.ButtonModel.UpDownModel(20){Down = "kb.press(Keycode.RIGHT_ARROW)", Up = "kb.release(Keycode.RIGHT_ARROW)" } },
              //media controls
              {"--- Media ---", new ActionsModel.ButtonModel.UpDownModel(21){Down = "", Up = "Layer = 1" } },
              {"Mute", new ActionsModel.ButtonModel.UpDownModel(22){Down = "cc.send(ConsumerControlCode.MUTE)", Up = "" } },
              {"Play/Pause", new ActionsModel.ButtonModel.UpDownModel(23){Down = "cc.send(ConsumerControlCode.PLAY_PAUSE)", Up = "" } },
              {"Next Track", new ActionsModel.ButtonModel.UpDownModel(24){Down = "cc.send(ConsumerControlCode.SCAN_NEXT_TRACK)", Up = "" } },
              {"Prev Track", new ActionsModel.ButtonModel.UpDownModel(25){Down = "cc.send(ConsumerControlCode.SCAN_PREVIOUS_TRACK)", Up = "" } },
              {"Volume Up", new ActionsModel.ButtonModel.UpDownModel  (26){Down = "cc.send(ConsumerControlCode.VOLUME_INCREMENT)", Up = "" } },
              {"Volume Down", new ActionsModel.ButtonModel.UpDownModel(27){Down = "cc.send(ConsumerControlCode.VOLUME_DECREMENT)", Up = "" } },
              {"Scrub Forward", new ActionsModel.ButtonModel.UpDownModel(28){Down = "cc.send(ConsumerControlCode.REWIND)", Up = "" } },
              {"Scrub Back", new ActionsModel.ButtonModel.UpDownModel   (29){Down = "cc.send(ConsumerControlCode.FAST_FORWARD)", Up = "" } },
              {"--- Window Navigation ---", new ActionsModel.ButtonModel.UpDownModel(30){Down = "", Up = "Layer = 1" } },
              {"Alt-Tab", new ActionsModel.ButtonModel.UpDownModel(31){Down = "kb.send(Keycode.ALT,Keycode.TAB)", Up = "" } },
              {"Snap Left", new ActionsModel.ButtonModel.UpDownModel(32){Down = "kb.send(Keycode.GUI,Keycode.LEFT_ARROW)", Up = "" } },
              {"Snap Right", new ActionsModel.ButtonModel.UpDownModel(33){Down = "kb.send(Keycode.GUI,Keycode.RIGHT_ARROW)", Up = "" } },
              {"Maximize", new ActionsModel.ButtonModel.UpDownModel(34){Down = "kb.send(Keycode.GUI,Keycode.UP_ARROW)", Up = "" } },
              {"Minimize", new ActionsModel.ButtonModel.UpDownModel(35){Down = "kb.send(Keycode.GUI,Keycode.DOWN_ARROW)", Up = "" } },
              {"--- Utility ---", new ActionsModel.ButtonModel.UpDownModel(36){Down = "", Up = "Layer = 1" } },
              {"Reset Microcontroler", new ActionsModel.ButtonModel.UpDownModel(37){Down = "microcontroller.reset()", Up = "" } },
            };
    }
    public class ConfigModel
    {
        public PinsModel Pins { get; set; }
        public ActionsModel Actions { get; set; }
    }

    public class ActionsModel
    {
        public ButtonModel Button1 { get; set; }
        public ButtonModel Button2 { get; set; }
        public ButtonModel Button3 { get; set; }
        public ButtonModel Button4 { get; set; }
        public ButtonModel Button5 { get; set; }
        public ButtonModel Button6 { get; set; }
        public ButtonModel Button7 { get; set; }
        public ButtonModel Button8 { get; set; }
        public class ButtonModel
        {
            public UpDownModel Layer1 { get; set; }
            public UpDownModel Layer2 { get; set; }
            public UpDownModel Layer3 { get; set; }
            public UpDownModel Layer4 { get; set; }
            public UpDownModel Layer5 { get; set; }
            public class UpDownModel
            {
                public UpDownModel() { }
                public UpDownModel(int index)
                {
                    Index = index;
                }
                public int Index { get; set; }
                public string Up { get; set; }
                public string Down { get; set; }
            }
        }
    }
    public class PinsModel
    {
        public EncoderPins Encoder1 { get; set; }
        public EncoderPins Encoder2 { get; set; }
        public ButtonPins Buttons { get; set; }
        public int Slowmo { get; set; }
        public class EncoderPins
        {
            public int Pin1 { get; set; }
            public int Pin2 { get; set; }

        }
        public class ButtonPins
        { 
            public int Pin1 { get; set; }
            public int Pin2 { get; set; }
            public int Pin3 { get; set; }
            public int Pin4 { get; set; }
            public int Pin5 { get; set; }
            public int Pin6 { get; set; }
            public int Pin7 { get; set; }
            public int Pin8 { get; set; }

        }
    }
}
