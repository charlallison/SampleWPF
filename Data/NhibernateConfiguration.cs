using Data.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;

namespace Data
{
    class NhibernateConfiguration
    {
        static readonly string dbFilePath;

        static NhibernateConfiguration()
        {
            dbFilePath = $@"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)}\data.db";

            sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration
                .Standard.UsingFile(dbFilePath))
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
            new SchemaExport(configuration).Create(true, !File.Exists(dbFilePath));
        }

        static ISessionFactory sessionFactory;
    }
}
