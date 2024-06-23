using BAYSOFT.Abstractions.Crosscutting.Specification;
using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Validations
{
	public abstract class DomainValidator<TKey, TEntity> : Validator<TKey, TEntity>
		where TEntity : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
    }
}
