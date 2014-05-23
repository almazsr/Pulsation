using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Calculation.Interfaces;
using Newtonsoft.Json;

namespace Calculation.Database
{
    public class DbSolutionContext : DbContext, IAccessSolutionContext
    {
        public DbSolutionContext() : base("SolutionsConnectionString")
        {           
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<DbSolution1D> Solutions { get; set; }
        public DbSet<DbLayer1D> Layers { get; set; }
        public DbSet<DbGrid1D> Grids { get; set; }

        #region Grid creators
        public IGrid1D CreateGrid(double min, double max, int N)
        {
            var grid = new DbGrid1D(min, max, N);
            Grids.Add(grid);
            return grid;
        } 
        #endregion

        #region Solution creators
        public ISolution1D CreateNumericSolution(IGrid1D grid, object physicalData, Type solverType)
        {
            var solution = new DbSolution1D((DbGrid1D) grid, physicalData, solverType);
            Solutions.Add(solution);
            return solution;            
        }

        public ISolution1D CreateNumericTimeDependentSolution(IGrid1D grid, object physicalData, double dt, Type solverType)
        {
            var solution = new DbSolution1D((DbGrid1D)grid, physicalData, dt, solverType);
            Solutions.Add(solution);
            return solution;   
        }

        public ISolution1D CreateExactSolution(IGrid1D grid, object physicalData)
        {
            var solution = new DbSolution1D((DbGrid1D)grid, physicalData);
            Solutions.Add(solution);
            return solution;   
        }

        public ISolution1D CreateExactTimeDependentSolution(IGrid1D grid, object physicalData, double dt)
        {
            var solution = new DbSolution1D((DbGrid1D)grid, physicalData, dt);
            Solutions.Add(solution);
            return solution;   
        }

        #endregion

        #region Getters

        public IList<ISolution1D> GetSolutions()
        {
            return Solutions.AsEnumerable().Cast<ISolution1D>().ToList();
        }

        public ISolution1D GetSolution(int id)
        {
            return Solutions.FirstOrDefault(s => s.Id == id);
        }

        public ILayer1D GetLayer(int solutionId, int nt)
        {
            return Layers.FirstOrDefault(l => l.DbSolutionId == solutionId && l.nt == nt);
        }

        public IList<ILayer1D> GetAllLayers(int solutionId, int count)
        {
            var result = new List<ILayer1D>();

            var layersQuery = Layers.Where(l => l.DbSolutionId == solutionId);
            int N = layersQuery.Count();
            int timeStep = N / count;

            var firstLayer = layersQuery.FirstOrDefault(l => l.nt == 0);

            result.Add(firstLayer);

            var layers = timeStep > 0
                             ? layersQuery.Where(l => l.nt != 0 && l.nt%timeStep == 0)
                             : layersQuery.Where(l => l.nt != 0);
            result.AddRange(layers);

            return result;
        }

        public List<ILayer1D> GetLayers(int solutionId, int fromTimeIndex, int count)
        {
            var layersQuery = Layers.Where(l => l.DbSolutionId == solutionId && l.nt >= fromTimeIndex).Take(count);
            return layersQuery.AsEnumerable().Cast<ILayer1D>().ToList();
        }

        public object GetPhysicalData(int solutionId)
        {
            var solution = GetSolution(solutionId);
            return JsonConvert.DeserializeObject(solution.PhysicalData);
        }

        public IGrid1D GetGrid(int solutionId)
        {
            var solution = GetSolution(solutionId);
            return solution.Grid;
        }

        public void DeleteSolution(int id)
        {
            var solution = Solutions.FirstOrDefault(s => s.Id == id);
            var layers = Layers.Where(l => l.DbSolutionId == id);
            Layers.RemoveRange(layers);
            Solutions.Remove(solution);
        }

        public IGrid1D GetGrid(string name)
        {
            return Grids.FirstOrDefault(g => g.Name == name);
        }
        #endregion
    }
}