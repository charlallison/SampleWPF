namespace Domain.model
{
    public class Address
    {
        public Address () {}

        public Address(string streetname, int number)
        {
            Street = streetname;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Number}, {Street}";
        }

        public virtual int Id { get; protected set; }
        public virtual string Street { get; set; }
        public virtual int Number { get; set; }
    }
}
