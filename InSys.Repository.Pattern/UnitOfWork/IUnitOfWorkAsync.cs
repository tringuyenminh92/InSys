using System.Threading;
using System.Threading.Tasks;
using InSys.Repository.Pattern.Infrastructure;
using InSys.Repository.Pattern.Repositories;

namespace InSys.Repository.Pattern.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}