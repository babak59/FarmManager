using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Abstract
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        #region Members

        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FindFirstOrDefault(Expression<Func<T, bool>> expression);
        void Save();
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        #endregion
    }
}
