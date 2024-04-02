namespace Steadsoft.Spitfire.STM32MP153
{
    public static class Constants
    {
        public const UInt16 Bit0 = 0b0000_0000_0000_0001;
        public const UInt16 Bit1 = 0b0000_0000_0000_0010;
        public const UInt16 Bit2 = 0b0000_0000_0000_0100;
        public const UInt16 Bit3 = 0b0000_0000_0000_1000;
        public const UInt16 Bit4 = 0b0000_0000_0001_0000;
        public const UInt16 Bit5 = 0b0000_0000_0010_0000;
        public const UInt16 Bit6 = 0b0000_0000_0100_0000;
        public const UInt16 Bit7 = 0b0000_0000_1000_0000;
        public const UInt16 Bit8 = 0b0000_0001_0000_0000;
        public const UInt16 Bit9 = 0b0000_0010_0000_0000;
        public const UInt16 Bit10 = 0b0000_0100_0000_0000;
        public const UInt16 Bit11 = 0b0000_1000_0000_0000;
        public const UInt16 Bit12 = 0b0001_0000_0000_0000;
        public const UInt16 Bit13 = 0b0010_0000_0000_0000;
        public const UInt16 Bit14 = 0b0100_0000_0000_0000;
        public const UInt16 Bit15 = 0b1000_0000_0000_0000;

        public const UInt16 RCC_MC_AHB4ENSETR_OFX = 0x0AA8;
        public const UInt16 RCC_MP_AHB4ENSETR_OFX = 0x0A28;

        // Express the register offset as either 16 or 32 bits depending 
        // on whether the register itself is 16 or 32 bits.

        //public const UInt32 GPIO_MODER_OFX = 0x00;
        //public const UInt32 GPIO_OTYPER_OFX = 0x04;
        //public const UInt32 GPIO_OSPEEDR_OFX = 0x08;
        //public const UInt32 GPIO_PUPDR_OFX = 0x0C;
        //public const UInt32 GPIO_IDR_OFX = 0x10;
        //public const UInt32 GPIO_ODR_OFX = 0x14;
        //public const UInt32 GPIO_BSRR_OFX = 0x18;
        //public const UInt32 GPIO_LCKR_OFX = 0x1C;
        //public const UInt32 GPIO_AFRL_OFX = 0x20;
        //public const UInt32 GPIO_AFRH_OFX = 0x24;
        //public const UInt32 GPIO_BRR_OFX = 0x28;

        public const UInt32 GPIO_IPIDR_OFX = 0x3F8;

        public const UInt32 GPIOD_ADR = 0x50005000;
        public const UInt32 GPIOC_ADR = 0x50004000;
        public const UInt32 GPIOB_ADR = 0x50003000;
        public const UInt32 GPIOA_ADR = 0x50002000;

        public const UInt32 RCC_ADDR = 0x50000000;

        public const uint TIM2_ADDR = 0x40000000;
        public const uint TIM3_ADDR = 0x40001000;
        public const uint TIM4_ADDR = 0x40002000;
        public const uint TIM5_ADDR = 0x40003000;

        public const UInt32 BSEC_BASE_ADDR = 0x5C005000;

        public const UInt32 UID0_OFX = 0x234;
        public const UInt32 UID1_OFX = 0x238;
        public const UInt32 UID2_OFX = 0x23C;

        // language=regex
        public const string identifier = @"(([a-zA-Z][a-zA-Z\d]*))";
        // language=regex
        public const string hexnumber = @"0x[0-9A-Fa-f]+";
        // language=regex
        public const string s = @"\s*";
        // language=regex
        public const string lpar = @"\(";
        // language=regex
        public const string rpar = @"\)";
        // language=regex
        public const string colon = @":";
        // language=regex
        public const string commalist = @"\d+(\s*,\s*\d+)+";
        // language=regex
        public const string semicolon = @";";
        // language=regex
        public const string dot = @"\.";
        // language=regex
        public const string Syntax = $@"{identifier}{s}{lpar}{s}{hexnumber}{s}{rpar}{s}{colon}{s}({identifier}({dot}{identifier})?{s}{lpar}{s}{commalist}{s}{rpar}{s}{identifier}{s}{semicolon}{s})+";
    }
}