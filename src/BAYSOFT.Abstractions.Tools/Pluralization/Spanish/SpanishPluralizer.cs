using BAYSOFT.Abstractions.Crosscutting.Extensions;
using BAYSOFT.Abstractions.Crosscutting.Singularization;
using BAYSOFT.Abstractions.Crosscutting.Singularization.English;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Pluralization.Spanish
{
	public static class SpanishPluralizerExtensions
	{
		public static IServiceCollection AddSpanishPluralizer(this IServiceCollection services)
		{
			Pluralizer.GetInstance().AddSpanishPluralizer();

			return services;
		}

		public static Pluralizer AddSpanishPluralizer(this Pluralizer pluralizer)
		{
			pluralizer.AddPluralizer(new SpanishPluralizer());

			return pluralizer;
		}
	}
	public class SpanishPluralizer : IPluralizer
	{
		private readonly HashSet<string> Invariables = new()
		{
			"lunes", "martes", "miércoles", "jueves", "viernes",
			"tórax", "paraguas", "virus", "análisis", "crisis"
		};
		
		public string Culture { get { return "es-MX"; } }

		public string Pluralize(string word)
        {
			var originalCase = word.IdentifyCase();

            word = PluralizeCore(word.ToKebabCase());

			return word.ToCase(originalCase);
        }

        private string PluralizeCore(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return word;

            word = word.Trim().ToLower();

            // 1. invariáveis
            if (Invariables.Contains(word))
                return word;

            // 2. termina em vogal → +s
            if (EndsWithVowel(word))
                return word + "s";

            // 3. termina em Z → troca por "ces"
            if (word.EndsWith("z"))
                return word[..^1] + "ces";

            // 4. termina em s/x átona → invariável
            if ((word.EndsWith("s") || word.EndsWith("x")) && IsUnstressed(word))
                return word;

            // 5. regra padrão → +es
            return word + "es";
        }

        private bool EndsWithVowel(string word)
		{
			char last = word[^1];
			return "aeiouáéíóú".Contains(last);
		}

		private bool IsUnstressed(string word)
		{
			// regra simplificada: não contém acento
			return !word.Contains('á') && !word.Contains('é') &&
				   !word.Contains('í') && !word.Contains('ó') &&
				   !word.Contains('ú');
		}
	}
}
