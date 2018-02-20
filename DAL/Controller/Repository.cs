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
        private static ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly object _lockObj=new object();
        public Repository()
        {
            if (_context==null)
            {
                _context = ApplicationDbContext.Create();
            }
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            lock (_lockObj)
            {
                return _dbSet.AsNoTracking().ToList();
            }
        }

        public IEnumerable<T> Get(Func<T, bool> where,params Expression<Func<T, object>>[] navigationProperties)
        {
            lock (_lockObj)
            {
                IQueryable<T> dbQuery = _context.Set<T>();
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                {
                    dbQuery = dbQuery.Include(navigationProperty);
                }
                return dbQuery.AsNoTracking().Where(where).ToList();
            }
        }
        public T GetById(object id)
        {
            lock (_lockObj)
            {
                var entity = _context.Set<T>().Find(id);
                _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
        }
        public T Insert(T obj)
        {
            lock (_lockObj)
            {
                _dbSet.Add(obj);
                Save();
                return obj;
            }
        }
        public bool Delete(object id)
        {
            lock (_lockObj)
            {
                T entityToDelete = _dbSet.Find(id);
                Delete(entityToDelete);
                return true;
            }
        }
        public bool Delete(T entityToDelete)
        {
            lock (_lockObj)
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
                Save();
                return true;
            }
        }
        public T Update(T obj)
        {
            lock (_lockObj)
            {
                var entry = _context.Entry(obj);
                if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Modified; //do it here
                    _context.Set<T>().Attach(obj); //attach
                    Save(); //save it
                }
                return obj;
            }
        }
        public void Save()
        {
            lock (_lockObj)
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
                            Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
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
