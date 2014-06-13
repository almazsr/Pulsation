using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Calculation.Enums;
using Calculation.Interfaces;
using Newtonsoft.Json;

namespace Calculation.Database
{
    public partial class DbGroup
    {
        public DbGroup()
        {
            this.Context = new DbSolutionContext();
            this.ArraysBuffer = new List<DbArray>();
        }

        public DbGroup(object data)
        {
            Type type = data.GetType();
            var parameterProperties =
                type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(
                    p => p.GetCustomAttribute<ParameterAttribute>() != null);
            foreach (var property in parameterProperties)
            {
                AddParameter(property.Name, property.GetValue(data));
            }
        }

        [NotMapped]
        public DbSolutionContext Context { get; set; }

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
            var dbSolution = Context.GetSolution(Id) as DbGroup1D;
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
        public List<DbArray> ArraysBuffer { get; private set; }

        public void AddParameter(string name, object value)
        {
            DbParameter parameter = new DbParameter { Name = name };
            if (value is string)
            {
                parameter.StringValue = (string)value;
                parameter.Type = ParameterType.String;
            }
            if (value is double)
            {
                parameter.DoubleValue = (double)value;
                parameter.Type = ParameterType.Double;
            }
            if (value is int)
            {
                parameter.IntValue = (int)value;
                parameter.Type = ParameterType.Int;
            }
            DbParameters.Add(parameter);
        }

        public Dictionary<string, object> Parameters
        {
            get
            {
                return DbParameters.ToDictionary(p => p.Name, p =>
                                                                  {
                                                                      switch (p.Type)
                                                                      {
                                                                          case ParameterType.Int:
                                                                              return (object)p.IntValue;
                                                                              case ParameterType.Double:
                                                                              return (object)p.DoubleValue;
                                                                              case ParameterType.String:
                                                                              return (object)p.StringValue;
                                                                          default:
                                                                              return null;
                                                                      }
                                                                  });
            }
        }
    }
}