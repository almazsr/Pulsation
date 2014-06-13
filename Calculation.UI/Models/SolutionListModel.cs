using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calculation.UI.Models
{
    public class SolutionListModel : INotifyPropertyChanged
    {
        public SolutionListModel()
        {
            Solutions = new ObservableCollection<PulsationSolutionItemModel>();
        }

        private ObservableCollection<PulsationSolutionItemModel> _solutions;

        public ObservableCollection<PulsationSolutionItemModel> Solutions
        {
            get { return _solutions; }
            set
            {
                if (!Equals(_solutions, value))
                {
                    _solutions = value;
                    OnPropertyChanged("Solutions");
                    OnSolutionsChanged();
                }
            }
        }

        protected virtual void OnSolutionsChanged()
        {
            if (SolutionsChanged != null)
            {
                SolutionsChanged(this, new EventArgs());
            }
        }

        public event EventHandler SolutionsChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}