using System.Linq.Expressions;
using Entities.DTOs;
using Entities.DTOs.Common;

namespace DataAccessLayer.Interface;

public interface IBaseRepository<T> where T : class
{
    Task AddAsync(T model, CancellationToken cancellationToken = default);

    Task AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken = default);

    Task UpdateAsync(T model, CancellationToken cancellationToken = default);

    Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken = default);

    Task<PageListResponseDTO<T>> GetAllAsync(PageListRequestDTO<T> pageListRequest, Expression<Func<T, bool>>? predicate = null);
}
