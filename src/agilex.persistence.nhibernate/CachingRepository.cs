using System;
using System.Collections.Generic;
using System.Linq;

namespace agilex.persistence.nhibernate
{
    public class CachingRepository : ICachingRepository
    {
        private readonly IRepository _repository;
        private readonly ICacheStrategy _cacheStrategy;

        public CachingRepository(IRepository repository, ICacheStrategy cacheStrategy)
        {
            _repository = repository;
            _cacheStrategy = cacheStrategy;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public int Count<T>() where T : class
        {
            return _repository.Count<T>();
        }


        public T Get<T>(object id) where T : class
        {
            return _cacheStrategy.Get<object, T>(id);
        }

        public bool Exists<T>(int id) where T : class
        {
            return _repository.Exists<T>(id);

        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _repository.GetAll<T>();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _repository.Query<T>();
        }

        public void Save<T>(T entity) where T : class
        {
            _repository.Save(entity);
        }

        public void SaveAndCommit<T>(T entity) where T : class
        {
            _repository.Save(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _repository.Delete(entity);

        }

        public void BeginTransaction()
        {
            _repository.BeginTransaction();
        }

        public void Commit()
        {
            _repository.Commit();
        }

        public void Rollback()
        {
            _repository.Rollback();
        }

        public T GetOrThrowNotFound<T>(object id) where T : class
        {
            return _cacheStrategy.GetOrThrowNotFound<object, T>(id);
        }
    }
}