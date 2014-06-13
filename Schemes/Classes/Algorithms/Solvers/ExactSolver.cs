using System;
using Calculation.Classes.Algorithms.Common.Extensions;
using Calculation.Classes.Data;

namespace Calculation.Classes.Algorithms.Solvers
{
    public class ExactSolver<TData> : Solver
    {
        public void Solve(string name, TData data, params Func<double, double>[] fFuncs)
        {
            Bundle bundle = new Bundle(name, data);
            try
            {
                bundle.BeginEdit();
                bundle.Save();

                int number = 0;
                var grid = bundle.GetGrid();

                foreach (var func in fFuncs)
                {
                    double[] arrayValues = new double[grid.N];

                    for (int i = 0; i < grid.N; i++)
                    {
                        double x = grid[i];
                        arrayValues[i] = func(x);
                    }
                    string layerName = GetLayerName(bundle, number);
                    bundle.AddArray(layerName, number, arrayValues);
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