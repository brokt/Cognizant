using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity
    {
        T Add(T entity);
        List<T> Add(List<T> entity);
        T Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<T> Query();
        TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null);
        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);
        int GetCount(Expression<Func<T, bool>> expression = null);

    }
}
