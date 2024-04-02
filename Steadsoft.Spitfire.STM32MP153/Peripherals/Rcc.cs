using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnitsNet;

namespace Steadsoft.Spitfire.STM32MP153.Peripherals
{
    public partial class Rcc : Peripheral
    {
        internal Rcc() : base((uint)AHB4.RCC)
        {
        }
    }

    public partial class Page : Peripheral
    {
        internal Page(uint Address, uint Alignment) : base(Address, Alignment)
        {
        }

    }
}