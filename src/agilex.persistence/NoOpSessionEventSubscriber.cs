namespace agilex.persistence
{
    public class NoOpSessionEventSubscriber : ISessionEventSubscriber
    {
        public void OnSave(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames)
        {
        }

        public void OnPrepareStatement(string sql)
        {
        }

        public void OnDelete(object entity, object id, object[] currentState, string[] propertyNames)
        {    
        }

        public void OnCreate(object entity, object id, object[] currentState, string[] propertyNames)
        {
        }
    }
}