using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Pharmacy.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        private ObservableCollection<Medicine> myMedicines { get; set; }
        public ObservableCollection<string> MyCategories { get; set; } = new ObservableCollection<string>();
        private Medicine selectedMedicine;
        private string selectedCategory;
        private string searchName;


        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set { selectedMedicine = value; OnPropertyChanged("SelectedMedicine"); }
        }

        public string SelectedCategory
        {
            get {
                SelectMedicines(true, selectedCategory);
                return  selectedCategory;   }
            set { selectedCategory = value; OnPropertyChanged("SelectedCategory"); }
        }

        public ObservableCollection<Medicine> MyMedicines
        {
            get {return myMedicines;}
            set { myMedicines = value; OnPropertyChanged("MyMedicines"); }
        }

        public string SearchName
        {
            get { return searchName; }
            set { searchName = value; OnPropertyChanged("SearchName"); }
        }

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(Action);

                return addCommand;
            }
        }

        public void Action() 
        {
            SelectMedicines(false, searchName);
        }

        public MainVM()
        {
            using (BDContext context = new BDContext())
            {
                var cat = new ObservableCollection<Category>(context.Categories.ToList());
                foreach (var category in cat)
                    MyCategories.Add(category.CategoryName);
                MyMedicines = new ObservableCollection<Medicine>(context.Medicines.ToList().OrderBy(i => i.Name));
            }
            selectedCategory = MyCategories[0];
            selectedMedicine = MyMedicines[0];
        }


        public void SelectMedicines(bool check, string searchName)
        {
            using (BDContext context = new BDContext())
            {
                if (check)
                {
                    if (searchName == "all")
                        MyMedicines = new ObservableCollection<Medicine>(context.Medicines.ToList().OrderBy(i => i.Name));
                    else
                    {
                        int catId = context.Categories.First(u => u.CategoryName.Equals(searchName)).Id;
                        MyMedicines = new ObservableCollection<Medicine>(context.Medicines.Where(c => c.CategoryId == catId).ToList().OrderBy(i=>i.Name));
                    }
                }
                else
                    MyMedicines = new ObservableCollection<Medicine>(context.Medicines.Where(c => c.Name.Contains(searchName) || c.ShortDescription.Contains(searchName)).ToList().OrderBy(i => i.Name));
            }
            if (MyMedicines.Count > 0)
                selectedMedicine = MyMedicines[0];
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
