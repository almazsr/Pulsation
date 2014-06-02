using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculation.Interfaces;

namespace Calculation.Classes
{
    public static class SolutionExtensions
    {
        public static void FillExact(this ISolution1D solution, Func<double, double, double> f,
                                     IEnumerable<IStopCondition> stopConditions)
        {
            try
            {
                solution.Start();
                while (stopConditions.All(c => !c.IsFinish(solution)))
                {
                    var grid = solution.Grid;
                    double t = solution.tCurrent;
                    double[] layerValues = new double[grid.N];
                    for (int i = 0; i < grid.N; i++)
                    {
                        double x = grid[i];
                        layerValues[i] = f(x, t);
                    }
                    solution.AddLayer(layerValues);
                    solution.NextTime();
                }
                solution.Finish(true);
            }
            catch (Exception exception)
            {
                solution.Finish(false);
            }
        }

        public static async void FillExactAsync(this ISolution1D solution, Func<double, double, double> f,
                                                IEnumerable<IStopCondition> stopConditions)
        {
            await Task.Run(() => solution.FillExact(f, stopConditions));
        }
    }
}