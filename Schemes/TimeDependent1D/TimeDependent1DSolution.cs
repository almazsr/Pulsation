using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Schemes.TimeDependent1D
{
    public class TimeDependent1DSolution
    {
        internal TimeDependent1DSolution()
        {
            this.tInternal = new List<double>();
            this.LayersInternal = new List<double[]>();
        }

        internal TimeDependent1DSolution(Grid1D grid, double dt)
            : this()
        {
            this.Grid = grid;
            this.dt = dt;
        }

        #region Internal
        internal void Initialize(double[] initialLayer)
        {
            Next();
            AddLayer(initialLayer);
        }

        internal List<double> tInternal { get; set; }

        public List<double[]> LayersInternal { get; set; }

        internal void AddLayer(double[] layer)
        {
            LayersInternal.Add(layer);
        }

        internal void Next()
        {
            tInternal.Add(dt * NTime);
        } 
        #endregion

        #region Public

        public int NTime
        {
            get { return tInternal.Count; }
        }

        public Grid1D Grid { get; set; }

        public double dt { get; set; }

        public double tCurrent
        {
            get { return tInternal[NTime - 1]; }
        }

        public ReadOnlyCollection<double> t
        {
            get { return tInternal.AsReadOnly(); }
        }

        public double[] InitialLayer
        {
            get { return LayersInternal[0]; }
        }

        public double[] CurrentLayer
        {
            get { return LayersInternal.LastOrDefault(); }
        }

        public ReadOnlyCollection<double[]> Layers
        {
            get { return LayersInternal.AsReadOnly(); }
        } 
        #endregion
    }
}