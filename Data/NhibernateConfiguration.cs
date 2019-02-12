using Data.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Data
{
    class NhibernateConfiguration
    {
        static NhibernateConfiguration()
        {
            sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration
                .Standard.ConnectionString($@"Data Source={AppDomain.CurrentDomain.BaseDirectory}\data.db;Version=3"))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<AddressMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        internal static ISession GetSession()
        {
            return sessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Create(true, false);
        }

        static ISessionFactory sessionFactory;
    }
}
