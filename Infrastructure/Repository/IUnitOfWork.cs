
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
