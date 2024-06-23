using MediatR;
using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
	public abstract class DomainServiceRequest<TEntity>
        : IRequest<TEntity>
		where TEntity : IDomainEntityBase
	{
        public TEntity Payload { get; set; }
        public DomainServiceRequest(TEntity payload)
        {
            Payload = payload;
        }
    }
}
