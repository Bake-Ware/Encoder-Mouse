using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderMouseConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("./config.json"))
            {
                var cfgRaw = File.ReadAllText("./config.json");
                var cfg = System.Text.Json.JsonSerializer.Deserialize<ConfigModel>(cfgRaw);
                numericEncoder1Pin1.Value = cfg.Encoder1.Pin1;
                numericEncoder1Pin2.Value = cfg.Encoder1.Pin2;
                numericEncoder2Pin1.Value = cfg.Encoder2.Pin1;
                numericEncoder2Pin2.Value = cfg.Encoder2.Pin2;
                
                numericButton1.Value = cfg.Buttons.Pin1;
                numericButton2.Value = cfg.Buttons.Pin2;
                numericButton3.Value = cfg.Buttons.Pin3;
                numericButton4.Value = cfg.Buttons.Pin4;
                numericButton5.Value = cfg.Buttons.Pin5;
                numericButton6.Value = cfg.Buttons.Pin6;
                numericButton7.Value = cfg.Buttons.Pin7;
                numericButton8.Value = cfg.Buttons.Pin8;

                checkSlowmo.Checked = cfg.Slowmo == 1;
            }
        }

        private void button1_Click(object sender, EventArgs e) //save
        {
            var cfg = new ConfigModel()
            {
                Encoder1 = new ConfigModel.EncoderPins()
                {
                    Pin1 = (int)numericEncoder1Pin1.Value,
                    Pin2 = (int)numericEncoder1Pin2.Value
                },
                Encoder2 = new ConfigModel.EncoderPins()
                {
                    Pin1 = (int)numericEncoder2Pin1.Value,
                    Pin2 = (int)numericEncoder2Pin2.Value
                },
                Buttons = new ConfigModel.ButtonPins()
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
            };
            File.WriteAllText("./config.json", System.Text.Json.JsonSerializer.Serialize(cfg));
        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }
    }
}
