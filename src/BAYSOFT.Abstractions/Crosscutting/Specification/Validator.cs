using BAYSOFT.Abstractions.Core.Domain.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace BAYSOFT.Abstractions.Crosscutting.Specification;

public class Validator<TKey, TEntity>
	where TEntity : IDomainEntity<TKey>
	where TKey : IEquatable<TKey>
{
	private readonly Dictionary<string, Rule<TEntity>> _validations = new Dictionary<string, Rule<TEntity>>();

	public ValidationResult Validate(TEntity obj)
	{
		ValidationResult validationResult = new ValidationResult();
		foreach (string key in _validations.Keys)
		{
			Rule<TEntity> rule = _validations[key];
			if (!rule.Validate(obj))
			{
				validationResult.Errors.Add(new ValidationFailure(obj.GetType().Name, rule.ErrorMessage));
			}
		}

		return validationResult;
	}

	protected void Add(string name, Rule<TEntity> rule)
	{
		_validations.Add(name, rule);
	}

	protected void Remove(string name)
	{
		_validations.Remove(name);
	}

	protected Rule<TEntity> GetRule(string name)
	{
		_validations.TryGetValue(name, out var value);
		return value;
	}
}