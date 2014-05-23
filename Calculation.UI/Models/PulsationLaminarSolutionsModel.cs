using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Calculation.UI.Helpers;
using OpenGlExtensions.Classes;

namespace Calculation.UI.Models
{
    public class PulsationLaminarSolutionsModel : INotifyPropertyChanged
    {
        public PulsationLaminarSolutionsModel(IEnumerable<SolutionItemModel> solutionItems, double chartPaddingInPercent = 0.1)
        {
            CurveGroups = new Dictionary<string, List<Curve2D>>();
            ChartPaddingInPercent = chartPaddingInPercent;

            SolutionItems =
                solutionItems.Select((si, i) => new SolutionItemColoredModel(si, Pallete.GetColor(i))).ToList();
        }

        public Dictionary<string, List<Curve2D>> CurveGroups { get; set; }
        public List<SolutionItemColoredModel> SolutionItems { get; set; }

        public int LayersCount
        {
            get { return AppSettings.Default.LayersCount; }
            set
            {
                if (AppSettings.Default.LayersCount != value)
                {
                    AppSettings.Default.LayersCount = value;
                    OnPropertyChanged("LayersCount");
                    OnLayersCountChanged();
                }
            }
        }

        protected virtual void OnLayersCountChanged()
        {
            if (LayersCountChanged != null)
            {
                LayersCountChanged(this, new EventArgs());
            }
        }

        public event EventHandler LayersCountChanged;

        private int _currentLayerIndex;

        public int CurrentLayerIndex
        {
            get { return _currentLayerIndex; }
            set
            {
                if (_currentLayerIndex != value)
                {
                    _currentLayerIndex = value;
                    OnPropertyChanged("CurrentLayerIndex");
                    OnCurrentLayerIndexChanged();
                }
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

        private double _timeDeg;

        public double TimeDeg
        {
            get { return _timeDeg; }
            set
            {
                if (_timeDeg != value)
                {
                    _timeDeg = value;
                    OnPropertyChanged("TimeDeg");
                    OnTimeDegChanged();
                }
            }
        }

        protected virtual void OnTimeDegChanged()
        {
            if (TimeDegChanged != null)
            {
                TimeDegChanged(this, new EventArgs());
            }
        }

        public event EventHandler TimeDegChanged;

        private double _timeRad;

        public double TimeRad
        {
            get { return _timeRad; }
            set
            {
                if (_timeRad != value)
                {
                    _timeRad = value;
                    OnPropertyChanged("TimeRad");
                    OnTimeRadChanged();
                }
            }
        }

        protected virtual void OnTimeRadChanged()
        {
            if (TimeRadChanged != null)
            {
                TimeRadChanged(this, new EventArgs());
            }
        }

        public event EventHandler TimeRadChanged;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class SolutionsComparisonModel : INotifyPropertyChanged
    {
        public SolutionsComparisonModel(IEnumerable<SolutionItemModel> solutionItems, double chartPaddingInPercent = 0.1)
        {
            CurveGroups = new Dictionary<string, List<Curve2D>>();
            ChartPaddingInPercent = chartPaddingInPercent;
            SolutionItems =
                solutionItems.Select((si, i) => new SolutionItemColoredModel(si, Pallete.GetColor(i))).ToList();
        }

        public Dictionary<string, List<Curve2D>> CurveGroups { get; set; }
        public List<SolutionItemColoredModel> SolutionItems { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}