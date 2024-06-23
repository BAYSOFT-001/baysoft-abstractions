using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Abstractions.Core.Domain.Interfaces.Services;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
	public abstract class DomainService<TKey, TEntity> : DomainServiceBase<TKey, TEntity>, IDomainService<TKey, TEntity>
        where TEntity : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
		public DomainService() : base() { }
		public DomainService(IStringLocalizer localizer) : base(localizer) { }
		public DomainService(IStringLocalizer localizer, EntityValidator<TKey, TEntity> entityValidator) : base(localizer, entityValidator) { }
		public DomainService(IStringLocalizer localizer, EntityValidator<TKey, TEntity> entityValidator, DomainValidator<TKey, TEntity> domainValidator) : base(localizer, entityValidator, domainValidator) { }
        public abstract Task Run(TEntity entity);
    }
}
