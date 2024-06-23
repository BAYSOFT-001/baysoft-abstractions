using N.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Interfaces.Infrastructures.Data
{
	public interface IWriter
    {
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        public void Add<TEntity>(TEntity entity) where TEntity : class;

        public Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        public void AddRange<TEntity>(params TEntity[] entities) where TEntity : class;

        public Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class;
        public void Remove<TEntity>(TEntity entity) where TEntity : class;
        public void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class;
        public int Commit();
        public Task<int> CommitAsync(CancellationToken cancellationToken = default);
        public IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql) where TEntity : class;
        public int ExecuteSqlRaw(string sql, params object[] parameters);
		public void BulkMerge<TEntity>(List<TEntity> entities) where TEntity : class;
		public void BulkMerge<TEntity>(List<TEntity> entities, Action<BulkMergeOptions<TEntity>> options) where TEntity : class;
		public void BulkInsert<TEntity>(List<TEntity> entities) where TEntity : class;
		public void BulkDelete<TEntity>(List<TEntity> entities) where TEntity : class;
	}
}
