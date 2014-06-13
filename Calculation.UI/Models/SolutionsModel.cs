using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Calculation.UI.Helpers;
using OpenGlExtensions.Classes;
using Pulsation;

namespace Calculation.UI.Models
{
    public class SolutionsModel : INotifyPropertyChanged
    {
        public SolutionsModel(IEnumerable<PulsationSolutionItemModel> solutionItems)
        {
            SolutionItems = solutionItems.Select((si, i) => new SolutionItemColoredModel(si, Pallete.GetColor(i))).ToList();
        }

        public List<SolutionItemColoredModel> SolutionItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SolutionsCurvesModel : SolutionsModel
    {
        public SolutionsCurvesModel(IEnumerable<PulsationSolutionItemModel> solutionItems) 
            : base(solutionItems)
        {
            Curves = new Dictionary<string, Curve2D>();
        }

        public Dictionary<string, Curve2D> Curves { get; set; }
    }

    public class SolutionsCurveGroupsModel : SolutionsModel
    {
        public SolutionsCurveGroupsModel(IEnumerable<PulsationSolutionItemModel> solutionItems) : base(solutionItems)
        {
            CurveGroups = new Dictionary<string, List<Curve2D>>();
        }
        
        public Dictionary<string, List<Curve2D>> CurveGroups { get; set; }
    }

    public class SolutionsTimeDependentModel : SolutionsCurveGroupsModel
    {
        public SolutionsTimeDependentModel(IEnumerable<PulsationSolutionItemModel> solutionItems)
            : base(solutionItems)
        {
            this._count = solutionItems.Min(s => s.CountInPeriod > 0 ? s.CountInPeriod : s.Count);
        }

        public int Step
        {
            get { return PulsationSettings.Default.Step; }
            set
            {
                if (PulsationSettings.Default.Step != value)
                {
                    PulsationSettings.Default.Step = value;
                    OnPropertyChanged("LayersCount");
                    OnLayersCountChanged();
                    OnPropertyChanged("MaxIndex");
                    OnMaxIndexChanged();
                    OnPropertyChanged("Count");
                    OnCountChanged();
                }
            }
        }

        public int MaxIndex
        {
            get { return _count/Step - 1; }
        }

        protected virtual void OnMaxIndexChanged()
        {
            if (MaxIndexChanged != null)
            {
                MaxIndexChanged(this, new EventArgs());
            }
            CurrentLayerIndex = 0;
        }

        public event EventHandler MaxIndexChanged;

        private readonly int _count;

        public int Count
        {
            get { return _count / Step; }
        }

        protected virtual void OnCountChanged()
        {
            if (CountChanged != null)
            {
                CountChanged(this, new EventArgs());
            }
        }

        public event EventHandler CountChanged;

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
    }
}