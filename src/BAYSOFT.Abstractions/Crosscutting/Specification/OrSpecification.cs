using System;
using System.Linq.Expressions;

namespace BAYSOFT.Abstractions.Crosscutting.Specification;

internal sealed class OrSpecification<T> : Specification<T>
{
	private readonly Specification<T> _left;
	private readonly Specification<T> _right;
	public OrSpecification(Specification<T> left, Specification<T> right)
	{
		_right = right;
		_left = left;
	}
	public override Expression<Func<T, bool>> ToExpression()
	{
		Expression<Func<T, bool>> expression = _left.ToExpression();
		InvocationExpression right = Expression.Invoke(_right.ToExpression(), expression.Parameters);
		return (Expression<Func<T, bool>>)Expression.Lambda(Expression.OrElse(expression.Body, right), expression.Parameters);
	}
}