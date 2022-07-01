using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderMouseConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadSettings(object sender, EventArgs e)
        { 
            if (File.Exists("./config.json"))
            {
                var cfgRaw = File.ReadAllText("./config.json");
                var cfg = JsonSerializer.Deserialize<ConfigModel>(cfgRaw);
                numericEncoder1Pin1.Value = cfg.Pins.Encoder1.Pin1;
                numericEncoder1Pin2.Value = cfg.Pins.Encoder1.Pin2;
                numericEncoder2Pin1.Value = cfg.Pins.Encoder2.Pin1;
                numericEncoder2Pin2.Value = cfg.Pins.Encoder2.Pin2;
                
                numericButton1.Value = cfg.Pins.Buttons.Pin1;
                numericButton2.Value = cfg.Pins.Buttons.Pin2;
                numericButton3.Value = cfg.Pins.Buttons.Pin3;
                numericButton4.Value = cfg.Pins.Buttons.Pin4;
                numericButton5.Value = cfg.Pins.Buttons.Pin5;
                numericButton6.Value = cfg.Pins.Buttons.Pin6;
                numericButton7.Value = cfg.Pins.Buttons.Pin7;
                numericButton8.Value = cfg.Pins.Buttons.Pin8;

                checkSlowmo.Checked = cfg.Pins.Slowmo == 1;

                cbL1Button1.SelectedIndex = cfg.Actions.Button1.Layer1.Index;
                cbL1Button2.SelectedIndex = cfg.Actions.Button2.Layer1.Index;
                cbL1Button3.SelectedIndex = cfg.Actions.Button3.Layer1.Index;
                cbL1Button4.SelectedIndex = cfg.Actions.Button4.Layer1.Index;
                cbL1Button5.SelectedIndex = cfg.Actions.Button5.Layer1.Index;
                cbL1Button6.SelectedIndex = cfg.Actions.Button6.Layer1.Index;
                cbL1Button7.SelectedIndex = cfg.Actions.Button7.Layer1.Index;
                cbL1Button8.SelectedIndex = cfg.Actions.Button8.Layer1.Index;
            }
        }

        private void button1_Click(object sender, EventArgs e) //save
        {
            var cfg = new ConfigModel()
            {
                Pins = new PinsModel()
                {
                    Encoder1 = new PinsModel.EncoderPins()
                    {
                        Pin1 = (int)numericEncoder1Pin1.Value,
                        Pin2 = (int)numericEncoder1Pin2.Value
                    },
                    Encoder2 = new PinsModel.EncoderPins()
                    {
                        Pin1 = (int)numericEncoder2Pin1.Value,
                        Pin2 = (int)numericEncoder2Pin2.Value
                    },
                    Buttons = new PinsModel.ButtonPins()
                    {
                        Pin1 = (int)numericButton1.Value,
                        Pin2 = (int)numericButton2.Value,
                        Pin3 = (int)numericButton3.Value,
                        Pin4 = (int)numericButton4.Value,
                        Pin5 = (int)numericButton5.Value,
                        Pin6 = (int)numericButton6.Value,
                        Pin7 = (int)numericButton7.Value,
                        Pin8 = (int)numericButton8.Value
                    },
                    Slowmo = checkSlowmo.Checked ? 1 : 0
                },
                Actions = new ActionsModel() { 
                    Button1 = new ActionsModel.ButtonModel() {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button1.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button1.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button1.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button1.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button1.SelectedValue
                    },
                    Button2 = new ActionsModel.ButtonModel()
                    {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button2.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button2.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button2.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button2.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button2.SelectedValue
                    },
                    Button3 = new ActionsModel.ButtonModel()
                    {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button3.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button3.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button3.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button3.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button3.SelectedValue
                    },
                    Button4 = new ActionsModel.ButtonModel()
                    {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button4.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button4.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button4.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button4.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button4.SelectedValue
                    },
                    Button5 = new ActionsModel.ButtonModel()
                    {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button5.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button5.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button5.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button5.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button5.SelectedValue
                    },
                    Button6 = new ActionsModel.ButtonModel()
                    {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button6.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button6.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button6.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button6.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button6.SelectedValue
                    },
                    Button7 = new ActionsModel.ButtonModel()
                    {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button7.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button7.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button7.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button7.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button7.SelectedValue
                    },
                    Button8 = new ActionsModel.ButtonModel()
                    {
                        Layer1 = (ActionsModel.ButtonModel.UpDownModel)cbL1Button8.SelectedValue,
                        Layer2 = (ActionsModel.ButtonModel.UpDownModel)cbL2Button8.SelectedValue,
                        Layer3 = (ActionsModel.ButtonModel.UpDownModel)cbL3Button8.SelectedValue,
                        Layer4 = (ActionsModel.ButtonModel.UpDownModel)cbL4Button8.SelectedValue,
                        Layer5 = (ActionsModel.ButtonModel.UpDownModel)cbL5Button8.SelectedValue
                    }
                }
            };
            File.WriteAllText("./config.json", JsonSerializer.Serialize(cfg, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }
    }
}
