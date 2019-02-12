using Data.Repository;
using Domain.model;
using Prism.Commands;
using Prism.Mvvm;
using StudentRecord.Validator;
using System.Linq;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace StudentRecord.ViewModel
{
    public class DataEntryViewModel : BindableBase, IDataErrorInfo
    {
        public DataEntryViewModel()
        {
            Person = new Person();
            rules = new PersonValidator();
            Addresses = new List<Address>(new Repository<Address>().GetAll());
            SaveCommand = new DelegateCommand(SaveAction);
            People = new List<Person>(new Repository<Person>().GetAll());
        }

        private void SaveAction()
        {
             _result = rules.Validate(Person);
            DisplayedError = Error;

            if (_result.IsValid)
            {
                
                if (Person.Id > 0)
                {
                    repository.Update(Person);
                }
                else
                {
                    repository.Add(Person);
                }
                DisplayedError = null;
                repository.Save();
            }
        }

        public string Error {
            get {
                if (_result != null && _result.Errors.Any())
                {
                    var errors = string.Join(Environment.NewLine, _result.Errors.Select(x => x.ErrorMessage).ToArray());
                    return errors;
                }
                return string.Empty;
            }
        }

        public string this[string columnName] {
            get {
                var firstOrDefault = rules.Validate(Person).Errors.FirstOrDefault(x => x.PropertyName == columnName);
                if (firstOrDefault != null)
                    return rules != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }

        private Person person;
        public Person Person {
            get { return person; }
            set { person = value; RaisePropertyChanged(nameof(Person)); }
        }

        private List<Address> addresses;
        public List<Address> Addresses {
            get { return addresses; }
            set { addresses = value; RaisePropertyChanged(nameof(Address)); }
        }

        private string _displayedError;
        public string DisplayedError {
            get => _displayedError;
            set {
                _displayedError = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand SaveCommand { get; set; }
        public List<Person> People { get; set; }

        private ValidationResult _result;
        private PersonValidator rules;
        private Repository<Address> addRepo = new Repository<Address>();
        private Repository<Person> repository = new Repository<Person>();

    }
}
