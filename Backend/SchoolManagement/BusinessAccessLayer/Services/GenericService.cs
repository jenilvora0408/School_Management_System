using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using System.Linq.Expressions;

namespace BusinessAccessLayer.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        #region Constructor

        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
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

        public async virtual Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
       => await _repository.GetFirstOrDefaultAsync(filter, cancellationToken);

        public async virtual Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
            => await _repository.AnyAsync(filter, cancellationToken);

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _repository.UpdateRange(entities);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
