using agilex.persistence.Repository.Callbacks;

namespace agilex.persistence
{
    public interface IRepositoryFactory
    {
        IRepository Instance();
        IRepository Instance(IRepositoryCallbacks callbacks);
    }
}