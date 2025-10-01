using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Pluralization
{
	public static class PluralizerExtensions
	{
		public static IServiceCollection AddPluralizer(this IServiceCollection services)
		{
			services.AddSingleton<Pluralizer>(Pluralizer.GetInstance());

			return services;
		}
	}
	public class Pluralizer
	{
		public string DefaultCulture { get; set; }
		private static Pluralizer Instance { get; set; }
		private List<IPluralizer> Pluralizers { get; set; }
		public Pluralizer()
		{
			DefaultCulture = "en-US";
		}
		public static Pluralizer GetInstance()
		{
			if (Instance == null)
			{
				Instance = new Pluralizer();
			}
			return Instance;
		}
		public void AddPluralizer(IPluralizer pluralizer)
		{
			if (Pluralizers == null)
			{
				Pluralizers = new List<IPluralizer>();
			}
			if (!Pluralizers.Any(p => p.Culture.Equals(pluralizer.Culture, StringComparison.OrdinalIgnoreCase)))
			{
				Pluralizers.Add(pluralizer);
			}
		}
		public string Pluralize(string palavra, string culture)
		{
			if (Pluralizers == null || Pluralizers.Count == 0)
			{
				Pluralizers = new List<IPluralizer>();
				var pluralizerTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => typeof(IPluralizer).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);
				foreach (var type in pluralizerTypes)
				{
					if (Activator.CreateInstance(type) is IPluralizer pluralizer)
					{
						Pluralizers.Add(pluralizer);
					}
				}
			}
			var pluralizerToUse = Pluralizers.FirstOrDefault(p => p.Culture.Equals(culture, StringComparison.OrdinalIgnoreCase));
			if (pluralizerToUse == null)
			{
				pluralizerToUse = Pluralizers.FirstOrDefault(p => p.Culture.Equals(DefaultCulture, StringComparison.OrdinalIgnoreCase));
			}
			if (pluralizerToUse != null)
			{
				return pluralizerToUse.Pluralize(palavra);
			}
			return palavra;
		}
	}
}
