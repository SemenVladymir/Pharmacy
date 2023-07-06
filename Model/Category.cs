using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pharmacy.Model
{
    public class Category : INotifyPropertyChanged
    {
        private int id;
        private string categoryName;
        private ObservableCollection<Medicine> medicines;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; OnPropertyChanged("CategoryName"); }
        }

        public ObservableCollection<Medicine> Medicines
        {
            get { return medicines; }
            set { medicines = value; OnPropertyChanged("Medicines"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
