using System.Collections.Generic;
using FluentValidation.Results;

namespace BAYSOFT.Abstractions.Crosscutting.Specification;

public class Validator<T>
{
	private readonly Dictionary<string, Rule<T>> _validations = new Dictionary<string, Rule<T>>();

	public ValidationResult Validate(T obj)
	{
		ValidationResult validationResult = new ValidationResult();
		foreach (string key in _validations.Keys)
		{
			Rule<T> rule = _validations[key];
			if (!rule.Validate(obj))
			{
				validationResult.Errors.Add(new ValidationFailure(obj.GetType().Name, rule.ErrorMessage));
			}
		}

		return validationResult;
	}

	protected void Add(string name, Rule<T> rule)
	{
		_validations.Add(name, rule);
	}

	protected void Remove(string name)
	{
		_validations.Remove(name);
	}

	protected Rule<T> GetRule(string name)
	{
		_validations.TryGetValue(name, out var value);
		return value;
	}
}