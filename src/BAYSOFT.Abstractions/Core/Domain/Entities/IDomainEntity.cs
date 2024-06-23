namespace BAYSOFT.Abstractions.Core.Domain.Entities
{
	public interface IDomainEntity<TIdType> : IDomainEntity
    {
        public TIdType Id { get; set; }
    }

    public interface IDomainEntity
    {
        public void Update(IDomainEntity updatedEntity);
    }
}
