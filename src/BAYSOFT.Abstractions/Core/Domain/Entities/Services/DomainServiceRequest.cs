using MediatR;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
	public abstract class DomainServiceRequest<TEntity>
        : IRequest<TEntity>
        where TEntity : IDomainEntity
    {
        public TEntity Payload { get; set; }
        public DomainServiceRequest(TEntity payload)
        {
            Payload = payload;
        }
    }
}
