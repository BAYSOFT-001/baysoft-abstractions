using System.Linq;

namespace BAYSOFT.Abstractions.Core.Domain.Entities
{
	public abstract class DomainEntity<TIdType> : DomainEntity, IDomainEntity<TIdType>
	{
		public TIdType Id { get; set; }
		public override void Update(IDomainEntity updatedEntity)
		{
			this.GetType()
				.GetProperties()
				.Where(property => !typeof(DomainEntity<TIdType>).GetProperties().Any(p =>p.Name == property.Name))
				.ToList()
				.ForEach(property => property.SetValue(this, updatedEntity.GetType().GetProperty(property.Name).GetValue(updatedEntity)));
		}
	}

	public abstract class DomainEntity : IDomainEntity
	{
        public virtual void Update(IDomainEntity updatedEntity)
        {
            this.GetType()
				.GetProperties()
				.ToList()
				.ForEach(property => property.SetValue(this, updatedEntity.GetType().GetProperty(property.Name).GetValue(updatedEntity)));
        }
    }
}
