using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Abstractions.Core.Domain.Interfaces.Services;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
    public abstract class DomainService<TEntity> : DomainServiceBase<TEntity>, IDomainService<TEntity>
        where TEntity : DomainEntity
    {
        public DomainService(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator, DomainValidator<TEntity> domainValidator) : base(localizer, entityValidator, domainValidator) { }
        public abstract Task Run(TEntity entity);
    }
}
