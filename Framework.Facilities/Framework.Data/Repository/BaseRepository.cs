using Framework.Core;
using Framework.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Framework.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly IUnitOfWork _unitOfWork;
        public DbSet<TEntity> Entities => _unitOfWork.GetContext().Set<TEntity>();

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Entities.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }
    }
}
