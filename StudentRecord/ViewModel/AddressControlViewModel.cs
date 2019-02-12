using Data.Repository;
using Domain.model;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;

namespace StudentRecord.ViewModel
{
    public class AddressControlViewModel : BindableBase, IDataErrorInfo
    {
        public AddressControlViewModel()
        {
            SaveCommand = new DelegateCommand(SaveAction);
        }

        private void SaveAction()
        {
            var address = new Address(Street, Number);
            AddressRepository.Add(address);
            AddressRepository.Save();
        }

        private int number;
        public int Number {
            get { return number; }
            set { SetProperty(ref number, value); }
        }

        private string street;
        public string Street {
            get { return street; }
            set { street = value; RaisePropertyChanged(nameof(Street)); }
        }

        private List<Address> addresses;
        public List<Address> Addresses {
            get { return addresses; }
            set { addresses = value; RaisePropertyChanged(nameof(Addresses)); }
        }

        public DelegateCommand SaveCommand { get; }

        public string Error => throw new System.NotImplementedException();

        public string this[string columnName] => throw new System.NotImplementedException();

        private Repository<Address> AddressRepository {
            get { return ServiceLocator.Current.GetInstance<Repository<Address>>(); }
        }
    }
}
