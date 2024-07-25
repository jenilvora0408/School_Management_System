using System.Linq.Expressions;
using Common.Constants;
using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DTOs;
using System.Linq.Dynamic.Core;
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

    public async Task<PageListResponseDTO<T>> GetAllAsync(PageListRequestEntity<T> pageListRequest)
    {
        IQueryable<T> query = _dbSet.AsQueryable();

        if (pageListRequest.IncludeExpressions != null)
        {
            query = pageListRequest.IncludeExpressions.Aggregate(query, (current, include) =>
            {
                return current.Include(include);
            });
        }

        if (pageListRequest.ThenIncludeExpressions != null)
        {
            query = pageListRequest.ThenIncludeExpressions.Aggregate(query, (current, thenInclude) =>
            {
                return current.Include(thenInclude);
            });
        }

        if (pageListRequest.Selects != null)
            query = query.Select(pageListRequest.Selects);

        if (pageListRequest.Predicate != null)
        {
            query = query.Where(pageListRequest.Predicate);
        }

        if (!string.IsNullOrEmpty(pageListRequest.SortColumn))
        {
            string sortExpression = pageListRequest.SortColumn.Trim();

            string sortOrder = pageListRequest.SortOrder.Trim().ToLower();

            if (string.IsNullOrEmpty(sortOrder) || !sortOrder.Equals(SystemConstants.ASCENDING))
                sortOrder = SystemConstants.DESCENDING;

            string dynamicSortExpression = $"{sortExpression} {sortOrder}";

            query = query.OrderBy(dynamicSortExpression);
        }

        int totalRecords = await query.CountAsync();

        List<T>? records = await query
        .Skip((pageListRequest.PageIndex - 1) * pageListRequest.PageSize)
        .Take(pageListRequest.PageSize)
        .ToListAsync();

        return new PageListResponseDTO<T>(pageListRequest.PageIndex, pageListRequest.PageSize, totalRecords, records);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[]? includes = null, string[]? thenIncludes = null, Expression<Func<T, T>>? selects = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbSet.AsQueryable();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) =>
            {
                return current.Include(include);
            });
        }

        if (thenIncludes != null)
        {
            query = thenIncludes.Aggregate(query, (current, thenInclude) =>
            {
                return current.Include(thenInclude);
            });
        }

        query = query.Where(expression);

        if (selects != null)
            query = query.Select(selects);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    #endregion Methods
}
