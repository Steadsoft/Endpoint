using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using UnitsNet;
using System.Text;

namespace Steadsoft.Spitfire.STM32MP153
{
    public interface IRegister
    {
        uint AllBits { get; set; }
    }
}