using Domain.model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);

            References(x => x.Address);
        }
    }
}
