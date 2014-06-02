namespace Calculation.Classes.Integrators
{
    public interface IIntegrator
    {
        double GetIntegral(double[] f, double h, int N);
    }
}