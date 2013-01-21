using NHibernate;

namespace agilex.persistence.nhibernate
{
    public class AuditRepositoryFactory : IAuditRepositoryFactory
    {        
        readonly ISessionFactory _sessionFactory;

        public AuditRepositoryFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        public IAuditRepository Instance()
        {
            return new AuditRepository(_sessionFactory.OpenSession());
        }
    }
}