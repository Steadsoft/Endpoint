using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/********************************************************************************/
/* Steadsoft.Spitfire v1.0.0.0                                                  */
/* Warning DO NOT MODIFY this struct by editing.                                */
/* This code was generated by a software tool.                                  */
/********************************************************************************/

namespace Steadsoft.Spitfire.STM32MP153.Peripherals
{
    public partial class TimerGeneral
    {
        public ref Registers.CR1 CR1 => ref GetAsRegister<Registers.CR1>(0x0000);
        public ref Registers.CR2 CR2 => ref GetAsRegister<Registers.CR2>(0x0004);
        public ref Registers.SR SR => ref GetAsRegister<Registers.SR>(0x0010);
        public ref Registers.CCMR1 CCMR1 => ref GetAsRegister<Registers.CCMR1>(0x0018);
        public ref Registers.CNT_NRE CNT_NRE => ref GetAsRegister<Registers.CNT_NRE>(0x0024);
        public ref Registers.CNT_REM CNT_REM => ref GetAsRegister<Registers.CNT_REM>(0x0024);
        public ref Registers.ARR ARR => ref GetAsRegister<Registers.ARR>(0x002C);
        public ref Registers.PSC PSC => ref GetAsRegister<Registers.PSC>(0x0028);
        public ref Registers.CCER CCER => ref GetAsRegister<Registers.CCER>(0x0020);
        public ref Registers.CCR1 CCR1 => ref GetAsRegister<Registers.CCR1>(0x0034);

        public static class Registers
        {
            public struct CR1 : IRegister
            {
                private uint allBits;

                private CR1(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits & 0x00000BFFU; set => allBits = value & 0x00000BFFU; }

                public bool CEN
                {
                    get => Convert.ToBoolean ((this  & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFEU) | ((Convert.ToUInt32(value) & 0x00000001U));
                }

                public bool UDIS
                {
                    get => Convert.ToBoolean ((this  >> 1 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFDU) | ((Convert.ToUInt32(value) & 0x00000001U) << 1);
                }

                public bool URS
                {
                    get => Convert.ToBoolean ((this  >> 2 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFBU) | ((Convert.ToUInt32(value) & 0x00000001U) << 2);
                }

                public bool OPM
                {
                    get => Convert.ToBoolean ((this  >> 3 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFF7U) | ((Convert.ToUInt32(value) & 0x00000001U) << 3);
                }

                public bool DIR
                {
                    get => Convert.ToBoolean ((this  >> 4 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFEFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 4);
                }

                public CenterMode CMS
                {
                    get => (CenterMode) ((this  >> 5 & 0x00000003U)) ;
                    set => AllBits = (this & 0xFFFFFF9FU) | ((Convert.ToUInt32(value) & 0x00000003U) << 5);
                }

                public bool ARPE
                {
                    get => Convert.ToBoolean ((this  >> 7 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFF7FU) | ((Convert.ToUInt32(value) & 0x00000001U) << 7);
                }

                public uint CKD
                {
                    get => (uint) ((this  >> 8 & 0x00000003U)) ;
                    set => AllBits = (this & 0xFFFFFCFFU) | ((Convert.ToUInt32(value) & 0x00000003U) << 8);
                }

                public bool UIFREMAP
                {
                    get => Convert.ToBoolean ((this  >> 11 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFF7FFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 11);
                }


                public static implicit operator uint (CR1 R) => R.allBits;
                public static implicit operator CR1(uint R) => new CR1(R);
            }

            public struct CR2 : IRegister
            {
                private uint allBits;

                private CR2(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits & 0x000000F8U; set => allBits = value & 0x000000F8U; }

                public bool CCDS
                {
                    get => Convert.ToBoolean ((this  >> 3 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFF7U) | ((Convert.ToUInt32(value) & 0x00000001U) << 3);
                }

                public MasterMode MMS
                {
                    get => (MasterMode) ((this  >> 4 & 0x00000007U)) ;
                    set => AllBits = (this & 0xFFFFFF8FU) | ((Convert.ToUInt32(value) & 0x00000007U) << 4);
                }

                public bool TI1S
                {
                    get => Convert.ToBoolean ((this  >> 7 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFF7FU) | ((Convert.ToUInt32(value) & 0x00000001U) << 7);
                }


                public static implicit operator uint (CR2 R) => R.allBits;
                public static implicit operator CR2(uint R) => new CR2(R);
            }

            public struct SR : IRegister
            {
                private uint allBits;

                private SR(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits & 0x00001E5FU; set => allBits = value & 0x00001E5FU; }

                public bool UIF
                {
                    get => Convert.ToBoolean ((this  & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFEU) | ((Convert.ToUInt32(value) & 0x00000001U));
                }

                public bool CC1IF
                {
                    get => Convert.ToBoolean ((this  >> 1 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFDU) | ((Convert.ToUInt32(value) & 0x00000001U) << 1);
                }

                public bool CC2IF
                {
                    get => Convert.ToBoolean ((this  >> 2 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFBU) | ((Convert.ToUInt32(value) & 0x00000001U) << 2);
                }

                public bool CC3IF
                {
                    get => Convert.ToBoolean ((this  >> 3 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFF7U) | ((Convert.ToUInt32(value) & 0x00000001U) << 3);
                }

                public bool CC4IF
                {
                    get => Convert.ToBoolean ((this  >> 4 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFEFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 4);
                }

                public bool TIF
                {
                    get => Convert.ToBoolean ((this  >> 6 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFBFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 6);
                }

                public bool CC1OF
                {
                    get => Convert.ToBoolean ((this  >> 9 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFDFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 9);
                }

                public bool CC2OF
                {
                    get => Convert.ToBoolean ((this  >> 10 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFBFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 10);
                }

                public bool CC3OF
                {
                    get => Convert.ToBoolean ((this  >> 11 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFF7FFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 11);
                }

                public bool CC4OF
                {
                    get => Convert.ToBoolean ((this  >> 12 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFEFFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 12);
                }


                public static implicit operator uint (SR R) => R.allBits;
                public static implicit operator SR(uint R) => new SR(R);
            }

            public struct CCMR1 : IRegister
            {
                private uint allBits;

                private CCMR1(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits & 0x0101FFFFU; set => allBits = value & 0x0101FFFFU; }

                public CC1SMode CC1S
                {
                    get => (CC1SMode) ((this  & 0x00000003U)) ;
                    set => AllBits = (this & 0xFFFFFFFCU) | ((Convert.ToUInt32(value) & 0x00000003U));
                }

                public bool OC1FE
                {
                    get => Convert.ToBoolean ((this  >> 2 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFBU) | ((Convert.ToUInt32(value) & 0x00000001U) << 2);
                }

                public bool OC1PE
                {
                    get => Convert.ToBoolean ((this  >> 3 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFF7U) | ((Convert.ToUInt32(value) & 0x00000001U) << 3);
                }

                public OCMode OC1M
                {
                    get => (OCMode) ((this  >> 13 & 0x00000008U) | (this >> 4 & 0x00000007U)  ) ;
                    set => AllBits = (this & 0xFFFEFF8FU) | ((Convert.ToUInt32(value) & 0x00000008U) << 13) | ((Convert.ToUInt32(value) & 0x00000007U) << 4);
                }

                public bool OC1CE
                {
                    get => Convert.ToBoolean ((this  >> 7 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFF7FU) | ((Convert.ToUInt32(value) & 0x00000001U) << 7);
                }

                public CC2SMode CC2S
                {
                    get => (CC2SMode) ((this  >> 8 & 0x00000003U)) ;
                    set => AllBits = (this & 0xFFFFFCFFU) | ((Convert.ToUInt32(value) & 0x00000003U) << 8);
                }

                public bool OC2FE
                {
                    get => Convert.ToBoolean ((this  >> 10 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFBFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 10);
                }

                public bool OC2PE
                {
                    get => Convert.ToBoolean ((this  >> 11 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFF7FFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 11);
                }

                public OCMode OC2M
                {
                    get => (OCMode) ((this  >> 21 & 0x00000008U) | (this >> 12 & 0x00000007U)  ) ;
                    set => AllBits = (this & 0xFEFF8FFFU) | ((Convert.ToUInt32(value) & 0x00000008U) << 21) | ((Convert.ToUInt32(value) & 0x00000007U) << 12);
                }

                public bool OC2CE
                {
                    get => Convert.ToBoolean ((this  >> 15 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFF7FFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 15);
                }


                public static implicit operator uint (CCMR1 R) => R.allBits;
                public static implicit operator CCMR1(uint R) => new CCMR1(R);
            }

            public struct CNT_NRE : IRegister
            {
                private uint allBits;

                private CNT_NRE(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits; set => allBits = value; }

                public bool this[int B]
                {
                    get => GetAsBitVector32(ref allBits)[BitSupport.VectorOf1Bit[CheckMax(B, 31)]];
                    set => GetAsBitVector32(ref allBits)[BitSupport.VectorOf1Bit[CheckMax(B, 31)]] = value;
                }

                public static implicit operator uint (CNT_NRE R) => R.allBits;
                public static implicit operator CNT_NRE(uint R) => new CNT_NRE(R);
            }

            public struct CNT_REM : IRegister
            {
                private uint allBits;

                private CNT_REM(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits; set => allBits = value; }

                public bool this[int B]
                {
                    get => GetAsBitVector32(ref allBits)[BitSupport.VectorOf1Bit[CheckMax(B, 30)]];
                    set => GetAsBitVector32(ref allBits)[BitSupport.VectorOf1Bit[CheckMax(B, 30)]] = value;
                }
                public bool UIFCPY
                {
                    get => Convert.ToBoolean ((this  >> 31 & 0x00000001U)) ;
                    set => AllBits = (this & 0x7FFFFFFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 31);
                }


                public static implicit operator uint (CNT_REM R) => R.allBits;
                public static implicit operator CNT_REM(uint R) => new CNT_REM(R);
            }

            public struct ARR : IRegister
            {
                private uint allBits;

                private ARR(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits & 0x7FFFFFFFU; set => allBits = value & 0x7FFFFFFFU; }

                public bool this[int B]
                {
                    get => GetAsBitVector32(ref allBits)[BitSupport.VectorOf1Bit[CheckMax(B, 30)]];
                    set => GetAsBitVector32(ref allBits)[BitSupport.VectorOf1Bit[CheckMax(B, 30)]] = value;
                }

                public static implicit operator uint (ARR R) => R.allBits;
                public static implicit operator ARR(uint R) => new ARR(R);
            }

            public struct PSC : IRegister
            {
                private uint allBits;

                private PSC(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits & 0x0000FFFFU; set => allBits = value & 0x0000FFFFU; }

                public uint VALUE
                {
                    get => (uint) ((this  & 0x0000FFFFU)) ;
                    set => AllBits = (this & 0xFFFF0000U) | ((Convert.ToUInt32(value) & 0x0000FFFFU));
                }


                public static implicit operator uint (PSC R) => R.allBits;
                public static implicit operator PSC(uint R) => new PSC(R);
            }

            public struct CCER : IRegister
            {
                private uint allBits;

                private CCER(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits & 0x0000BBBBU; set => allBits = value & 0x0000BBBBU; }

                public bool CC1E
                {
                    get => Convert.ToBoolean ((this  & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFEU) | ((Convert.ToUInt32(value) & 0x00000001U));
                }

                public bool CC1P
                {
                    get => Convert.ToBoolean ((this  >> 1 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFFDU) | ((Convert.ToUInt32(value) & 0x00000001U) << 1);
                }

                public bool CC1NP
                {
                    get => Convert.ToBoolean ((this  >> 3 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFF7U) | ((Convert.ToUInt32(value) & 0x00000001U) << 3);
                }

                public bool CC2E
                {
                    get => Convert.ToBoolean ((this  >> 4 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFEFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 4);
                }

                public bool CC2P
                {
                    get => Convert.ToBoolean ((this  >> 5 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFFDFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 5);
                }

                public bool CC2NP
                {
                    get => Convert.ToBoolean ((this  >> 7 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFF7FU) | ((Convert.ToUInt32(value) & 0x00000001U) << 7);
                }

                public bool CC3E
                {
                    get => Convert.ToBoolean ((this  >> 8 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFEFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 8);
                }

                public bool CC3P
                {
                    get => Convert.ToBoolean ((this  >> 9 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFFDFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 9);
                }

                public bool CC3NP
                {
                    get => Convert.ToBoolean ((this  >> 11 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFF7FFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 11);
                }

                public bool CC4E
                {
                    get => Convert.ToBoolean ((this  >> 12 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFEFFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 12);
                }

                public bool CC4P
                {
                    get => Convert.ToBoolean ((this  >> 13 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFFDFFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 13);
                }

                public bool CC4NP
                {
                    get => Convert.ToBoolean ((this  >> 15 & 0x00000001U)) ;
                    set => AllBits = (this & 0xFFFF7FFFU) | ((Convert.ToUInt32(value) & 0x00000001U) << 15);
                }


                public static implicit operator uint (CCER R) => R.allBits;
                public static implicit operator CCER(uint R) => new CCER(R);
            }

            public struct CCR1 : IRegister
            {
                private uint allBits;

                private CCR1(uint Initial)
                {
                    allBits = Initial;
                }

                public uint AllBits { get => allBits; set => allBits = value; }

                public uint CCR
                {
                    get => (uint) ((this  & 0xFFFFFFFFU)) ;
                    set => AllBits = (this & 0x00000000U) | ((Convert.ToUInt32(value) & 0xFFFFFFFFU));
                }


                public static implicit operator uint (CCR1 R) => R.allBits;
                public static implicit operator CCR1(uint R) => new CCR1(R);
            }

            }
    }
}