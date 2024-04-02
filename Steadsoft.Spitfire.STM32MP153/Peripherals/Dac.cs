using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steadsoft.Spitfire.STM32MP153.Peripherals
{
    public partial class Dac : Peripheral
    {
        internal Dac(APB1 Address) : base((uint)Address)
        {
        }

        public enum MAMPMode
        {
            Unmask_0,
            Unmask_1,
            Unmask_2,
            Unmask_3,
            Unmask_4,
            Unmask_5,
            Unmask_6,
            Unmask_7,
            Unmask_8,
            Unmask_9,
            Unmask_10,
            Unmask_11
        }

        public enum TSELMode
        {
            SwTrig,
            Trig_1,
            Trig_2,
            Trig_3,
            Trig_4,
            Trig_5,
            Trig_6,
            Trig_7,
            Trig_8,
            Trig_9,
            Trig_10,
            Trig_11,
            Trig_12,
            Trig_13,
            Trig_14,
            Trig_15,
        }

        public enum WMode
        {
            Disabled,
            Noise,
            Triangle,
        }
    }
}