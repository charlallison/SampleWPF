using Data.Repository;
using Domain.model;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace StudentRecord.ViewModel
{
    public class AddressControlViewModel : BindableBase//, IDataErrorInfo
    {
        public AddressControlViewModel()
        {
            SaveCommand = new DelegateCommand(SaveAction);
            Address = new Address();
            Addresses = new ObservableCollection<Address>(AddressRepository.GetAll());
        }

        private void SaveAction()
        {
            AddressRepository.AddNewOrExisiting(Address);
            AddressRepository.Save();
            Addresses.Add(Address);
        }

        private Address address;
        public Address Address {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        private ObservableCollection<Address> addresses;
        public ObservableCollection<Address> Addresses {
            get { return addresses; }
            set { addresses = value; RaisePropertyChanged(nameof(Addresses)); }
        }

        public DelegateCommand SaveCommand { get; }

        //public string Error => throw new System.NotImplementedException();

        //public string this[string columnName] => throw new System.NotImplementedException();

        private Repository<Address> AddressRepository {
            get { return ServiceLocator.Current.GetInstance<Repository<Address>>(); }
        }
    }
}
