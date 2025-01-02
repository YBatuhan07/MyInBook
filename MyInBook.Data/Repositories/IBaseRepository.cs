using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyInBook.Data.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    IQueryable<T> Queryable(Expression<Func<T, bool>> expression);
}
