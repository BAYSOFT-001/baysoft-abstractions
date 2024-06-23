using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities
{
	public interface IDomainEntity<TKey>
        where TKey : IEquatable<TKey>
	{
        public TKey Id { get; set; }
    }

    public interface IDomainEntity: IDomainEntity<int>
	{
    }
}
