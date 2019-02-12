using StudentRecord.ViewModel;
using System.Windows.Controls;

namespace StudentRecord.View
{
    /// <summary>
    /// Interaction logic for AddressControl.xaml
    /// </summary>
    public partial class AddressControl : UserControl
    {
        public AddressControl(AddressControlViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
