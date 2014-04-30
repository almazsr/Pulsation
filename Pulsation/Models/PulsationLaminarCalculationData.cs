using System;
using System.ComponentModel;
using Schemes.TimeDependent1D;

namespace Pulsation.Models
{
    public class PulsationLaminarCalculationData : INotifyPropertyChanged
    {
        public PulsationLaminarCalculationData(double tMax = DefaultTMax, double gridMin = DefaultGridMin, double gridMax = DefaultGridMax, int dAngle = DefaultAngle, int nGrid = DefaultNGrid)
        {
            this.dAngle = dAngle;
            this.TMax = tMax;
            this.NGrid = nGrid;
            this.GridMin = gridMin;
            this.GridMax = gridMax;            
            RebuildGrid();
        }

        #region Constants

        public const double DefaultTMax = 2*Math.PI;
        public const double DefaultGridMin = 0;
        public const double DefaultGridMax = 1;

        public const int DefaultAngle = 30;
        public const int DefaultNTime = 100;
        public const int DefaultNGrid = 100;
        #endregion

        #region Methods
        protected void RebuildGrid()
        {
            Grid = Grid1D.Build(GridMin, GridMax, NGrid);
        } 
        #endregion

        #region Properties

        private double _tMax;

        public double TMax
        {
            get { return _tMax; }
            set
            {
                if (_tMax != value)
                {
                    _tMax = value;
                    OnPropertyChanged("TMax");
                    OnTMaxChanged();
                    OnPropertyChanged("NTime"); 
                }
            }
        }

        protected virtual void OnTMaxChanged()
        {
            if (TMaxChanged != null)
            {
                TMaxChanged(this, new EventArgs());
            }
        }

        public event EventHandler TMaxChanged;

        private double _gridMin;

        public double GridMin
        {
            get { return _gridMin; }
            set
            {
                if (_gridMin != value)
                {
                    _gridMin = value;
                    OnPropertyChanged("GridMin");
                    OnGridMinChanged();
                    OnPropertyChanged("h"); 
                }
            }
        }

        protected virtual void OnGridMinChanged()
        {
            if (GridMinChanged != null)
            {
                GridMinChanged(this, new EventArgs());
            }
        }

        public event EventHandler GridMinChanged;

        private double _gridMax;

        public double GridMax
        {
            get { return _gridMax; }
            set
            {
                if (_gridMax != value)
                {
                    _gridMax = value;
                    OnPropertyChanged("GridMax");
                    OnGridMaxChanged();
                    OnPropertyChanged("h");     
                }
            }
        }

        protected virtual void OnGridMaxChanged()
        {
            if (GridMaxChanged != null)
            {
                GridMaxChanged(this, new EventArgs());
            }
        }

        public event EventHandler GridMaxChanged;

        #region NTime

        public int NTime
        {
            get { return (int) (TMax/dt); }
        }

        protected virtual void OnNTimeChanged()
        {
            if (NTimeChanged != null)
            {
                NTimeChanged(this, new EventArgs());
            }
        }

        public event EventHandler NTimeChanged;
        #endregion

        public Grid1D Grid { get; set; }

        public double h
        {
            get { return (GridMax - GridMin)/(NGrid - 1); }
        }

        private int _dAngle;

        public int dAngle
        {
            get { return _dAngle; }
            set
            {
                if (_dAngle != value)
                {
                    _dAngle = value;
                    OnPropertyChanged("dAngle");
                    OndAngleChanged();
                    OnPropertyChanged("tau");
                    OnPropertyChanged("NTime");
                }
            }
        }

        protected virtual void OndAngleChanged()
        {
            if (dAngleChanged != null)
            {
                dAngleChanged(this, new EventArgs());
            }
        }

        public event EventHandler dAngleChanged;

        public double dt
        {
            get { return Math.PI*dAngle/180; }
        }

        private int _nGrid;

        public int NGrid
        {
            get { return _nGrid; }
            set
            {
                if (_nGrid != value)
                {
                    _nGrid = value;
                    OnPropertyChanged("NGrid");
                    OnNGridChanged();
                    RebuildGrid();
                }
            }
        }

        protected virtual void OnNGridChanged()
        {
            if (NGridChanged != null)
            {
                NGridChanged(this, new EventArgs());
            }
        }

        public event EventHandler NGridChanged;
        #endregion 

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}