
using System;
using System.Linq.Expressions;

namespace BAYSOFT.Abstractions.Crosscutting.Specification;

public abstract class Specification<T>
{
	public string SpecificationMessage { get; protected set; }
	private static readonly Specification<T> All = new IdentitySpecification<T>();
	public override string ToString() { return SpecificationMessage; }
	public bool IsSatisfiedBy(T entity)
	{
		return ToExpression().Compile()(entity);
	}
	public abstract Expression<Func<T, bool>> ToExpression();
	public Specification<T> And(Specification<T> specification)
	{
		if (this == All)
		{
			return specification;
		}

		if (specification == All)
		{
			return this;
		}

		return new AndSpecification<T>(this, specification);
	}
	public Specification<T> Or(Specification<T> specification)
	{
		if (this == All || specification == All)
		{
			return All;
		}

		return new OrSpecification<T>(this, specification);
	}
	public Specification<T> Not()
	{
		return new NotSpecification<T>(this);
	}
}