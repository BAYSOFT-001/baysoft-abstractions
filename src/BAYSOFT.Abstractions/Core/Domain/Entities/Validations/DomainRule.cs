using BAYSOFT.Abstractions.Crosscutting.Specification;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Validations
{
	public class DomainRule<TEntity> : Rule<TEntity>
        where TEntity : IDomainEntity
	{
		private readonly Specification<TEntity> Specification;
		public DomainRule(Specification<TEntity> specification, string errorMessage) : base(specification, errorMessage)
        {
			Specification = specification;
        }

	}
}
