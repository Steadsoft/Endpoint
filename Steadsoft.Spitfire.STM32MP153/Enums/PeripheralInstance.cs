using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steadsoft.Spitfire.STM32MP153
{
    public static class PeripheralInstance
    {
        public enum GpioPort
        {
            A,
            B,
            C,
            D
        }

        public enum GeneralTimer
        {
            TIM2,
            TIM3,
            TIM4,
            TIM5
        }

        public enum AdvancedTimer
        {
            TIM1,
            TIM8,
        }

        public enum BasicTimer
        {
            TIM6,
            TIM7
        }

    }
}
