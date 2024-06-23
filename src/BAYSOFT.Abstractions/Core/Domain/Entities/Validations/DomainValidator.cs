using BAYSOFT.Abstractions.Crosscutting.Specification;
using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Validations
{
	public abstract class DomainValidator<TEntity> : Validator<TEntity>
		where TEntity : IDomainEntityBase
	{
    }
}
