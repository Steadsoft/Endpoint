using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Steadsoft.Spitfire.STM32MP153
{
    public static class BitSupport
    {
        // Facilitates access to "array" elements composed of 1 bits
        private static int[] sections1Bits = new int[32];

        // Facilitates access to "array" elements composed of 2 bits
        private static BitVector32.Section[] sections2Bits = new BitVector32.Section[16];

        // Facilitates access to "array" elements composed of 3 bits
        private static BitVector32.Section[] sections3Bits = new BitVector32.Section[10];

        // Facilitates access to "array" elements composed of 4 bits
        private static BitVector32.Section[] sections4Bits = new BitVector32.Section[8];

        public static int[] VectorOf1Bit { get => sections1Bits; set => sections1Bits = value; }
        public static BitVector32.Section[] VectorOf2Bits { get => sections2Bits; set => sections2Bits = value; }
        public static BitVector32.Section[] VectoreOf3Bits { get => sections3Bits; set => sections3Bits = value; }
        public static BitVector32.Section[] VectorOf4Bits { get => sections4Bits; set => sections4Bits = value; }

        static BitSupport()
        {
            sections1Bits[0] = BitVector32.CreateMask();

            for (int I = 1; I < 32; I++)
            {
                sections1Bits[I] = BitVector32.CreateMask(sections1Bits[I - 1]);
            }

            sections2Bits[0] = BitVector32.CreateSection(0b_11);

            for (int I=1; I < 16; I++)
            {
                sections2Bits[I] = BitVector32.CreateSection(0b_11, sections2Bits[I - 1]);
            }

            sections3Bits[0] = BitVector32.CreateSection(0b_111);

            for (int I = 1; I < 10; I++)
            {
                sections3Bits[I] = BitVector32.CreateSection(0b_111, sections3Bits[I - 1]);
            }

            sections4Bits[0] = BitVector32.CreateSection(0b_1111);

            for (int I = 1; I < 8; I++)
            {
                sections4Bits[I] = BitVector32.CreateSection(0b_1111, sections4Bits[I - 1]);
            }
        }


        /// <summary>
        /// If a register can be regarded as a contiguous sequence of identically sized bit fields then this
        /// function can get the value of any 'element'.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="ElementBitLength"></param>
        /// <param name="ElementCount"></param>
        /// <param name="Register"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static uint GetBitArrayElement (int I, int ElementBitLength, int ElementCount, ref uint Register)
        {
            if (I >= ElementCount)
                throw new ArgumentOutOfRangeException(nameof(I), $"The index value must be between 0 and {ElementCount-1} inclusive.");

            byte mask = (byte)((1 << ElementBitLength - 1) - 1);
            byte shift = (byte)(ElementBitLength * I);
            return ((uint)(0b_11 << shift) & Register >> shift);
        }

        public static ref BitVector32 GetAsBitVector32(ref uint register)
        {
            return ref Unsafe.As<uint, BitVector32>(ref register);
        }

        //public static ref T GetAsRegister<T>(ref uint register)
        //{
        //    return ref Unsafe.As<UInt32,T>(ref register);
        //}

        public static int CheckMax(int Index, int Max)
        {
            if (Index > Max)
                throw new ArgumentOutOfRangeException(nameof(Index), $"The index must be less than {Max}.");

            return Index;
        }

        /// <summary>
        /// Checks that an inaccessible bit is not being accessed, a set bit in the mask means an illegal bit.
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Mask"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int CheckMask(int Index, uint Mask)
        {
            if (Index > 31)
                throw new ArgumentOutOfRangeException(nameof(Index), $"The index must be less than 32.");

            uint shifter = 1U << Index; // If the bit position being accessed corresponds a set bit in the mask, we throw.

            if (((uint)(1 << Index) & Mask) != 0)
                throw new ArgumentOutOfRangeException(nameof(Index), $"The indexed bit is out of bounds.");

            return Index;
        }
    }
}