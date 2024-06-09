using Data;
using Framework.Core;
using Framework.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected POCContext dbContext;
        protected IServiceProvider _serviceProvider;
        public UnitOfWork(POCContext context,
            IServiceProvider serviceProvider)
        {
            dbContext = context;
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public IBaseRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return _serviceProvider.GetRequiredService<IBaseRepository<T>>();
        }

        public DbContext GetContext()
        {
            return dbContext;
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}