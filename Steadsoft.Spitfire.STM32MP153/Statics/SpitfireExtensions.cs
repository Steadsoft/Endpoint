using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steadsoft.Spitfire.STM32MP153
{
    public static class SpitfireExtensions
    {
        public static void ThrowIfSeqNullOrEmpty<T>(this IEnumerable<T> sequence, string message) 
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            if (sequence.Any() == false) throw new ArgumentException(message, nameof(sequence));
        }
    }
}
