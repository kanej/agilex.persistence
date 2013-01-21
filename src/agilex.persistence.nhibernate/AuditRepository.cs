using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Envers;

namespace agilex.persistence.nhibernate
{
    public class AuditRepository : IAuditRepository
    {
        private readonly IAuditReader _auditReader;

        public AuditRepository(ISession session)
        {
            _auditReader = AuditReaderFactory.Get(session);
        }

        public IEnumerable<V> FindRevisionHistory<T, V>(object id)
        {
            var revisionNumbers = _auditReader.GetRevisions(typeof(T).FullName, id);
            return _auditReader.FindRevisions<V>(revisionNumbers).Values;
        }

        public IEnumerable<T> FindRevisions<T>(object id)
        {
            var revisionNumbers = _auditReader.GetRevisions(typeof (T).FullName, id);
            return revisionNumbers.Select(revisionNumber => _auditReader.Find<T>(id, revisionNumber));
        }

        public T Get<T>(object id, long revisionNumber)
        {
            return _auditReader.Find<T>(id, revisionNumber);
        }
    }
}