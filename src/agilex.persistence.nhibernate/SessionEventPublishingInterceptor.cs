using NHibernate;

namespace agilex.persistence.nhibernate
{
    public class SessionEventPublishingInterceptor : EmptyInterceptor
    {
        readonly ISessionEventSubscriber _sessionEventSubscriber;

        public SessionEventPublishingInterceptor(ISessionEventSubscriber sessionEventSubscriber)
        {
            _sessionEventSubscriber = sessionEventSubscriber;
        }

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _sessionEventSubscriber.OnFlush(entity, id, state, null, propertyNames);
            return base.OnSave(entity, id, state, propertyNames, types);
        }
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _sessionEventSubscriber.OnFlush(entity, id, currentState, previousState, propertyNames);
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }

        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            _sessionEventSubscriber.OnPrepareStatement(sql.ToString()); 
            return base.OnPrepareStatement(sql);

        }

    }
}