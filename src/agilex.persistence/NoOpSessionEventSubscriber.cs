namespace agilex.persistence
{
    public class NoOpSessionEventSubscriber : ISessionEventSubscriber
    {
        public void OnFlush(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames)
        {
        }

        public void OnPrepareStatement(string sql)
        {
        }
    }
}