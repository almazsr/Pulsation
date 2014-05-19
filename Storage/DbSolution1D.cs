using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Calculation.Interfaces;
using Newtonsoft.Json;

namespace Storage
{
    public partial class DbSolution1D
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        private DbSolution1D(DbSolutionContext dbContext, DbGrid1D grid, object physicalData, bool isExact = false, bool isTimeDependent = false)
        {
            this.DbContext = dbContext;
            this.DbGridId = grid.Id;
            this.PhysicalData = JsonConvert.SerializeObject(physicalData);
            this.IsExact = isExact;
            this.IsTimeDependent = isTimeDependent;
        }

        /// <summary>
        /// Exact, time undependent.
        /// </summary>
        internal DbSolution1D(DbSolutionContext dbContext, DbGrid1D grid, object physicalData)
            : this(dbContext, grid, physicalData, isExact: true)
        {
                     
        }

        /// <summary>
        /// Exact, time dependent.
        /// </summary>
        internal DbSolution1D(DbSolutionContext dbContext, DbGrid1D grid, object physicalData, double dt)
            : this(dbContext, grid, physicalData, isTimeDependent: true, isExact: true)
        {
            this.dt = dt;
        } 

        /// <summary>
        /// Default numeric constructor.
        /// </summary>
        private DbSolution1D(DbSolutionContext dbContext, DbGrid1D grid, object physicalData, Type solverType, bool isTimeDependent) :
            this(dbContext, grid, physicalData, isTimeDependent: isTimeDependent)
        {
            this.Solver = solverType.FullName;
        }      
        
        /// <summary>
        /// Numeric, time undependent.
        /// </summary>
        internal DbSolution1D(DbSolutionContext dbContext, DbGrid1D grid, object physicalData, Type solverType) :
            this(dbContext, grid, physicalData, solverType, isTimeDependent: false)
        {
        }      

        /// <summary>
        /// Numeric, time dependent.
        /// </summary>
        internal DbSolution1D(DbSolutionContext dbContext, DbGrid1D grid, object physicalData, double dt, Type solverType)
            : this(dbContext, grid, physicalData, solverType, isTimeDependent: true)
        {
            this.dt = dt;
        }

        public ILayer1D GetLayer(int timeIndex)
        {
            return DbContext.GetLayer(this, timeIndex);
        }

        public double GetTime(int timeIndex)
        {
            return timeIndex*dt;
        }

        public void AddLayer(double[] layerValues)
        {
            DbContext.AddLayerToSolution(this, layerValues);
        }

        public void NextTime()
        {
            DbContext.NextTimeSolution(this);
        }

        [NotMapped]
        public IGrid1D Grid
        {
            get { return DbGrid; }
            set
            {
                if (DbGrid == null)
                {
                    DbGrid = new DbGrid1D(value.Min, value.Max, value.N);
                }
            }
        }

        [NotMapped]
        public ILayer1D CurrentLayer
        {
            get { return DbLayers.OrderByDescending(l => l.nt).FirstOrDefault(); }
        }

        [NotMapped]
        public double tCurrent
        {
            get { return dt*Nt; }
        }

        [NotMapped]
        public DbSolutionContext DbContext { get; private set; }
    }
}