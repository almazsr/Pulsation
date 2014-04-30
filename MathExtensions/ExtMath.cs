using System;
using System.Linq;

namespace MathExtensions
{
    public static class ExtMath
    {
        public const int NBerBei = 10;

        public static double bei(double x)
        {
            double sum = 0;
            for (int k = 0; k < NBerBei; k++)
            {
                sum += Math.Pow(-1, k) * Math.Pow(x, 4 * k + 2) / (Math.Pow(2, 4 * k + 2) * Math.Pow(Fact(2 * k + 1), 2));
            }
            return sum;
        }

        public static long Fact(long n)
        {
            long result = 1;
            for (int k = 1; k <= n; k++)
            {
                result *= k;
            }
            return result;
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

        public static double Norm(double[] a, double[] b)
        {
            return Math.Sqrt(a.Select((t, i) => (t - b[i])*(t - b[i])).Sum());
        }

        public static double[] TriDiag(double[] A, double[] C, double[] B, double[] F, int n)
        {
            double[] alpha = new double[n];
            double[] beta = new double[n];
            alpha[1] = -B[0] / C[0];
            beta[1] = F[0] / C[0];
            for (int i = 1; i < n - 1; i++)
            {
                alpha[i + 1] = -B[i] / (A[i] * alpha[i] + C[i]);
                beta[i + 1] = (F[i] - A[i] * beta[i]) / (A[i] * alpha[i] + C[i]);
            }
            double[] x = new double[n];
            x[n - 1] = (F[n - 1] - A[n - 1] * beta[n - 1]) / (C[n - 1] + A[n - 1] * alpha[n - 1]);
            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = alpha[i + 1] * x[i + 1] + beta[i];
            }
            return x;
        }
    }
}