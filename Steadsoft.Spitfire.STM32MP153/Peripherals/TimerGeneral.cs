using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace Steadsoft.Spitfire.STM32MP153.Peripherals
{
    public partial class TimerGeneral : Peripheral
    {
        internal TimerGeneral(APB1 Address) : base((uint)Address)
        {
        }
        public enum OCMode
        {
            Frozen = 0b0000,
            ActiveOnMatch = 0b_0001,
            InactiveOnMatch = 0b_0010,
            ToggleOnMatch = 0b_0011,
            ForceInactive = 0b_0100,
            ForceActive = 0b_0101,
            PwmMode1 = 0b_0110,
            PwmMode2 = 0b_0111,
            RetrigOpmMode1 = 0b_1000,
            RetrigOpmMode2 = 0b_1001,
            CombinedPwmMode1 = 0b_1100,
            CombinedPwmMode2 = 0b_1101,
            AssymetricPwmMode1 = 0b_1110,
            AssymetricPwmMode2 = 0b_1111
        }
        public enum CC1SMode
        {
            Output,
            InputTI1,
            InputTI2,
            InputTRC
        }
        public enum CC2SMode
        {
            Output,
            InputTI2,
            InputTI,
            InputTRC
        }
        public enum CenterMode
        {
            EdgeAligned,
            CenterAligned_1,
            CenterAligned_2,
            CenterAligned_3

        }
        public enum  MasterMode
        {
            Reset,
            Enable,
            Update,
            ComparePulse,
            CompareOC1,
            CompareOC2,
            CompareOC3,
            CompareOC4,
        }
    }
}