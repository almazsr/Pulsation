namespace Calculation.Classes.Integrators
{
    public class SimpsonIntegrator : IIntegrator
    {
        public double GetIntegral(double[] f, double h, int N)
        {
            double result = 0;
            for (int k = 1; k < N - 1; k += 2)
            {
                result += f[k - 1] + 4 * f[k] + f[k + 1];
            }
            result *= h / 3;
            return result;
        } 
    }

    public class TrapezoidalIntegrator : IIntegrator
    {
        public double GetIntegral(double[] f, double h, int N)
        {
            double result = (f[0] + f[N - 1])/2;
            for (int k = 1; k < N - 1; k++)
            {
                result += f[k];
            }
            result *= h;
            return result;
        }
    }
}