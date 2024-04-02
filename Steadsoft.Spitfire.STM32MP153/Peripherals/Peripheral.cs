using GHIElectronics.Endpoint.Core;
using Steadsoft.Spitfire.STM32MP153;
using Steadsoft.Spitfire.STM32MP153.Peripherals;
using System.Runtime.CompilerServices;

// SEE: http://www.bradgoodman.com/bittool/

namespace Steadsoft.Spitfire.STM32MP153
{
    public delegate void RefAction<T>(ref T R) where T : IRegister;
    public abstract class Peripheral : IDisposable
    {
        private bool disposedValue;
        protected Peripheral(UInt32 RealAddress, uint Alignment = 0x0400)
        {
            int handle = 0;
            uint mappedAddress = 0;

            if (RealAddress == 0)
                throw new ArgumentOutOfRangeException(nameof(RealAddress), "The supplied address must not be zero.");

            if ((uint)RealAddress % Alignment != 0)
                throw new ArgumentOutOfRangeException(nameof(RealAddress), $"The supplied address ({RealAddress.ToString("X8")}) must be 1K aligned.");

            try
            {
                handle = Interop.Open(Linux.MemoryPathname, Interop.FileOpenFlags.O_RDWR | Interop.FileOpenFlags.O_SYNC);

                if (handle < 1)
                    throw new Exception($"Failed to open '{Linux.MemoryPathname}', the result handle was {handle}.");

                var result = Interop.Mmap(nint.Zero, (int)(4096), Interop.MemoryMappedProtections.PROT_READ | Interop.MemoryMappedProtections.PROT_WRITE, Interop.MemoryMappedFlags.MAP_SHARED, handle, (int)RealAddress);

                if (result == -1)
                    throw new Exception($"Failed to map the address '{RealAddress:X8}'");

                mappedAddress = (uint)result;

                this.Handle = handle;
                this.RealAddress = RealAddress;
                this.MappedAddress = mappedAddress;
                this.Pages = 1;
            }
            catch (Exception ex)
            {
                Dispose();
                throw;
            }
        }
        /// <summary>
        /// Copies a register, calls a user lambda to 'edit' the register fields then writes that final register back to 
        /// the actual real register.
        /// </summary>
        /// <typeparam name="T">The type of the register.</typeparam>
        /// <param name="Register">A ref to a register property in a peripheral.</param>
        /// <param name="Editor">A lambda that freely updates a copy of the register.</param>
        public void EditRegister<T>(ref T Register, RefAction<T> Editor) where T : IRegister
        {
            var copy = Register;
            Editor(ref copy);
            Register = copy;
        }
        public void TwiddleRegister<T>(ref T Register, uint And, uint Or) where T : IRegister
        {
            EditRegister(ref Register, (ref T copied) =>
            {
                copied.AllBits &= And;
                copied.AllBits |= Or;
            }
            );
        }
        public static Gpio OpenGpio(GpioPort instance)
        {
            return instance switch
            {
                GpioPort.A => new Gpio(AHB4.GPIOA),
                GpioPort.B => new Gpio(AHB4.GPIOB),
                GpioPort.C => new Gpio(AHB4.GPIOC),
                GpioPort.D => new Gpio(AHB4.GPIOD),
            };
        }
        public static TimerGeneral OpenTimer(GeneralTimer instance)
        {
            return instance switch
            {
                GeneralTimer.TIM2 => new TimerGeneral(APB1.TIM2),
                GeneralTimer.TIM3 => new TimerGeneral(APB1.TIM3),
                GeneralTimer.TIM4 => new TimerGeneral(APB1.TIM4),
                GeneralTimer.TIM5 => new TimerGeneral(APB1.TIM5),
            };
        }

        public static Peripherals.Dac OpenDac()
        {
            return new Peripherals.Dac(APB1.DAC);
        }
        //public static BasicTimer OpenTimer(BasicTimer instance)
        //{
        //    return null;
        //}

        //public static TimerGeneral OpenTimer(GeneralTimer instance)
        //{
        //    return instance switch
        //    {
        //        GeneralTimer.TIM2 => new TimerGeneral(APB1.TIM2),
        //        GeneralTimer.TIM3 => new TimerGeneral(APB1.TIM3),
        //        GeneralTimer.TIM4 => new TimerGeneral(APB1.TIM4),
        //        GeneralTimer.TIM5 => new TimerGeneral(APB1.TIM5),
        //    };
        //}
        public static Rcc OpenRcc()
        {
            return new Rcc();
        }

        public unsafe static Page OpenPage(uint Address)
        {
            return new Page(Address, 0x0100);
        }
        public int Handle { get; protected set; }
        public uint MappedAddress { get; protected set; }
        public uint RealAddress { get; protected set; }
        public uint Pages { get; protected set; }
        protected unsafe ref T GetAsRegister<T>(uint Offset) where T : unmanaged
        {
            return ref *(T*)(MappedAddress + Offset);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                if (MappedAddress != 0)
                    Interop.Munmap((nint)MappedAddress, (int)RealAddress);

                if (Handle != 0)
                    Interop.Close(Handle);

                disposedValue = true;
            }
        }
        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Mapping()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}