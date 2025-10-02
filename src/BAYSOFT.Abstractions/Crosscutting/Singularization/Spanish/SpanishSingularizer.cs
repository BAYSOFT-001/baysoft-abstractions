using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BAYSOFT.Abstractions.Crosscutting.Singularization.Spanish
{
	public static class SpanishSingularizerExtensions
	{
		public static IServiceCollection AddSpanishSingularizer(this IServiceCollection services)
		{
			Singularizer.GetInstance().AddPluralizer(new SpanishSingularizer());

			return services;
		}
	}
	public class SpanishSingularizer : ISingularizer
	{
		public string Culture { get { return "es-MX"; } }
		private readonly HashSet<string> Invariables = new()
		{
			"lunes", "martes", "miércoles", "jueves", "viernes",
			"tórax", "paraguas", "virus", "análisis", "crisis", "series"
		};

		public string Singularize(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				return word;

			word = word.Trim().ToLower();

			// 1. invariáveis
			if (Invariables.Contains(word))
				return word;

			// 2. termina em "ces" → vira "z"
			if (word.EndsWith("ces"))
				return word[..^3] + "z";

			// 3. termina em "es"
			if (word.EndsWith("es"))
			{
				// ex: papeles → papel, mujeres → mujer
				return word[..^2];
			}

			// 4. termina em "s" após vogal → remove o "s"
			if (word.EndsWith("s") && word.Length > 1 && IsVowel(word[^2]))
				return word[..^1];

			return word; // fallback
		}

		private bool IsVowel(char c)
		{
			return "aeiouáéíóú".Contains(char.ToLower(c));
		}
	}
}
