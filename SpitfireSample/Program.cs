using GHIElectronics.Endpoint.Core;
using GHIElectronics.Endpoint.Native;
using Steadsoft.Spitfire.STM32MP153;
using System.Collections.Specialized;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;
using Steadsoft.Spitfire.STM32MP153.Peripherals;
using static Steadsoft.Spitfire.STM32MP153.PeripheralAddress;
using static Steadsoft.Spitfire.STM32MP153.PeripheralInstance;
using static Steadsoft.Spitfire.STM32MP153.Peripherals.Gpio;
using static Steadsoft.Spitfire.STM32MP153.Peripherals.TimerGeneral;

namespace PeripheralAddresses
{
    internal class Program
    {
        // STM32MP153 - TFBGA361 package
        // REFMAN https://www.st.com/resource/en/reference_manual/rm0442-stm32mp153-advanced-armbased-32bit-mpus-stmicroelectronics.pdf
        // DATASHEET https://www.st.com/resource/en/datasheet/stm32mp153a.pdf
        // ALSO: https://community.st.com/t5/stm32-mpus-products/using-mmap-in-c-code-from-linux-application-to-access-gpios-i/td-p/239506

        // Board pinouts
        // https://www.ghielectronics.com/endpoint/

        private static readonly Stopwatch clock = new();
        private static readonly int iterations = 37000;  // 32616 or greater causes out of memory exception.
        public static void Main(string[] args)
        {
          
            Console.WriteLine($"Board Image Version: {DeviceInformation.Version}.");

            Console.WriteLine("Pulsing via DAC");

            PulseViaDac();

            Console.WriteLine("Pulsing via Timer GPIO");
            
            PulseViaTimerGpio();

            Console.WriteLine("Pulsing via Timer");
            
            PulseViaTimer();

            Console.WriteLine("Pulsing via Register");

            PulseViaRegister();

            //Console.WriteLine("Pulsing via Library");

            //PulseViaLibrary();

            //Console.WriteLine($"Elapsed seconds: {clock.Elapsed.TotalSeconds}");

            Console.WriteLine("Pulsing via Direct");

            PulseViaDirect();

            Console.WriteLine($"Elapsed seconds: {clock.Elapsed.TotalSeconds}");

            Console.ReadLine();

        }

        public static void PulseViaDac()
        {
            double[] sine = new double[4096];
            uint[] intsine = new uint[4096];

            double full = Math.PI * 2;

            double incr = full / 2048;

            for (int i = 0; i < 4096; i++)
            {
                sine[i] = Math.Sin(i * incr);
                intsine[i] = Convert.ToUInt32((sine[i] + 1) * 2048);
            }

            using var clocks = Peripheral.OpenRcc();
            using var gpioa = Peripheral.OpenGpio(GpioPort.A);
            using var dac1 = Peripheral.OpenDac();

            clocks.MP_APB1ENSETR.DAC12EN = true;
            clocks.MP_AHB4ENSETR[GpioPort.A] = true;

            gpioa.MODER[4] = Mode.Analog;

            dac1.CR.EN1 = true;

            uint data = 0;

            while (true)
            {
                for (int i = 0; i < 4096; i++)
                {
                    dac1.DHR12R1.DACC1DHR = intsine[i];
                }
            }
        }

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


        /// <summary>
        /// Polls a timer and toggles LED on expiration
        /// </summary>
        public static void PulseViaTimer()
        {
            using var clock = Peripheral.OpenRcc();
            using var timer = Peripheral.OpenTimer(GeneralTimer.TIM2);
            using var gpioa = Peripheral.OpenGpio(GpioPort.A);

            // Enable clocks for GPIOA and TIM2

            clock.MP_APB1ENSETR.TIM2EN = true;
            clock.MP_AHB4ENSETR[GpioPort.A] = true;

            // Setup the GPIO pin 4 here

            gpioa.MODER[4] = Mode.Output;
            gpioa.OSPEEDR[4] = Speed.VeryHigh;
            gpioa.PUPDR[4] = Pull.Down;

            // Setup the timer registers

            timer.PSC = 500;
            timer.ARR = 20;
            timer.CNT_NRE = 0;

            // Enable counting

            timer.CR1.CEN = true;

            // Crudely poll and toggle PA4 on each timer overflow

            while(true)
            {
                while(timer.SR.UIF == false)
                {
                }

                gpioa.BSRR = 0x_00000010U;
                gpioa.BSRR = 0x_00100000U;

                // Reset the flag

                timer.SR.UIF = false;
            }
        }

        public static void PulseViaDirect()
        {
            using var rcc = Peripheral.OpenRcc();
            using var gpioa = Peripheral.OpenGpio(GpioPort.A);

            rcc.MP_AHB4ENSETR[GpioPort.A] = true;

            //gpioa.OSPEEDR.AllBits = 0;

            gpioa.EditRegister(ref gpioa.OSPEEDR, (ref Gpio.Registers.OSPEEDR reg) => 
            {
                reg[2] = Gpio.Speed.Medium;
                reg[3] = Gpio.Speed.VeryHigh;
            }
            );

            var mem = GC.GetGCMemoryInfo();

            // This serves no real purpose here but does prevent 
            // any collecttions taking place within the designated region.

            Platform.WithoutGC(4096, () =>
            {
                gpioa.MODER[4] = Gpio.Mode.Output;
                gpioa.OSPEEDR[4] = Gpio.Speed.VeryHigh;
                gpioa.PUPDR[4] = Gpio.Pull.Down;
            });

            while (true)
            {
                gpioa.BSRR.AllBits = 0x_00000010;
                gpioa.BSRR.AllBits = 0x_00100000;
            }
        }

        public static void PulseViaLibrary()
        {
            var port = EPM815.Gpio.Pin.PA4 / 16;
            var pin = EPM815.Gpio.Pin.PA4 % 16;
            var gpioDriver = new LibGpiodDriver((int)port);

            var gpioController = new GpioController(PinNumberingScheme.Logical, gpioDriver);

            gpioController.OpenPin(pin);
            gpioController.SetPinMode(pin, PinMode.Output);

            clock.Start();

            for (int I = 0; I < iterations; I++)
            {
                gpioController.Write(pin, PinValue.High);
                gpioController.Write(pin, PinValue.Low);
            }

            clock.Stop();
        }

        public static void PulseViaRegister()
        {
            var id = EPM815.Gpio.Pin.PA0;
            var port = id / 16;
            var pin = id % 16;

            var GPIO_PORT = 0x50002000 + port * 0x1000;
            var GPIO_PORT_MODER = GPIO_PORT + 0; var GPIO_PORT_OTYPER = GPIO_PORT + 0x4;
            var GPIO_PORT_BSRR = GPIO_PORT + 0x18;

            Register.Write(0x50000A28, (uint)(1 << (int)port));

            var value = Register.Read((uint)GPIO_PORT_MODER);

            var clear = 3 << (pin * 2);

            value &= (uint)~clear;

            var set = (uint)1 << (pin * 2);

            value |= set;

            Register.Write((uint)GPIO_PORT_MODER, value);

            clock.Start();

            for (int I = 0; I < iterations; I++)
            {
                try
                {
                    Register.Write((uint)GPIO_PORT_BSRR, 1 << 0);
                    Register.Write((uint)GPIO_PORT_BSRR, 1 << 16);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            clock.Stop();
        }
    }
}