using BAYSOFT.Abstractions.Core.Domain.Entities;
using MediatR;
using System;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Interfaces.Services
{
	public interface IDomainService<TKey, TEntity>
		where TEntity : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
        Task Run(TEntity entity);
    }

    public interface IDomainService<TKey, TEntity, TRequest>
        : IRequestHandler<TRequest, TEntity>
        where TRequest : IRequest<TEntity>
		where TEntity : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
    }
}
