using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Calculation.Database.Helpers;
using Calculation.Interfaces;
using Newtonsoft.Json;

namespace Calculation.Database
{
    public partial class DbSolution1D
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        private DbSolution1D(DbGrid1D grid, object physicalData, bool isExact = false, bool isTimeDependent = false)
        {
            LayersBuffer = new List<ILayer1D>();
            this.DbGridId = grid.Id;
            this.PhysicalData = JsonConvert.SerializeObject(physicalData);
            this.IsExact = isExact;
            this.IsTimeDependent = isTimeDependent;
        }

        /// <summary>
        /// Exact, time undependent.
        /// </summary>
        internal DbSolution1D(DbGrid1D grid, object physicalData)
            : this(grid, physicalData, isExact: true)
        {
                     
        }

        /// <summary>
        /// Exact, time dependent.
        /// </summary>
        internal DbSolution1D(DbGrid1D grid, object physicalData, double dt)
            : this(grid, physicalData, isTimeDependent: true, isExact: true)
        {
            this.dt = dt;
        } 

        /// <summary>
        /// Default numeric constructor.
        /// </summary>
        private DbSolution1D(DbGrid1D grid, object physicalData, Type solverType, bool isTimeDependent) :
            this(grid, physicalData, isTimeDependent: isTimeDependent)
        {
            this.Solver = solverType.FullName;
        }      
        
        /// <summary>
        /// Numeric, time undependent.
        /// </summary>
        internal DbSolution1D(DbGrid1D grid, object physicalData, Type solverType) :
            this(grid, physicalData, solverType, isTimeDependent: false)
        {
        }      

        /// <summary>
        /// Numeric, time dependent.
        /// </summary>
        internal DbSolution1D(DbGrid1D grid, object physicalData, double dt, Type solverType)
            : this(grid, physicalData, solverType, isTimeDependent: true)
        {
            this.dt = dt;
        }

        public ILayer1D GetLayer(int nt)
        {
            return DbAccess.GetLayer(this, nt);
        }

        public double GetTime(int nt)
        {
            return nt*dt;
        }

        public void AddLayer(double[] layerValues)
        {            
            DbLayer1D layer = new DbLayer1D(layerValues, this);
            if (LayersBuffer.Count < LayersBufferMaxSize)
            {
                LayersBuffer.Add(layer);
            }
            else
            {
                DbAccess.SaveLayers(LayersBuffer);
                LayersBuffer.Clear();
            }
        }

        public void NextTime()
        {
            DbAccess.SolutionNextTime(this);
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
            get { return DbAccess.GetLayer(this, Nt - 1); }
        }

        [NotMapped]
        public double tCurrent
        {
            get { return dt*Nt; }
        }

        [NotMapped]
        internal int LayersBufferMaxSize = 10;

        [NotMapped]
        internal List<DbLayer1D> LayersBuffer { get; set; }
    }
}