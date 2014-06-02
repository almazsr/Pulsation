using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Calculation.UI.Helpers;
using OpenGlExtensions.Classes;

namespace Calculation.UI.Models
{
    public class SolutionsModel : INotifyPropertyChanged
    {
        public SolutionsModel(IEnumerable<SolutionItemModel> solutionItems)
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
        public SolutionsCurvesModel(IEnumerable<SolutionItemModel> solutionItems) 
            : base(solutionItems)
        {
            Curves = new Dictionary<string, Curve2D>();
        }

        public Dictionary<string, Curve2D> Curves { get; set; }
    }

    public class SolutionsCurveGroupsModel : SolutionsModel
    {
        public SolutionsCurveGroupsModel(IEnumerable<SolutionItemModel> solutionItems) : base(solutionItems)
        {
            CurveGroups = new Dictionary<string, List<Curve2D>>();
        }
        
        public Dictionary<string, List<Curve2D>> CurveGroups { get; set; }
    }

    public class SolutionsTimeDependentModel : SolutionsCurveGroupsModel
    {
        public SolutionsTimeDependentModel(IEnumerable<SolutionItemModel> solutionItems)
            : base(solutionItems)
        {
        }

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
    }
}