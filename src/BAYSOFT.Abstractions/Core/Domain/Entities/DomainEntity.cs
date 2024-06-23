using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities
{
	public abstract class DomainEntity<TKey> : IDomainEntity<TKey>
		where TKey : IEquatable<TKey>
	{
		public TKey Id { get; set; }
	}

	public abstract class DomainEntity : DomainEntity<int>, IDomainEntity<int>
	{
    }
}
