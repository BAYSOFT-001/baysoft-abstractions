using System;

namespace BAYSOFT.Abstractions.Core.Domain.Entities
{   public interface IDomainEntityBase { }
	public interface IDomainEntity<TKey> : IDomainEntityBase
        where TKey : IEquatable<TKey>
	{
        public TKey Id { get; set; }
    }

    public interface IDomainEntity: IDomainEntity<int>
	{
    }
}
