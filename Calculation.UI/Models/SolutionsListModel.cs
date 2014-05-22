using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calculation.UI.Models
{
    public class SolutionsListModel : INotifyPropertyChanged
    {
        public SolutionsListModel()
        {
            Solutions = new ObservableCollection<SolutionItemModel>();
        }

        public SolutionItemModel SelectedItem { get; set; }

        private ObservableCollection<SolutionItemModel> _solutions;

        public ObservableCollection<SolutionItemModel> Solutions
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