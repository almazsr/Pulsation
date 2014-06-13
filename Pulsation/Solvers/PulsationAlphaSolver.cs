using System;
using System.Linq;
using Calculation.Classes.Algorithms.Common.Extensions;
using Calculation.Classes.Algorithms.Common.Integrators;
using Calculation.Classes.Algorithms.Solvers;
using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Data;
using Calculation.Interfaces;
using Pulsation.Models;
using Array = Calculation.Classes.Data.Array;

namespace Pulsation.Solvers
{
    public class PulsationAlphaSolver : Solver
    {
        public void Solve(string name, PulsationAlphaData data)
        {
            using (CalculationDbContext context = new CalculationDbContext())
            {
                var bundle = context.GetBundle(data.GroupId);

                int NPeriod = bundle.PeriodN();

                var grid = bundle.GetGrid();

                var alphaGroup = new Bundle("Нахождение коэффициентов alpha", data);

                int Nt = bundle.GetCount();

                context.SaveChanges();

                try
                {
                    IIntegrator integrator = new SimpsonIntegrator();

                    var lastPeriodLayers = bundle.GetArrays(Nt - NPeriod, NPeriod);
                    int number = 0;
                    for (int deg = 2; deg <= 3; deg++)
                    {
                        double[] alphaValues = new double[NPeriod];
                        for (int i = 0; i < NPeriod; i++)
                        {
                            alphaValues[i] = CalculateAlpha(integrator, deg, lastPeriodLayers[i], grid.Values, grid.h, NPeriod);
                        }
                        alphaGroup.AddArray(string.Format("alpha{0}", number+1), number, alphaValues);
                        number++;
                    }
                    OnSolved(true);
                }
                catch (Exception exception)
                {
                    OnSolved(false, exception);
                }
            }
        }

        public double CalculateAlpha(IIntegrator integrator, int deg, Array layer, double[] r, double h, int N)
        {
            double[] u = layer.Values;

            double uavg = 2 * integrator.GetIntegral(u.Select((uj, j) => uj * r[j]), h, N);

            return 2 * integrator.GetIntegral(u.Select((uj, j) => Math.Pow(uj, deg) * r[j]), h, N) / Math.Pow(uavg, deg);
        }

        protected virtual void OnSolved(bool success, Exception error = null)
        {
            if (Solved != null)
            {
                Solved(this, new SolvedEventArgs {Success = success, Error = error});
            }
        }

        public event SolvedEventHandler Solved;
    }
}