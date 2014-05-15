using System;
using Calculation.Enums;
using Calculation.Interfaces;
using Storage.Logic;

namespace Storage.Database
{
    public class DbFactory : IFactory
    {
        public IGrid1D CreateGrid(double min, double max, int N)
        {
            var grid = new DbGrid1D
                       {
                           Min = min,
                           Max = max,
                           N = N,
                           h = (max - min)/N,
                           Name = string.Format("[{0:0.##}, {1:0.##}]({2})", min, max, N)
                       };
            return EntityLogic.Insert(grid);
        }

        public ISolution1D CreateSolution(IGrid1D grid, double timeStep)
        {
            var dbGrid = grid as DbGrid1D;
            if (dbGrid == null)
            {
                throw new ArgumentException("Invalid grid type.", "grid");
            }
            var solution = new DbSolution1D
                               {
                                   DbGridId = dbGrid.Id,                                   
                                   TimeStep = timeStep,
                                   State = SolutionState.None
                               };
            return EntityLogic.Insert(solution);
        }
    }
}