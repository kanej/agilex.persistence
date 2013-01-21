namespace agilex.persistence
{
    public interface IAuditRepositoryFactory
    {
        IAuditRepository Instance();
    }
}