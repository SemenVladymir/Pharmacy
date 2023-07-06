using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pharmacy.Model
{
    public class Medicine : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string? shortDescription;
        private string? fullDescription;
        private int? categoryId;
        private Category categoryName;
        private string? urlPhoto;
        private string? urlPhoto2;
        private string? urlPhoto3;
        private string? form;
        private int? dosage;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public string ShortDescription
        {
            get { return shortDescription ?? ""; }
            set { shortDescription = value; OnPropertyChanged("ShortDescription"); }
        }

        public string FullDescription
        {
            get { return fullDescription ?? ""; }
            set { fullDescription = value; OnPropertyChanged("FullDescription"); }
        }

        public string UrlPhoto
        {
            get { return urlPhoto ?? ""; }
            set { urlPhoto = value; OnPropertyChanged("UrlPhoto"); }
        }

        public string UrlPhoto2
        {
            get { return urlPhoto2 ?? ""; }
            set { urlPhoto2 = value; OnPropertyChanged("UrlPhoto2"); }
        }

        public string UrlPhoto3
        {
            get { return urlPhoto3 ?? ""; }
            set { urlPhoto3 = value; OnPropertyChanged("UrlPhoto3"); }
        }

        public int CategoryId
        {
            get { return categoryId ?? 0; }
            set { categoryId = value; OnPropertyChanged("CategoryId"); }
        }

        public Category CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; OnPropertyChanged("CategoryName"); }
        }

        public string Form
        {
            get { return form ?? ""; }
            set { form = value; OnPropertyChanged("Form"); }
        }

        public int Dosage
        {
            get { return dosage ?? 0; }
            set { dosage = value; OnPropertyChanged("Dosage"); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
