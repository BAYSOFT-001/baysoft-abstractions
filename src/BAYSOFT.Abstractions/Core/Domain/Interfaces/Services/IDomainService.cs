using BAYSOFT.Abstractions.Core.Domain.Entities;
using MediatR;
using System;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Interfaces.Services
{
	public interface IDomainService<TEntity>
		where TEntity : IDomainEntityBase
	{
        Task Run(TEntity entity);
    }

    public interface IDomainService<TEntity, TRequest>
        : IRequestHandler<TRequest, TEntity>
        where TRequest : IRequest<TEntity>
		where TEntity : IDomainEntityBase
	{
    }
}
