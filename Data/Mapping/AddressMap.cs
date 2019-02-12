using Domain.model;
using FluentNHibernate.Mapping;

namespace Data.Mapping
{
    class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Street);
            Map(x => x.Number);
        }
    }
}
