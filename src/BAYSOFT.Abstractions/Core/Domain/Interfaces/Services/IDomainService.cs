using BAYSOFT.Abstractions.Core.Domain.Entities;
using MediatR;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Interfaces.Services
{
    public interface IDomainService<TEntity>
        where TEntity : DomainEntity
    {
        Task Run(TEntity entity);
    }

    public interface IDomainService<TEntity, TRequest>
        : IRequestHandler<TRequest, TEntity>
        where TEntity : DomainEntity
        where TRequest : IRequest<TEntity>
    {
    }
}
