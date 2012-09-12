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

        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _sessionEventSubscriber.OnDelete(entity, id, state ?? new object[] { }, propertyNames ?? new string[] { });            
            base.OnDelete(entity, id, state, propertyNames, types);
        }

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _sessionEventSubscriber.OnCreate(entity, id, state ?? new object[] { }, propertyNames ?? new string[] { });
            return base.OnSave(entity, id, state, propertyNames, types);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _sessionEventSubscriber.OnSave(entity, id, currentState ?? new object[] { }, previousState ?? new object[] { }, propertyNames ?? new string[] { });
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }

        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            _sessionEventSubscriber.OnPrepareStatement(sql.ToString()); 
            return base.OnPrepareStatement(sql);

        }

    }
}