using System.Windows.Controls;

namespace Pharmacy.View
{
    public partial class MedicineCard : UserControl
    {
        public MedicineCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
