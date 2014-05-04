using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenGlExtensions.Classes;
using Pulsation.Models;

namespace Pulsation.WinForms.ViewModels
{
    public class PulsationLaminarSolutionViewModel : INotifyPropertyChanged
    {
        public PulsationLaminarSolutionViewModel(double chartPaddingInPercent = 0.1)
        {
            ChartPaddingInPercent = chartPaddingInPercent;
            CurrentLayerIndex = 0;            
            PhysicalData = new PulsationLaminarPhysicalData();
            CalculationData = new PulsationLaminarCalculationData();
            CurveGroups = new Dictionary<string, List<Curve2D>>();
        }

        #region Settings
        private bool _exactSolutionVisible;

        public bool ExactSolutionVisible
        {
            get { return _exactSolutionVisible; }
            set
            {
                if (_exactSolutionVisible != value)
                {
                    _exactSolutionVisible = value;
                    OnPropertyChanged("ExactSolutionVisible");
                    OnExactSolutionVisibleChanged();
                }
            }
        }

        protected virtual void OnExactSolutionVisibleChanged()
        {
            if (ExactSolutionVisibleChanged != null)
            {
                ExactSolutionVisibleChanged(this, new EventArgs());
            }
        }

        public event EventHandler ExactSolutionVisibleChanged;

        private bool _implicitSchemeSolutionVisible;

        public bool ImplicitSchemeSolutionVisible
        {
            get { return _implicitSchemeSolutionVisible; }
            set
            {
                if (_implicitSchemeSolutionVisible != value)
                {
                    _implicitSchemeSolutionVisible = value;
                    OnPropertyChanged("ImplicitSchemeSolutionVisible");
                    OnImplicitSchemeSolutionVisibleChanged();
                }
            }
        }

        protected virtual void OnImplicitSchemeSolutionVisibleChanged()
        {
            if (ImplicitSchemeSolutionVisibleChanged != null)
            {
                ImplicitSchemeSolutionVisibleChanged(this, new EventArgs());
            }
        }

        public event EventHandler ImplicitSchemeSolutionVisibleChanged;

        private bool _crankNikolsonSchemeSolutionVisible;

        public bool CrankNikolsonSchemeSolutionVisible
        {
            get { return _crankNikolsonSchemeSolutionVisible; }
            set
            {
                if (_crankNikolsonSchemeSolutionVisible != value)
                {
                    _crankNikolsonSchemeSolutionVisible = value;
                    OnPropertyChanged("CrankNikolsonSchemeSolutionVisible");
                    OnCrankNikolsonSchemeSolutionVisibleChanged();
                }
            }
        }

        protected virtual void OnCrankNikolsonSchemeSolutionVisibleChanged()
        {
            if (CrankNikolsonSchemeSolutionVisibleChanged != null)
            {
                CrankNikolsonSchemeSolutionVisibleChanged(this, new EventArgs());
            }
        }

        public event EventHandler CrankNikolsonSchemeSolutionVisibleChanged;

        private double _ChartPadding;

        public double ChartPaddingInPercent
        {
            get { return _ChartPadding; }
            set
            {
                if (_ChartPadding != value)
                {
                    _ChartPadding = value;
                    OnPropertyChanged("ChartPaddingInPercent");
                    OnChartPaddingInPercentChanged();
                }
            }
        }

        protected virtual void OnChartPaddingInPercentChanged()
        {
            if (ChartPaddingInPercentChanged != null)
            {
                ChartPaddingInPercentChanged(this, new EventArgs());
            }
        }

        public event EventHandler ChartPaddingInPercentChanged;

        private bool _solved;

        public bool Solved
        {
            get { return _solved; }
            set
            {
                _solved = value;
                OnPropertyChanged("Solved");
                OnSolvedChanged();
            }
        }

        protected virtual void OnSolvedChanged()
        {
            if (SolvedChanged != null)
            {
                SolvedChanged(this, new EventArgs());
            }
        }

        public event EventHandler SolvedChanged;

        public double Angle
        {
            get
            {
                return CalculationData.dAngle*CurrentLayerIndex;
            }
        }

        private int _currentLayerIndex;

        public int CurrentLayerIndex
        {
            get { return _currentLayerIndex; }
            set
            {
                _currentLayerIndex = value;
                OnPropertyChanged("CurrentLayerIndex");
                OnCurrentLayerIndexChanged();
            }
        }

        protected virtual void OnCurrentLayerIndexChanged()
        {
            if (CurrentLayerIndexChanged != null)
            {
                CurrentLayerIndexChanged(this, new EventArgs());
            }
        }

        public event EventHandler CurrentLayerIndexChanged;

        public event PropertyChangedEventHandler PropertyChanged; 

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }  
        #endregion

        public PulsationLaminarPhysicalData PhysicalData { get; set; }

        public PulsationLaminarCalculationData CalculationData { get; set; }

        public Dictionary<string, List<Curve2D>> CurveGroups { get; set; }
    }
}