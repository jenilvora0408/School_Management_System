using System.Linq.Expressions;

namespace DataAccessLayer.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T model, CancellationToken cancellationToken = default);

        Task UpdateAsync(T model, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken = default);

        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

        void UpdateRange(IEnumerable<T> entities);

        Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
