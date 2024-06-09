using Framework.Core;
using Framework.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Framework.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
        IBaseRepository<T> GetRepository<T>() where T : BaseEntity;
        DbContext GetContext();
    }
}