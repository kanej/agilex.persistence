using System;
using System.Collections.Generic;

namespace agilex.persistence
{
    public interface IAuditRepository
    {
        IEnumerable<V> FindRevisionHistory<T,V>(object id);
        IEnumerable<T> FindRevisions<T>(object id);
        T Get<T>(object id, long revisionNumber);

    }
}