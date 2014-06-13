using System;
using System.Linq;

namespace Calculation.Helpers
{
    internal class Convert
    {
        internal static double[] ToDoubles(byte[] bytes)
        {
            return Enumerable.Range(0, bytes.Length / sizeof(double))
                .Select(offset => BitConverter.ToDouble(bytes, offset * sizeof(double)))
                .ToArray();
        }

        internal static byte[] ToBytes(double[] values)
        {
            return values.SelectMany(BitConverter.GetBytes).ToArray();
        }     
    }
}