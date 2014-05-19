using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Calculation.Enums;
using Calculation.Interfaces;
using Newtonsoft.Json;

namespace Storage
{
    public class DbSolutionContext : DbContext, IAccessSolutionContext
    {
        public DbSolutionContext() : base("SolutionsConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbSolutionContext>());
        }

        public DbSet<DbSolution1D> Solutions { get; set; }
        public DbSet<DbLayer1D> Layers { get; set; }
        public DbSet<DbGrid1D> Grids { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (ChangeTracker.HasChanges())
            {
                SaveChanges();
            }
        }

        #region Grid creators
        public IGrid1D CreateGrid(double min, double max, int N)
        {
            var grid = new DbGrid1D(min, max, N);
            Grids.Add(grid);
            SaveChanges();
            return grid;
        } 
        #endregion

        #region Solution creators
        public ISolution1D CreateNumericSolution(IGrid1D grid, object physicalData, Type solverType)
        {
            return SaveSolution(new DbSolution1D(this, (DbGrid1D)grid, physicalData, solverType));
        }

        public ISolution1D CreateNumericTimeDependentSolution(IGrid1D grid, object physicalData, double dt, Type solverType)
        {
            return SaveSolution(new DbSolution1D(this, (DbGrid1D)grid, physicalData, dt, solverType));
        }

        public ISolution1D CreateExactSolution(IGrid1D grid, object physicalData)
        {
            return SaveSolution(new DbSolution1D(this, (DbGrid1D)grid, physicalData));
        }

        public ISolution1D CreateExactTimeDependentSolution(IGrid1D grid, object physicalData, double dt)
        {
            return SaveSolution(new DbSolution1D(this, (DbGrid1D)grid, physicalData, dt));
        } 
        #endregion

        #region Private savers into DB.
        private DbSolution1D SaveSolution(DbSolution1D solution)
        {
            Solutions.Add(solution);
            return solution;
        }

        private DbLayer1D SaveLayer(DbLayer1D layer)
        {
            Layers.Add(layer);
            return layer;
        }
        #endregion

        #region Solution updaters
        public void StartSolution(ISolution1D solution)
        {
            var dbSolution = GetSolution(solution.Key) as DbSolution1D;
            if (dbSolution != null)
            {
                dbSolution.Started = DateTime.Now;
                dbSolution.State = SolutionState.InProcess;
                dbSolution.NextTime();
            }
        }

        public void NextTimeSolution(ISolution1D solution)
        {
            var dbSolution = GetSolution(solution.Key) as DbSolution1D;
            if (dbSolution != null)
            {
                dbSolution.Nt++;
                SaveChanges();
            }
        } 
        #endregion

        #region Add layer
        public ILayer1D AddLayerToSolution(ISolution1D solution, double[] layerValues)
        {
            var dbSolution = GetSolution(solution.Key) as DbSolution1D;
            if (dbSolution != null)
            {
                SaveSolution(dbSolution);
            }
            return SaveLayer(new DbLayer1D(layerValues, (DbSolution1D)solution));
        } 
        #endregion

        #region Getters

        public IList<ISolution1D> GetSolutions()
        {
            return Solutions.AsEnumerable().Cast<ISolution1D>().ToList();
        }

        public ISolution1D GetSolution(object id)
        {
            return Solutions.FirstOrDefault(s => s.Id == (int)id);
        }

        public ILayer1D GetLayer(ISolution1D solution, int nt)
        {
            return Layers.FirstOrDefault(l => l.DbSolutionId == (int)solution.Key && l.nt == nt);
        }

        public IList<ILayer1D> GetLayers(ISolution1D solution, int count)
        {
            var result = new List<ILayer1D>();

            var layersQuery = Layers.Where(l => l.DbSolutionId == (int)solution.Key);
            int N = layersQuery.Count();
            int timeStep = N / count;

            var firstLayer = Layers.OrderBy(l => l.nt).FirstOrDefault();
            result.Add(firstLayer);

            var layers = Layers.Where(l => l.DbSolutionId == (int)solution.Key && l.nt % timeStep == 0);
            result.AddRange(layers);

            return result;
        }

        public object GetPhysicalData(ISolution1D solution)
        {
            return JsonConvert.DeserializeObject(solution.PhysicalData);
        }

        public IGrid1D GetGrid(ISolution1D solution)
        {
            var dbSolution = Solutions.FirstOrDefault(s => s.Id == (int)solution.Key);
            if (dbSolution != null)
            {
                return dbSolution.DbGrid;
            }
            return null;
        } 
        #endregion
    }
}