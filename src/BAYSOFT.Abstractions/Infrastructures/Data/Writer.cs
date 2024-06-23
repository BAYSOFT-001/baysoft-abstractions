using BAYSOFT.Abstractions.Core.Domain.Interfaces.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using N.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Infrastructures.Data
{
	public class Writer: IWriter
    {
        public DbContext Context { get; private set; }
        public Writer(DbContext context)
        {
            Context = context;
        }
        public virtual IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().AsQueryable();
        }
        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
		{
            Context.Set<TEntity>().Add(entity);
        }
        public virtual Task AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
            return Context.Set<TEntity>().AddAsync(entity).AsTask();
        }
        public virtual void AddRange<TEntity>(params TEntity[] entities) where TEntity : class
		{
            Context.Set<TEntity>().AddRange(entities);
        }
        public virtual Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
		{
            return Context.Set<TEntity>().AddRangeAsync(entities);
        }
        public virtual void Remove<TEntity>(TEntity entity) where TEntity : class
		{
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class
		{
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public virtual int Commit()
        {
            return Context.SaveChanges();
        }
        public virtual Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
		}
		public IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql) where TEntity : class
		{
			return Context.Set<TEntity>().FromSqlInterpolated(sql);
		}
		public int ExecuteSqlRaw(string sql, params object[] parameters)
		{
			return Context.Database.ExecuteSqlRaw(sql, parameters);
		}
		public void BulkMerge<TEntity>(List<TEntity> entities) where TEntity : class
		{
			Context.BulkMerge<TEntity>(entities);
		}
		public void BulkMerge<TEntity>(List<TEntity> entities, Action<BulkMergeOptions<TEntity>> options) where TEntity : class
		{
			Context.BulkMerge<TEntity>(entities, options);
		}
		public void BulkInsert<TEntity>(List<TEntity> entities) where TEntity : class
		{
			Context.BulkInsert<TEntity>(entities);
		}
		public void BulkDelete<TEntity>(List<TEntity> entities) where TEntity : class
		{
			Context.BulkDelete<TEntity>(entities);
		}
	}
}