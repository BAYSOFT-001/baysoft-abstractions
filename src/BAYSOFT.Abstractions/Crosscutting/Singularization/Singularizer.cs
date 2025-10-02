using BAYSOFT.Abstractions.Crosscutting.Pluralization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Singularization
{
	public static class SingularizerExtensions
	{
		public static IServiceCollection AddSingularizer(this IServiceCollection services)
		{
			services.AddSingleton<Singularizer>(Singularizer.GetInstance());

			return services;
		}
	}
	public class Singularizer
	{
		public string DefaultCulture { get; set; }
		private static Singularizer Instance { get; set; }
		private List<ISingularizer> Singularizers { get; set; }
		public Singularizer()
		{
			DefaultCulture = "en-US";
		}
		public static Singularizer GetInstance()
		{
			if (Instance == null)
			{
				Instance = new Singularizer();
			}
			return Instance;
		}
		public void AddSingularizer(ISingularizer singularizer)
		{
			if (Singularizers == null)
			{
				Singularizers = new List<ISingularizer>();
			}
			if (!Singularizers.Any(p => p.Culture.StartsWith(singularizer.Culture, StringComparison.OrdinalIgnoreCase)))
			{
				Singularizers.Add(singularizer);
			}
		}
		public string Singularize(string word, string culture)
		{
			if (Singularizers == null || Singularizers.Count == 0)
			{
				Singularizers = new List<ISingularizer>();
				var singularizerTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => typeof(ISingularizer).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);
				foreach (var type in singularizerTypes)
				{
					if (Activator.CreateInstance(type) is ISingularizer singularizer)
					{
						Singularizers.Add(singularizer);
					}
				}
			}
			var singularizerToUse = Singularizers.FirstOrDefault(p => p.Culture.Equals(culture, StringComparison.OrdinalIgnoreCase));
			if (singularizerToUse == null)
			{
				singularizerToUse = Singularizers.FirstOrDefault(p => p.Culture.Equals(DefaultCulture, StringComparison.OrdinalIgnoreCase));
			}
			if (singularizerToUse != null)
			{
				return singularizerToUse.Singularize(word);
			}
			return word;
		}
	}
}
