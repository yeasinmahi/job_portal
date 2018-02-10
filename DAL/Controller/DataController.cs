using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Controller
{
    public class DataController<T> where T : class
    {
        private static Repository<T> _repository;
        public static IEnumerable<T> GetAll()
        {
            _repository = new Repository<T>();
            return _repository.GetAll();
        }
        public static IEnumerable<T> Get(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            _repository = new Repository<T>();
            return _repository.Get(where,navigationProperties);
        }

        public static T GetById(object id)
        {
            _repository = new Repository<T>();
            return _repository.GetById(id);
        }
        public static T Insert(T obj)
        {
            _repository = new Repository<T>();
            return _repository.Insert(obj);
        }
        public static bool Delete(object id)
        {
            _repository = new Repository<T>();
            return _repository.Delete(id);
        }
        public static bool Delete(T obj)
        {
            _repository = new Repository<T>();
            return _repository.Delete(obj);
        }
        public static T Update(T obj)
        {
            _repository = new Repository<T>();
            return _repository.Update(obj);
        }
    }
}
