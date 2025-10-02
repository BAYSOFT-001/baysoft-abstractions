using BAYSOFT.Abstractions.Crosscutting.Singularization.Spanish;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BAYSOFT.Abstractions.Crosscutting.Singularization.Portuguese
{
	public static class PortugueseSingularizerExtensions
	{
		public static IServiceCollection AddPortugueseSingularizer(this IServiceCollection services)
		{
			Singularizer.GetInstance().AddPortugueseSingularizer();

			return services;
		}

		public static Singularizer AddPortugueseSingularizer(this Singularizer singularizer)
		{
			singularizer.AddSingularizer(new PortugueseSingularizer());

			return singularizer;
		}
	}
	public class PortugueseSingularizer : ISingularizer
	{
		public string Culture { get { return "pt-BR"; } }

		private readonly HashSet<string> Invariables = new()
		{
			"lápis", "ônibus", "tórax", "vírus", "atlas"
		};

		private readonly Dictionary<string, string> Irregulars = new()
		{
			{"pães", "pão"},
			{"mães", "mãe"},
			{"cães", "cão"},
			{"alemães", "alemão"},
			{"mãos", "mão"}
		};

		public string Singularize(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				return word;

			word = word.Trim().ToLower();

			// Invariáveis
			if (Invariables.Contains(word))
				return word;

			// Irregulares
			if (Irregulars.ContainsKey(word))
				return Irregulars[word];

			// 1. termina em "ões"
			if (word.EndsWith("ões"))
				return word[..^3] + "ão";

			// 2. termina em "ns" → "m"
			if (word.EndsWith("ns"))
				return word[..^2] + "m";

			// 4. termina em "is" e antes era L
			if (word.EndsWith("is") && word.Length > 2 && word[^3] == 'a')
				return word[..^2] + "l"; // animais → animal

			// 5. termina em "es"
			if (word.EndsWith("es"))
			{
				if (word.EndsWith("ses") || word.EndsWith("zes") || word.EndsWith("res"))
					return word[..^2]; // remove "es"
			}

			// 6. termina em "s" após vogal
			if (word.EndsWith("s"))
				return word[..^1];

			return word; // fallback
		}
	}
}
