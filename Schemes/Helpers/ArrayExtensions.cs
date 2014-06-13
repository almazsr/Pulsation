using System;
using System.Linq;
using Array = Calculation.Classes.Data.Array;

namespace Calculation.Helpers
{
    public static class ArrayExtensions
    {
        public static double NormInf(this double[] array)
        {
            return array.Select(Math.Abs).Max();
        }

        public static double Norm1(this double[] array)
        {
            return array.Select(Math.Abs).Sum();
        }

        public static double Norm2(this double[] array)
        {
            return Math.Sqrt(array.Select(t => t*t).Sum());
        }

        public static double[] Subtract(this Array array1, Array array2)
        {
            return array1.Values.Select((t, i) => t - array2.Values[i]).ToArray();
        }
    }
}