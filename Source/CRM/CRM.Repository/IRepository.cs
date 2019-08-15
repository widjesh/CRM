using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(Expression<Func<T, bool>> predicate, string includeProperties = null);
        Task<IList<T>> GetList(Expression<Func<T, bool>> predicate, string includeProperties = null);
        Task<T> Update(T t);
        Task<T> Save(T t);
        Task Delete(T t);
    }
}
