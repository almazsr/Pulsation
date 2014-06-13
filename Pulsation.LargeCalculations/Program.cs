using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsation.Models;
using Pulsation.Solvers;

namespace Pulsation.LargeCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            PulsationModel model = new PulsationModel
                                       {
                                           CrankNikolson = true,
                                           Turbulent = false,
                                           Implicit = false,
                                           Exact = false,                                           
                                           IsComplexMode = true
                                       };
            int min = -2;
            int max = 2;
            double o = 10;
            for (int degH1=min;degH1<=max;degH1++)
            {
                model.H1 = Math.Pow(o, degH1);
                for (int degH2 = min; degH2 <= max; degH2++)
                {
                    model.H2 = Math.Pow(o, degH2);
                    for (int degH3 = min; degH3 <= max; degH3++)
                    {
                        model.H3 = Math.Pow(o, degH3);
                        PulsationSolver.Solve(model);
                    }
                }
            }
        }
    }
}
