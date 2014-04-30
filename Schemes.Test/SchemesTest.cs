using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schemes.Classes;
using Schemes.Classes.Schemes;
using Schemes.Enums;
using Schemes.TimeDependent1D;

namespace Schemes.Test
{
    [TestClass]
    public class SchemesTest
    {
        [TestMethod]
        public void DiffusionCylindricSchemeTest()
        {
            Func<double, double, double> rightPart = (r, t) => r-t/r;
            DiffusionCylindricScheme scheme = new DiffusionCylindricScheme(0);
            scheme.TMax = 2*Math.PI;
            Grid1D grid = Grid1D.Build(1, 2, 100);
            double[] ut0 = new double[grid.N];
            for (int i = 0; i < grid.N; i++)
            {
                ut0[i] = 0;
            }            
            var solution =scheme.Solve(grid, new[]
                                   {
                                       new BoundaryCondition(t => 1-t, BoundaryConditionLocation.Left,
                                                             BoundaryConditionType.Dirichlet),
                                       new BoundaryCondition(t=>2-t/2, BoundaryConditionLocation.Right,
                                                             BoundaryConditionType.Dirichlet)
                                   }, ut0, 1E-3);
            Func<double, double, double> uExact = (r, t) => r*t;
            int n = 0;
            foreach (var layer in solution.Layers)
            {
                for (int i=0; i<grid.N; i++)
                {
                    double r = grid[i];
                    double t = solution.dt*n;
                    double uExacti = uExact(r, t);
                    double uNumerici = layer[i];
                    Assert.AreEqual(uExacti, uNumerici);
                }
                n++;
            }
        }
    }
}
