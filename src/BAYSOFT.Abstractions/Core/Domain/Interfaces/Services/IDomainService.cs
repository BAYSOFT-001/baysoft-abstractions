using BAYSOFT.Abstractions.Core.Domain.Entities;
using MediatR;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Interfaces.Services
{
	public interface IDomainService<TEntity>
        where TEntity : IDomainEntity
    {
        Task Run(TEntity entity);
    }

    public interface IDomainService<TEntity, TRequest>
        : IRequestHandler<TRequest, TEntity>
        where TEntity : IDomainEntity
        where TRequest : IRequest<TEntity>
    {
    }
}
