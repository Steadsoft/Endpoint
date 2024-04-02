using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using UnitsNet;
using System.Text;

// SEE: https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1008

namespace Steadsoft.Spitfire.STM32MP153.Peripherals
{
    public partial class Gpio : Peripheral
    {
        internal Gpio(AHB4 Address) : base((uint)Address)
        {
        }
        public enum Pull
        {
            None = 0,
            Up = 1,
            Down = 2,
            Reserved = 3
        }
        public enum Speed
        {
            Low = 0,
            Medium = 1,
            High = 2,
            VeryHigh = 3
        }
        public enum Mode
        {
            Input = 0,
            Output = 1,
            Alternate = 2,
            Analog = 3
        }
        public enum AlternateFunction
        {
            AF0 = 0,
            AF1 ,
            AF2 ,
            AF3 ,
            AF4 ,
            AF5 ,
            AF6 ,
            AF7 ,
            AF8 ,
            AF9 ,
            AF10 ,
            AF11 ,
            AF12 ,
            AF13 ,
            AF14 ,
            AF15 
        }
    }
}