namespace agilex.persistence
{
    public interface ISessionEventSubscriber
    {
        void OnFlush(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames);
        void OnPrepareStatement(string sql);
    }
}