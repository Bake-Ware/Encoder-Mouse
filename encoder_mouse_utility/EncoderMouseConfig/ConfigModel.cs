using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoderMouseConfig
{
    public class ConfigModel
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
