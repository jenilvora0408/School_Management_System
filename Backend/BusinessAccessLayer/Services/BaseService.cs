using System.Linq.Expressions;
using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DTOs;
using Entities.DTOs.Common;

namespace BusinessAccessLayer.Services;

public class BaseService<T> : IBaseService<T> where T : class
{
    #region Constructor

    private readonly IBaseRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public BaseService(IBaseRepository<T> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    #region Methods

    public async virtual Task AddAsync(T model, CancellationToken cancellationToken = default)
    {
        await _repository.AddAsync(model, cancellationToken);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken = default)
        => await _repository.AddRangeAsync(models, cancellationToken);

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _repository.UpdateAsync(entity, cancellationToken));
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entitities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _repository.UpdateRangeAsync(entitities, cancellationToken));
        await _unitOfWork.SaveAsync();
    }

    public async virtual Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
       => await _repository.GetFirstOrDefaultAsync(filter, cancellationToken);

    public async virtual Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        => await _repository.AnyAsync(filter, cancellationToken);

    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => await _repository.GetByIdAsync(id, cancellationToken);

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken = default)
        => await _repository.GetAllAsync(predicate, cancellationToken);

    public async Task<PageListResponseDTO<T>> GetAllAsync(PageListRequestDTO<T> pageListRequest, Expression<Func<T, bool>>? predicate = null)
       => await _repository.GetAllAsync(pageListRequest, predicate);


    #endregion
}
