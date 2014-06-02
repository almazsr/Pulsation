using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Calculation.Enums;
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
            this.Context = new DbSolutionContext();
            this.LayersBuffer = new List<DbLayer1D>();
            this.DbGridId = grid.Id;
            this.PhysicalData = JsonConvert.SerializeObject(physicalData);
            this.IsExact = isExact;
            this.IsTimeDependent = isTimeDependent;
        }

        public const string GridFormatTemplate = "[{0},{1}](N={2})(d={3})";
        public const string TimeDataFormatTemplate = "[{0}](N={1})(d={2})";

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
            this.SolverType = solverType.Name;
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

        [NotMapped]
        public DbSolutionContext Context { get; set; }

        public void SetPeriod(int periodNt)
        {
            IsPeriodic = true;
            PeriodNt = periodNt;
        }

        public ILayer1D GetLayer(int nt)
        {
            return Context.GetLayer(Id, nt);
        }

        public List<ILayer1D> GetLayers(int fromTimeIndex, int count)
        {
            LayersBuffer = LayersBuffer ?? new List<DbLayer1D>();
            var dbLayers = Context.GetLayers(Id, fromTimeIndex, count - LayersBuffer.Count);
            return dbLayers.Concat(LayersBuffer).ToList();
        }

        public double GetTime(int nt)
        {
            return nt*dt;
        }

        public void AddLayer(double[] layerValues)
        {            
            var layer = new DbLayer1D(layerValues, this);
            LayersBuffer.Add(layer); 
            CurrentLayer = layer;
            if (LayersBuffer.Count >= MaxBufferSize)
            {
                CommitLayers();
                RecreateContext();
            }
        }

        private void CommitLayers()
        {
            Context.Layers.AddRange(LayersBuffer);
            Context.SaveChanges();
            LayersBuffer.Clear();
        }

        private void RecreateContext()
        {
            Context.Dispose();
            Context = new DbSolutionContext();
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
        public ILayer1D CurrentLayer { get; private set; }

        [NotMapped]
        public double tCurrent
        {
            get { return dt*Nt; }
        }

        [NotMapped]
        internal static int MaxBufferSize = 100;

        public void Start()
        {
            AttachIfNot();
            StartedAt = DateTime.Now;
            State = SolutionState.InProcess;
            Context.SaveChanges();
            if (Started != null)
            {
                Started(this, new EventArgs());
            }
        }

        public void AttachIfNot()
        {
            var entry = Context.Entry(this);
            if (entry.State == EntityState.Detached)
            {
                Context.Solutions.Attach(this);
            }
        }

        public void Finish(bool success)
        {
            if (LayersBuffer != null && LayersBuffer.Any())
            {
                CommitLayers();
            }
            State = success ? SolutionState.Success : SolutionState.Failed;
            var dbSolution = Context.GetSolution(Id) as DbSolution1D;
            if (dbSolution != null)
            {
                dbSolution.State = State;
                dbSolution.Nt = Nt;
            }
            Context.SaveChanges();
            if (Finished != null)
            {
                Finished(this, new EventArgs());
            }
        }

        public void NextTime()
        {
            Nt++;
        }

        [NotMapped]
        public List<DbLayer1D> LayersBuffer { get; private set; }

        public event EventHandler Started;
        public event EventHandler Finished;
    }
}