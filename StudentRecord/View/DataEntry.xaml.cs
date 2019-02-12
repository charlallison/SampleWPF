using StudentRecord.ViewModel;

namespace StudentRecord.View
{
    /// <summary>
    /// Interaction logic for DataEntry.xaml
    /// </summary>
    public partial class DataEntry
    {
        public DataEntry(DataEntryViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
