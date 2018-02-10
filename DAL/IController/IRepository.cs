using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.IController
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetById(object sl);
        T Insert(T obj);
        bool Delete(object sl);
        T Update(T obj);
        void Save();
    }
}
