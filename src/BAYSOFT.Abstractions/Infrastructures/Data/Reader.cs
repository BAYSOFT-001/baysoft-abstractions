using BAYSOFT.Abstractions.Core.Domain.Interfaces.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BAYSOFT.Abstractions.Infrastructures.Data
{
	public class Reader: IReader
    {
        public DbContext Context { get; private set; }
        public Reader(DbContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> Query<TEntity>() where TEntity : class
		{
            return Context.Set<TEntity>().AsQueryable().AsNoTracking();
		}
	}
}
