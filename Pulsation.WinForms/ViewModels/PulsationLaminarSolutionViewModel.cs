using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenGlExtensions.Classes;
using Pulsation.Models;

namespace Pulsation.UI.ViewModels
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