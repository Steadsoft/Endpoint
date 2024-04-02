This package abstracts some of the peripheral registers in the STM32MP153 processor, enabling C# code to perform GPIO as well as some limited DAC and Timer functionality.

The following example shows how one typically would use this:

```cs
        public static void PulseViaTimerGpio()
        {
            using var clock = Peripheral.OpenRcc();
            using var timer = Peripheral.OpenTimer(GeneralTimer.TIM2);
            using var gpioa = Peripheral.OpenGpio(GpioPort.A);

            // Enable clocks for GPIOA and TIM2

            clock.MP_APB1ENSETR.TIM2EN = true;
            clock.MP_AHB4ENSETR[GpioPort.A] = true;

            // Setup the GPIO pin 5 here

            gpioa.MODER[5] = Mode.Alternate;
            gpioa.OSPEEDR[5] = Speed.VeryHigh;
            gpioa.PUPDR[5] = Pull.None;
            gpioa.AFRL[5] = AlternateFunction.AF1;

            // Setup the timer registers

            timer.PSC = 9;
            timer.ARR = 4;
            timer.CCMR1.OC1M = OCMode.ToggleOnMatch;
            timer.CCR1.AllBits = 0;
            timer.CCER.CC1E = true;
            timer.CNT_NRE = 0;
            timer.CR1.CEN = true;

            Thread.Sleep(-1);   // do nothing
        }

```
The register names and sub field names correspond very closely to the documentation which can be found [here](https://www.st.com/resource/en/reference_manual/rm0442-stm32mp153-advanced-armbased-32bit-mpus-stmicroelectronics.pdf).