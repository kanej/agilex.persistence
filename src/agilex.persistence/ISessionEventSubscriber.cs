namespace agilex.persistence
{
    public interface ISessionEventSubscriber
    {
        void OnSave(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames);
        void OnPrepareStatement(string sql);
        void OnDelete(object entity, object id, object[] currentState, string[] propertyNames);
        void OnCreate(object entity, object id, object[] currentState, string[] propertyNames);
    }
}