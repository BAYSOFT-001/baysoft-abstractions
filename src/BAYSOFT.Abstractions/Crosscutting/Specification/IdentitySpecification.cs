using System;
using System.Linq.Expressions;

namespace BAYSOFT.Abstractions.Crosscutting.Specification;

internal sealed class IdentitySpecification<T> : Specification<T>
{
	public override Expression<Func<T, bool>> ToExpression()
	{
		return (T x) => true;
	}
}