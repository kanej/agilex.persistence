using System.Collections.Generic;

namespace agilex.persistence.nhibernate
{
    public class CacheStrategy : ICacheStrategy
    {
        readonly Dictionary<object, object> _cache = new Dictionary<object, object>();
        private readonly IRepository _repository;

        public CacheStrategy(IRepository repository)
        {
            _repository = repository;
        }
        public TCacheType Get<TCacheId, TCacheType>(TCacheId id) where TCacheType : class
        {
            return Holds<TCacheId, TCacheType>(id) ?? Add(id, _repository.Get<TCacheType>(id));
        }

        public TCacheType GetOrThrowNotFound<TCacheId, TCacheType>(TCacheId id) where TCacheType : class
        {
            return Holds<TCacheId, TCacheType>(id) ?? Add(id, _repository.GetOrThrowNotFound<TCacheType>(id));
        }

        private TCacheType Holds<TCacheId, TCacheType>(TCacheId id) where TCacheType : class
        {
            return _cache.ContainsKey(id) ? _cache[id] as TCacheType : null;
        }

        private TCacheType Add<TCacheId, TCacheType>(TCacheId id, TCacheType obj) where TCacheType : class
        {
            lock (_cache)
            {
                if (!_cache.ContainsKey(id))
                    _cache.Add(id, obj);

            }
            return obj;
        }
    }
}