using System.Linq;

namespace BAYSOFT.Abstractions.Core.Domain.Interfaces.Infrastructures.Data
{
	public interface IReader
    {
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    }
}
