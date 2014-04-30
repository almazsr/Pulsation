using System;

namespace MathExtensions
{
    public static class Functions
    {
        public const int NBerBei = 2;
        
        public static double bei(double x)
        {
            double sum = 0;
            for (int k = 0; k < NBerBei; k++)
            {
                sum += Math.Pow(-1, k) * Math.Pow(x, 4 * k + 2) / (Math.Pow(2, 4 * k + 2) * Math.Pow(Fact(2 * k + 1), 2));
            }
            return sum;
        }

        public static double ber(double x)
        {
            double sum = 0;
            for (int k = 0; k < NBerBei; k++)
            {
                sum += Math.Pow(-1, k) * Math.Pow(x, 4 * k) / (Math.Pow(2, 4 * k) * Math.Pow(Fact(2 * k), 2));
            }
            return sum;
        } 

        public static int Fact(int n)
        {
            int result = 1;
            for (int k = 1; k <= n; k++)
            {
                result *= k;
            }
            return result;
        }
    }
}
