﻿using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Constructor
        protected readonly AppDbContext _dbContext;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        #endregion Constructor

        public virtual async Task AddAsync(T model, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(model, cancellationToken);

        public async Task AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken = default)
            => await _dbSet.AddRangeAsync(models, cancellationToken);

        public async Task UpdateAsync(T model, CancellationToken cancellationToken = default)
            => await Task.Run(() => _dbSet.Update(model), cancellationToken);

        public virtual async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(filter, cancellationToken);

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
            => await _dbSet.AnyAsync(filter, cancellationToken);

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
