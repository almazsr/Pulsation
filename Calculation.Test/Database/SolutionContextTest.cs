using System;
using Calculation.Classes.Schemes;
using Calculation.Database;
using Calculation.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Calculation.Test.Database
{
    [TestClass]
    public class SolutionContextTest
    {
        [TestMethod]
        public void CreateGridTest()
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                double min = 0;
                double max = 1;
                int N = 100;
                double h = 0.01;
                string name = string.Format(DbGrid1D.NameFormat, min, max, N);

                db.CreateGrid(min, max, N);
                var grid = db.GetGrid(name);

                Assert.IsNotNull(grid);
                Assert.AreEqual(min, grid.Min);
                Assert.AreEqual(max, grid.Max);
                Assert.AreEqual(h, grid.h);
                Assert.AreEqual(N, grid.N);
                Assert.AreEqual(name, ((DbGrid1D)grid).Name);
            }
        }

        [TestMethod]
        public void CreateExactSolutionTest()
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                double min = 0;
                double max = 1;
                int N = 100;

                var grid = db.CreateGrid(min, max, N);
                var physicalData = new {x = 0, y = 0, z = 0};
                var solution = db.CreateExactSolution(grid, physicalData);

                Assert.IsNotNull(solution);
                Assert.AreEqual(true, solution.IsExact);
                Assert.AreEqual(false, solution.IsTimeDependent);
                Assert.AreEqual(0, solution.dt);
                Assert.AreEqual(0, solution.Nt);
                Assert.AreEqual(0, solution.tCurrent);
                Assert.AreEqual(JsonConvert.SerializeObject(physicalData), solution.PhysicalData);
                Assert.AreEqual(null, solution.SolverType);
                Assert.AreEqual(null, solution.StartedAt);
                Assert.AreEqual(SolutionState.None, solution.State);
            }
        }

        [TestMethod]
        public void CreateNumericSolutionTest()
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                double min = 0;
                double max = 1;
                int N = 100;
                Type solverType = typeof (DiffusionCrankNicolsonCylindricScheme1D);

                var grid = db.CreateGrid(min, max, N);
                var physicalData = new { x = 0, y = 0, z = 0 };
                var solution = db.CreateNumericSolution(grid, physicalData, solverType);

                Assert.IsNotNull(solution);
                Assert.AreEqual(false, solution.IsExact);
                Assert.AreEqual(false, solution.IsTimeDependent);
                Assert.AreEqual(0, solution.dt);
                Assert.AreEqual(0, solution.Nt);
                Assert.AreEqual(0, solution.tCurrent);
                Assert.AreEqual(JsonConvert.SerializeObject(physicalData), solution.PhysicalData);
                Assert.AreEqual(solverType.ToString(), solution.SolverType);
                Assert.AreEqual(null, solution.StartedAt);
                Assert.AreEqual(SolutionState.None, solution.State);
            }
        }


        [TestMethod]
        public void CreateNumericTimeDependentSolutionTest()
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                double min = 0;
                double max = 1;
                int N = 100;
                double dt = 0.01;
                Type solverType = typeof(DiffusionCrankNicolsonCylindricScheme1D);

                var grid = db.CreateGrid(min, max, N);
                var physicalData = new { x = 0, y = 0, z = 0 };
                var solution = db.CreateNumericTimeDependentSolution(grid, physicalData, dt, solverType);

                Assert.IsNotNull(solution);
                Assert.AreEqual(false, solution.IsExact);
                Assert.AreEqual(true, solution.IsTimeDependent);
                Assert.AreEqual(dt, solution.dt);
                Assert.AreEqual(0, solution.Nt);
                Assert.AreEqual(0, solution.tCurrent);
                Assert.AreEqual(JsonConvert.SerializeObject(physicalData), solution.PhysicalData);
                Assert.AreEqual(solverType.ToString(), solution.SolverType);
                Assert.AreEqual(null, solution.StartedAt);
                Assert.AreEqual(SolutionState.None, solution.State);

                solution.Start();

                Assert.AreEqual(SolutionState.InProcess, solution.State);

                solution.NextTime();

                Assert.AreEqual(dt, solution.dt);
                Assert.AreEqual(1, solution.Nt);
                Assert.AreEqual(dt, solution.tCurrent);
            }
        }

        [TestMethod]
        public void CreateExactTimeDependentSolutionTest()
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                double min = 0;
                double max = 1;
                int N = 100;
                double dt = 0.01;

                var grid = db.CreateGrid(min, max, N);
                var physicalData = new { x = 0, y = 0, z = 0 };
                var solution = db.CreateExactTimeDependentSolution(grid, physicalData, dt);

                Assert.IsNotNull(solution);
                Assert.AreEqual(true, solution.IsExact);
                Assert.AreEqual(true, solution.IsTimeDependent);
                Assert.AreEqual(dt, solution.dt);
                Assert.AreEqual(0, solution.Nt);
                Assert.AreEqual(0, solution.tCurrent);
                Assert.AreEqual(JsonConvert.SerializeObject(physicalData), solution.PhysicalData);
                Assert.AreEqual(null, solution.SolverType);
                Assert.AreEqual(null, solution.StartedAt);
                Assert.AreEqual(SolutionState.None, solution.State);

                solution.Start();

                Assert.AreEqual(SolutionState.InProcess, solution.State);

                solution.NextTime();

                Assert.AreEqual(dt, solution.dt);
                Assert.AreEqual(1, solution.Nt);
                Assert.AreEqual(dt, solution.tCurrent);
            }
        }

        [TestMethod]
        public void AddLayerToSolutionTest()
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                double min = 0;
                double max = 1;
                int N = 100;
                double dt = 0.01;

                var grid = db.CreateGrid(min, max, N);
                var physicalData = new {x = 0, y = 0, z = 0};
                var solution = db.CreateExactTimeDependentSolution(grid, physicalData, dt);

                solution.Start();
                int n = 100;
                int m = 10;
                for (int i = 0; i < n;i++ )
                {                    
                    solution.NextTime();
                }

                Assert.AreEqual(dt, solution.dt);
                Assert.AreEqual(n, solution.Nt);
                Assert.AreEqual(n*dt, solution.tCurrent);

                var layers = db.GetSeparatedLayers((int)solution.Key, m);
                Assert.IsNotNull(layers);
                Assert.AreEqual(m, layers.Count);

                for (int i = 0; i < m; i++)
                {
                    Assert.AreEqual(layers[i].nt, i*(n/m));
                }
            }
        }
    }
}
