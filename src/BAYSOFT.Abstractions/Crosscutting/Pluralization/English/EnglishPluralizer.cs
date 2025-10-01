using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Pluralization.pt_br
{
	public static class EnglishPluralizerExtensions
	{
		public static IServiceCollection AddEnglishPluralizer(this IServiceCollection services)
		{
			Pluralizer.GetInstance().AddPluralizer(new EnglishPluralizer());

			return services;
		}
	}
	public class EnglishPluralizer : IPluralizer
	{
		private readonly Dictionary<string, string> IrregularPlurals = new()
		{
			{"man", "men"},
			{"woman", "women"},
			{"child", "children"},
			{"tooth", "teeth"},
			{"foot", "feet"},
			{"goose", "geese"},
			{"mouse", "mice"},
			{"person", "people"}
		};

		private readonly HashSet<string> Invariables = new()
		{
			"sheep", "fish", "deer", "species", "aircraft", "series"
		};

		private readonly HashSet<string> FtoS = new()
		{
			"roof", "chief", "belief", "chef", "proof" // exceções que ficam em "s"
		};

		private readonly HashSet<string> OtoS = new()
		{
			"photo", "piano", "halo", "solo", "zero", "video" // exceções que ficam em "s"
		};
		public string Culture { get { return "en-US"; } }
		public string Pluralize(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				return word;

			word = word.Trim().ToLower();

			// 1. Irregulares
			if (IrregularPlurals.ContainsKey(word))
				return IrregularPlurals[word];

			// 2. Invariáveis
			if (Invariables.Contains(word))
				return word;

			// 3. terminações especiais
			if (word.EndsWith("s") || word.EndsWith("x") || word.EndsWith("z") ||
				word.EndsWith("ch") || word.EndsWith("sh"))
				return word + "es";

			if (word.EndsWith("y") && word.Length > 1 && IsConsonant(word[^2]))
				return word[..^1] + "ies";

			if (word.EndsWith("f") && !FtoS.Contains(word))
				return word[..^1] + "ves";

			if (word.EndsWith("fe") && !FtoS.Contains(word))
				return word[..^2] + "ves";

			if (word.EndsWith("o") && !OtoS.Contains(word))
				return word + "es";

			// 4. regra padrão
			return word + "s";
		}

		private bool IsConsonant(char c)
		{
			return !"aeiou".Contains(char.ToLower(c));
		}
	}
}
