using Data.Repository;
using Domain.model;

namespace Data
{
    public class Provider
    {
        static Provider()
        {
            new NhibernateConfiguration();
            addressRepository = new Repository<Address>();
            studentRepository = new Repository<Person>();
        }

        public Repository<Address> GetAddressRepository()
        {
            return addressRepository;
        }

        public Repository<Person> GetPersonRepository()
        {
            return studentRepository;
        }

        static Repository<Address> addressRepository;
        static Repository<Person> studentRepository;

    }
}
