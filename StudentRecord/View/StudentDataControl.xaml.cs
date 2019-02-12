using StudentRecord.ViewModel;

namespace StudentRecord.View
{
    /// <summary>
    /// Interaction logic for DataEntry.xaml
    /// </summary>
    public partial class StudentDataEntry
    {
        public StudentDataEntry(StudentDataViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
