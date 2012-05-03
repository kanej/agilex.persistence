using NHibernate;
using agilex.persistence.Repository.Callbacks;

namespace agilex.persistence.nhibernate
{
    public class RepositoryFactory : IRepositoryFactory
    {
        readonly ISessionFactory _sessionFactory;

        public RepositoryFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IRepository Instance()
        {
            return new Repository(_sessionFactory.OpenSession());
        }

        public IRepository Instance(IRepositoryCallbacks callbacks)
        {
            return new Repository(_sessionFactory.OpenSession());
        }
    }
}