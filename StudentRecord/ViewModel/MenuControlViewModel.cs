using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Shared;
using StudentRecord.View;
using System.Windows;

namespace StudentRecord.ViewModel
{
    public class MenuControlViewModel : BindableBase
    {
        public MenuControlViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.unityContainer = container;

            ExitCommnad = new DelegateCommand(ExitAction);
            NewRecordCommnad = new DelegateCommand(NewRecordAction);
            ShowAddressViewCommand = new DelegateCommand(ShowAddressesAction);
            ShowStudentViewCommand = new DelegateCommand(ShowStudentsAction);
        }

        private void ExitAction()
        {
            var result = MessageBox.Show("Do you want to exit this application?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void ShowAddressesAction()
        {
            MessageBox.Show("");
        }

        private void ShowStudentsAction()
        {
            MessageBox.Show("");
        }

        private void NewRecordAction()
        {
            var view = regionManager.Regions[RegionNames.ContentRegion].GetView(nameof(DataEntry));
            if (view == null)
            {
                regionManager.Regions[RegionNames.ContentRegion].Add(unityContainer.Resolve<DataEntry>(), nameof(DataEntry));
            }
            regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(DataEntry));
        }

        public DelegateCommand ExitCommnad { get; set; }
        public DelegateCommand NewRecordCommnad { get; set; }
        public DelegateCommand ShowAddressViewCommand { get; set; }
        public DelegateCommand ShowStudentViewCommand { get; set; }

        private IRegionManager regionManager;
        private IUnityContainer unityContainer;
    }
}
