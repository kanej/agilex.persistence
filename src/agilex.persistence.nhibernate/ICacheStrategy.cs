namespace agilex.persistence.nhibernate
{
    public interface ICacheStrategy
    {
        TCacheType Get<TCacheId, TCacheType>(TCacheId id) where TCacheType : class;
        TCacheType GetOrThrowNotFound<TCacheId, TCacheType>(TCacheId id) where TCacheType : class;
    }
}