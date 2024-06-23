using BAYSOFT.Abstractions.Crosscutting.Specification;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Validations
{
	public abstract class DomainValidator<TEntity> : Validator<TEntity>
        where TEntity : IDomainEntity
    {
    }
}
