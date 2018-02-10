using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using DAL.IController;
using DAL.Models;

namespace DAL.Controller
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository()
        {
            _context = ApplicationDbContext.Create();
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> Get(Func<T, bool> where,params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include(navigationProperty);
            }
            return dbQuery.AsNoTracking().Where(where).ToList();
        }
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public T Insert(T obj)
        {
            _dbSet.Add(obj);
            Save();
            return obj;
        }
        public bool Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
            return true;
        }
        public bool Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            return true;
        }
        public T Update(T obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
            return obj;
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
