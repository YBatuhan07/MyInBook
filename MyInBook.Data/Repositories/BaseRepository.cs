using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace MyInBook.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly MyInBookDatabaseContext _context;
    private DbSet<T> _dbSet => _context.Set<T>();
    public BaseRepository(MyInBookDatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        var result = await _dbSet.ToListAsync();
        return result;
    }
    public async Task<T> GetAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public IQueryable<T> Queryable(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
}
