using System.Linq.Expressions;
using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    #region Constructor
    protected readonly AppDbContext _dbContext;

    private readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    #endregion Constructor

    #region Methods

    public virtual async Task AddAsync(T model, CancellationToken cancellationToken = default)
                => await _dbSet.AddAsync(model, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken = default)
        => await _dbSet.AddRangeAsync(models, cancellationToken);

    public async Task UpdateAsync(T model, CancellationToken cancellationToken = default)
        => await Task.Run(() => _dbSet.Update(model), cancellationToken);

    public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        => await Task.Run(() => _dbSet.UpdateRange(entities), cancellationToken);

    public virtual async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
       => await _dbSet.FirstOrDefaultAsync(filter, cancellationToken);

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(filter, cancellationToken);

    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken = default)
    {
        if (predicate == null)
        {
            return await _dbSet.ToListAsync();
        }

        return await _dbSet.Where(predicate).ToListAsync();
    }

    #endregion Methods
}
