using System;
using System.Linq;
using Calculation.Classes.Algorithms.Common.Extensions;
using Calculation.Classes.Algorithms.TimeDependent;
using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Data;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.Solvers
{
    public class ExactTimeDependentSolver<TData> : Solver
    {
        public void Solve(string name, TData data, Func<double, double, double> fFunc, params IContinue[] continues)
        {
            Bundle bundle = new Bundle(name, data);
            try
            {
                bundle.BeginEdit();
                bundle.Save();

                double t = 0;
                int number = 0;
                var grid = bundle.GetGrid();
                double dt = bundle.dt();

                while (continues.All(c => c.Continue(bundle)))
                {
                    double[] arrayValues = new double[grid.N];

                    for (int i = 0; i < grid.N; i++)
                    {
                        double x = grid[i];
                        arrayValues[i] = fFunc(x, t);
                    }
                    string layerName = GetLayerName(bundle, number);
                    bundle.AddArray(layerName, number, arrayValues);
                    t += dt;
                    number++;
                }
                OnSolved(bundle, true);   
            }
            catch (Exception exception)
            {
                OnSolved(bundle, false, exception);
            }
        } 
    }
}