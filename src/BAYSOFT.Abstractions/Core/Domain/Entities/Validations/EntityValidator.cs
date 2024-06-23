using FluentValidation;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Validations
{
	public abstract class EntityValidator<TEntity> : AbstractValidator<TEntity>
		where TEntity : IDomainEntityBase
	{
    }
}
