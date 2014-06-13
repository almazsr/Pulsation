using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Calculation.Enums;
using Calculation.Exceptions;

namespace Calculation.Classes.Data
{
    public partial class Bundle
    {
        #region Constructors
        static Bundle()
        {
            MaxBufferSize = CalculationSettings.Default.BundleMaxBufferSize;
        }

        public Bundle()
        {
            this.ArraysBuffer = new List<Array>();
            this.Parameters = new Collection<Parameter>();
        }

        public Bundle(string name, object data, bool isSequence = false)
            : this()
        {
            this.IsSequence = isSequence;
            this.Name = name;

            AttachData(data);
        } 
        #endregion

        #region Context options
        public void Save()
        {
            if (!EditMode) throw new BundleNotInEditModeException();
            Context.Bundles.Add(this);
            Context.SaveChanges();
        }

        public void BeginEdit()
        {
            this.EditMode = true;
            this._connection = CalculationDbContext.CreateConnection();
            this.Context = new CalculationDbContext(_connection); 
        }

        public void EndEdit(bool success)
        {
            if (!EditMode) throw new BundleNotInEditModeException();
            if (success)
            {
                Commit();
            }
            else
            {
                Rollback();
            }
        }

        [NotMapped]
        internal CalculationDbContext Context { get; set; }

        private void RecreateContext()
        {
            Context.Dispose();
            Context = new CalculationDbContext(_connection);
        }

        #region Transaction
        [NotMapped]
        private DbConnection _connection;

        [NotMapped]
        private DbTransaction _transaction;

        private void Commit()
        {
            if (ArraysBuffer.Any())
            {
                Context.Arrays.AddRange(ArraysBuffer);
                Context.SaveChanges();
                ArraysBuffer.Clear();
            }
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction = null;
            }
        }

        private void Rollback()
        {
            if (_transaction != null)
            {
                this._transaction.Rollback();
                this._transaction = null;
            }
            if (Context != null)
            {
                this.Context.Dispose();
                this.Context = null;
            }
            if (_connection != null)
            {
                this._connection.Dispose();
                this._connection = null;
            }
            this.EditMode = false;
        } 
        #endregion

        internal bool EditMode { get; private set; }

        #endregion

        #region Arrays

        [NotMapped]
        internal readonly static int MaxBufferSize = 100;

        protected internal int _count;

        public int GetCount()
        {
            return EditMode ? _count : Context.Arrays.Count(arr => arr.BundleId == Id);
        }

        public Array GetArray(int number)
        {
            var array = Arrays.FirstOrDefault(arr => arr.BundleId == Id && arr.Number == number);
            return array ?? ArraysBuffer.FirstOrDefault(arr => arr.Number == number);
        }

        public List<Array> GetArrays(int fromNumber, int count)
        {
            var dbArraysQuery = Arrays.Where(arr => arr.BundleId == Id && arr.Number >= fromNumber).Take(count);
            return dbArraysQuery.AsEnumerable().Concat(ArraysBuffer).ToList();
        }

        public virtual Array AddArray(string name, int number, double[] values)
        {
            if (!EditMode) throw new BundleNotInEditModeException();
            var array = new Array(name, number, values, Id);
            ArraysBuffer.Add(array);
            if (ArraysBuffer.Count >= MaxBufferSize)
            {
                Commit();
                RecreateContext();
            }
            _count++;
            return array;
        }

        [NotMapped]
        protected internal List<Array> ArraysBuffer { get; private set; }

        public List<Array> GetSeparatedArrays(int step)
        {
            var result = new List<Array>();
            var arraysQuery = Arrays.Where(arr => arr.BundleId == Id);
            var firstArray = arraysQuery.FirstOrDefault(arr => arr.Number == 0);
            result.Add(firstArray);
            var layers = arraysQuery.Where(arr => arr.Number != 0 && arr.Number % step == 0);
            result.AddRange(layers);
            return result;
        }

        public List<Array> GetSeparatedArrays(int fromNumber, int count, int step)
        {
            var result = new List<Array>();

            var arraysQuery = Arrays.Where(arr => arr.BundleId == Id && arr.Number >= fromNumber).Take(count);

            var firstLayer = arraysQuery.FirstOrDefault(arr => arr.Number == fromNumber);

            result.Add(firstLayer);

            var layers = arraysQuery.Where(arr => arr.Number != fromNumber && (arr.Number - fromNumber) % step == 0);
            result.AddRange(layers);

            return result;
        }

        public List<Array> GetAllArrays()
        {
            var arraysQuery = Arrays.Where(arr => arr.BundleId == Id);
            return arraysQuery.ToList();
        }
        #endregion

        #region Parameters
        private void AttachData(object data)
        {
            Type type = data.GetType();
            var parameterProperties = GetParameterProperties(type);
            foreach (var property in parameterProperties)
            {
                AddParameter(property.Name, property.GetValue(data));
            }
        }

        private IEnumerable<PropertyInfo> GetParameterProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(
                    p => p.GetCustomAttribute<ParameterAttribute>() != null);
        }

        public void AddParameter(string name, object value)
        {
            Parameter parameter = new Parameter { Name = name };
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
            Parameters.Add(parameter);
        }

        public object Parameter(Type type, string name)
        {
            var parameter = Parameters.FirstOrDefault(p => p.Name == name);
            object result = null;
            if (parameter != null)
            {
                if (type == typeof(string))
                {
                    result = parameter.StringValue;
                }
                if (type == typeof(int))
                {
                    result = parameter.IntValue;
                }
                if (type == typeof(double))
                {
                    result = parameter.DoubleValue;
                }
            }
            return result;
        }

        public T Parameter<T>(string name)
        {
            var result = Parameter(typeof (T), name);
            return (T) (result ?? default(T));
        }

        public TData GetData<TData>() where TData : class
        {
            Type type = typeof(TData);
            var parameterProperties = GetParameterProperties(type);
            TData result = Activator.CreateInstance<TData>();
            foreach (var property in parameterProperties)
            {
                object value = Parameter(property.PropertyType, property.Name);
                if (property.SetMethod != null)
                {
                    property.SetValue(result, value);
                }
            }
            return result;
        } 
        #endregion
    }
}