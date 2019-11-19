using Domain.Abstract;
using Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IBaseEntity
    {
        #region Properties

        protected FarmManagerDbContext ManageFarmDbContext { get; set; }

        #endregion
        #region Constructors

        public RepositoryBase(FarmManagerDbContext manageFarmDbContext)
        {
            ManageFarmDbContext = manageFarmDbContext;
        }

        #endregion
        #region Members

        public IEnumerable<T> FindAll()
        {
            return ManageFarmDbContext.Set<T>().ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return ManageFarmDbContext.Set<T>().Where(expression);
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return ManageFarmDbContext.Set<T>().FirstOrDefault(expression);
        }

        public void Save()
        {
            ManageFarmDbContext.SaveChangesAsync();
        }

        public T Add(T entity)
        {
            ManageFarmDbContext.Set<T>().Add(entity);
            Save();

            return entity;
        }

        public T Update(T entity)
        {
            ManageFarmDbContext.Set<T>().Update(entity);
            Save();

            return entity;
        }

        public void Delete(T entity)
        {
            ManageFarmDbContext.Set<T>().Remove(entity);
            Save();
        }

        #endregion
    }
}
