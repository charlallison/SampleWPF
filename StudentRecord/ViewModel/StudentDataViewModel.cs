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
using Microsoft.Practices.ServiceLocation;
using System.Reflection;

namespace StudentRecord.ViewModel
{
    public class StudentDataViewModel : BindableBase, IDataErrorInfo
    {
        public StudentDataViewModel()
        {
            Person = new Person();
            rules = new PersonValidator();
            Addresses = new List<Address>(AddressRepository.GetAll());
            SaveCommand = new DelegateCommand(SaveAction);
            People = new List<Person>(StudentRepository.GetAll());

            
        }

        private void SaveAction()
        {
            _result = rules.Validate(Person);
            DisplayedError = Error;

            if (_result.IsValid)
            {

                if (Person.Id > 0)
                {
                    StudentRepository.Update(Person);
                }
                else
                {
                    StudentRepository.Add(Person);
                }
                DisplayedError = null;
                StudentRepository.Save();
                Person = new Person();
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

        Repository<Address> AddressRepository {
            get { return ServiceLocator.Current.GetInstance<Repository<Address>>(); }
        }

        Repository<Person> StudentRepository {
            get { return ServiceLocator.Current.GetInstance<Repository<Person>>(); }
        }

    }
}
