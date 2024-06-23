using MediatR;
using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
	public abstract class DomainServiceRequest<TKey, TEntity>
        : IRequest<TEntity>
		where TEntity : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
        public TEntity Payload { get; set; }
        public DomainServiceRequest(TEntity payload)
        {
            Payload = payload;
        }
    }
}
