using FluentValidation;
using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Validations
{
	public abstract class EntityValidator<TKey, TEntity> : AbstractValidator<TEntity>
		where TEntity : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
    }
}
