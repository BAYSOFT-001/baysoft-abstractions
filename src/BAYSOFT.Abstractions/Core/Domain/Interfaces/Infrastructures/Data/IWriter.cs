using BAYSOFT.Abstractions.Core.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Interfaces.Infrastructures.Data
{
    public interface IWriter
    {
        public IQueryable<TEntity> Query<TEntity>() where TEntity : DomainEntity;

        public void Add<TEntity>(TEntity entity) where TEntity : DomainEntity;

        public Task AddAsync<TEntity>(TEntity entity) where TEntity : DomainEntity;

        public void AddRange<TEntity>(params TEntity[] entities) where TEntity : DomainEntity;

        public Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : DomainEntity;
        public void Remove<TEntity>(TEntity entity) where TEntity : DomainEntity;
        public void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : DomainEntity;
        public int Commit();
        public Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
