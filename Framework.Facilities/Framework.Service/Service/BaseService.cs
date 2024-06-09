using Framework.Core;
using Framework.Data.Repository;
using Framework.Data.UnitOfWork;

namespace Framework.Service.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity
    {
        public IBaseRepository<TEntity> _repository;

        protected IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
