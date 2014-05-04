using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Wolfram.NETLink;

namespace MathExtensions
{
    public static class ExtMath
    {
        public static int NBerBei = 300; 
        private static IKernelLink _mathLink;

        //#region MathLink
        //public static double bei(double x)
        //{
        //    _mathLink.Evaluate(string.Format("KelvinBei[{0:0.000000000}]", x));
        //    _mathLink.WaitForAnswer();
        //    return _mathLink.GetDouble();
        //}

        //public static double ber(double x)
        //{
        //    _mathLink.Evaluate(string.Format("KelvinBer[{0:0.000000000}]", x));
        //    _mathLink.WaitForAnswer();
        //    return _mathLink.GetDouble();
        //} 
        //#endregion

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
                double termi, term = x * x / 4;
                double sum = term * sign;
                for (int i = 1; i <= NBerBei; i++)
                {
                    sign = -sign;
                    termi = Math.Pow((x/(4*i)) * (x/(4*i+2)), 2);
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
                double termi, term = 1;
                double sum = term*sign;
                for (int i = 1; i <= NBerBei; i++)
                {
                    sign = -sign;
                    termi = Math.Pow((x/(4*i)) * (x/(4*i-2)), 2);
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

        public static Dictionary<int, BigInteger> _factorials = new Dictionary<int, BigInteger>();

        public static BigInteger Fact(int n)
        {
            if (!_factorials.ContainsKey(n))
            {
                BigInteger result = 1;
                for (int k = 1; k <= n; k++)
                {
                    result *= k;
                }
                _factorials.Add(n, result);
            }
            return _factorials[n];            
        }

        public static double Norm(double[] a, double[] b)
        {
            return Math.Sqrt(a.Select((t, i) => (t - b[i])*(t - b[i])).Sum());
        } 
    }
}