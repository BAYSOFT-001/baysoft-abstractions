using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
    public abstract class DomainServiceRequest<TEntity>
        : IRequest<TEntity>
        where TEntity : DomainEntity
    {
        public TEntity Payload { get; set; }
        public DomainServiceRequest(TEntity payload)
        {
            Payload = payload;
        }
    }
}
