using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Abstractions.Core.Domain.Interfaces.Services;
using Microsoft.Extensions.Localization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
	public abstract class DomainServiceRequestHandler<TKey, TEntity, TRequest> : DomainServiceBase<TKey, TEntity>, IDomainService<TKey, TEntity, TRequest>
        where TRequest : DomainServiceRequest<TKey, TEntity>
		where TEntity : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
        public DomainServiceRequestHandler() : base() { }
		public DomainServiceRequestHandler(IStringLocalizer localizer) : base(localizer) { }
		public DomainServiceRequestHandler(IStringLocalizer localizer, EntityValidator<TKey, TEntity> entityValidator) : base(localizer, entityValidator) { }
		public DomainServiceRequestHandler(IStringLocalizer localizer, EntityValidator<TKey, TEntity> entityValidator, DomainValidator<TKey, TEntity> domainValidator) : base(localizer, entityValidator, domainValidator) { }

		public abstract Task<TEntity> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
