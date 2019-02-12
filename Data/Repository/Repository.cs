using System.Collections.Generic;
using Domain.model;
using NHibernate;

namespace Data.Repository
{
    public class Repository<T>
    {
        public Repository()
        {
            Session = NhibernateConfiguration.GetSession();
        }

        public void Add(T item)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(item);
            }
        }

        public void Delete(T item)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(item);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public void Update(T item)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Update(item);
            }
        }

        public void Save()
        {
            using (var transaction = Session.BeginTransaction())
            {
                transaction.Commit();
            }
        }

        private ISession Session;
    }
}
