using StudentRecord.ViewModel;

namespace StudentRecord.View
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl
    {
        public MenuControl(MenuControlViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
