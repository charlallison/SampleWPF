namespace Domain.model
{
    public class Person
    {
        public Person() { }

        public Person(string firstName, string lastName, string email, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Address Address { get;  set; }
        public virtual string Email { get; set; }
    }
}

