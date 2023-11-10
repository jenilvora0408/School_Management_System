using System.Linq.Expressions;

namespace BusinessAccessLayer.Interface
{
    public interface IGenericService<T> where T : class
    {
        Task AddAsync(T model, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken = default);

        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity);
    }
}
