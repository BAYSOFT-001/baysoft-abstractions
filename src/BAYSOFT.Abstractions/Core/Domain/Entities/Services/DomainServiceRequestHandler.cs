using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Abstractions.Core.Domain.Interfaces.Services;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
    public abstract class DomainServiceRequestHandler<TEntity, TRequest> : DomainServiceBase<TEntity>, IDomainService<TEntity, TRequest>
        where TEntity : DomainEntity
        where TRequest : DomainServiceRequest<TEntity>
    {
        public DomainServiceRequestHandler() : base() { }
		public DomainServiceRequestHandler(IStringLocalizer localizer) : base(localizer) { }
		public DomainServiceRequestHandler(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator) : base(localizer, entityValidator) { }
		public DomainServiceRequestHandler(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator, DomainValidator<TEntity> domainValidator) : base(localizer, entityValidator, domainValidator) { }

		public abstract Task<TEntity> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
