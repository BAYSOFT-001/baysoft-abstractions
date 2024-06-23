using BAYSOFT.Abstractions.Crosscutting.Specification;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Specifications
{
    public abstract class DomainSpecification<TEntity> : Specification<TEntity>
        where TEntity : IDomainEntityBase
    {
    }
}
