using NetDevPack.Specification;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Specifications
{
    public abstract class DomainSpecification<TEntity> : Specification<TEntity>
        where TEntity : DomainEntity
    {
        public string SpecificationMessage { get; protected set; }
        public override string ToString() { return SpecificationMessage; }
    }
}
