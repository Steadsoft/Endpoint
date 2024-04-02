using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steadsoft.Spitfire.STM32MP153
{
    public static class PeripheralAddress
    {
        public enum AHB4 : uint
        {
            INVALID = 0,
            GPIOD = 0x50005000,
            GPIOC = 0x50004000,
            GPIOB = 0x50003000,
            GPIOA = 0x50002000,
            RCC = 0x50000000
        }

        public enum APB1
        {
            INVALID = 0,
            TIM2 = 0x40000000,
            TIM3 = 0x40001000,
            TIM4 = 0x40002000,
            TIM5 = 0x40003000,

            DAC = 0x40017000
        }
    }

    public enum SystemAddress :uint
    {
        NVIC = 0xE000E100U,
        SCB =  0xE000ED00U,
    }
}