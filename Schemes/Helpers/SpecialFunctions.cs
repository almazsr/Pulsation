using System;

namespace Calculation.Helpers
{
    public class SpecialFunctions
    {
        public static int NBerBei = 300;
        #region Functions
        public static double bei(double x)
        {
            if (x == 0)
            {
                return 0;
            }
            else
            {
                int sign = 1;
                double term = x * x / 4;
                double sum = term * sign;
                for (int i = 1; i <= NBerBei; i++)
                {
                    sign = -sign;
                    double termi = Math.Pow((x / (4 * i)) * (x / (4 * i + 2)), 2);
                    term = term * termi;
                    sum += sign * term;
                    if (Math.Abs(term / sum) < 1E-12)
                    {
                        break;
                    }
                }
                return sum;
            }
        }

        public static double ber(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                int sign = 1;
                double term = 1;
                double sum = term * sign;
                for (int i = 1; i <= NBerBei; i++)
                {
                    sign = -sign;
                    double termi = Math.Pow((x / (4 * i)) * (x / (4 * i - 2)), 2);
                    term = term * termi;
                    sum += sign * term;
                    if (Math.Abs(term / sum) < 1E-12)
                    {
                        break;
                    }
                }
                return sum;
            }
        }
        #endregion 
    }
}