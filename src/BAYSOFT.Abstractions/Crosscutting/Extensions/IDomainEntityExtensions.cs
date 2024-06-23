using BAYSOFT.Abstractions.Core.Domain.Entities;
using System;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Extensions
{
	public static class IDomainEntityExtensions
	{

		public static void Update<TKey>(this IDomainEntity<TKey> source, IDomainEntity<TKey> updatedEntity)
			where TKey : IEquatable<TKey>
		{
			source.GetType()
				.GetProperties()
				.Where(property => !typeof(IDomainEntity<TKey>).GetProperties().Any(p => p.Name == property.Name))
				.ToList()
				.ForEach(property => property.SetValue(source, updatedEntity.GetType().GetProperty(property.Name).GetValue(updatedEntity)));
		}
	}
}
