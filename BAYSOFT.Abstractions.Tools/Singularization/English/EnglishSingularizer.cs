using BAYSOFT.Abstractions.Crosscutting.Singularization.Portuguese;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BAYSOFT.Abstractions.Crosscutting.Singularization.English
{
	public static class EnglishSingularizerExtensions
	{
		public static IServiceCollection AddEnglishSingularizer(this IServiceCollection services)
		{
			Singularizer.GetInstance().AddEnglishSingularizer();

			return services;
		}

		public static Singularizer AddEnglishSingularizer(this Singularizer singularizer)
		{
			singularizer.AddSingularizer(new EnglishSingularizer());

			return singularizer;
		}
	}
	public class EnglishSingularizer : ISingularizer
	{
		public string Culture { get { return "en-US"; } }
		private readonly Dictionary<string, string> Irregulars = new()
		{
			{"men", "man"},
			{"women", "woman"},
			{"children", "child"},
			{"teeth", "tooth"},
			{"feet", "foot"},
			{"geese", "goose"},
			{"mice", "mouse"},
			{"people", "person"}
		};

		private readonly HashSet<string> Invariables = new()
		{
			"sheep", "deer", "fish", "series", "species", "aircraft"
		};

		private readonly HashSet<string> FtoS = new()
		{
			"roofs", "chiefs", "proofs", "beliefs"
		};

		private readonly HashSet<string> OtoS = new()
		{
			"photos", "pianos", "halos", "videos"
		};

		public string Singularize(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				return word;

			word = word.Trim().ToLower();

			// 1. Irregulares
			if (Irregulars.ContainsKey(word))
				return Irregulars[word];

			// 2. Invariáveis
			if (Invariables.Contains(word))
				return word;

			// 3. termina em "ies" → "y"
			if (word.EndsWith("ies") && word.Length > 3)
				return word[..^3] + "y";

			// 4. termina em "ves" (f/fe)
			if (word.EndsWith("ves") && !FtoS.Contains(word))
			{
				string baseWord = word[..^3];
				return baseWord + (baseWord.EndsWith("li") ? "fe" : "f");
			}

			// 5. termina em "oes"
			if (word.EndsWith("oes") && !OtoS.Contains(word))
				return word[..^2]; // tomatoes → tomato

			// 6. termina em "es" (bus → buses, box → boxes)
			if (word.EndsWith("es") &&
				(word.EndsWith("ses") || word.EndsWith("xes") || word.EndsWith("zes") ||
				 word.EndsWith("ches") || word.EndsWith("shes")))
			{
				return word[..^2];
			}

			// 7. termina em "s"
			if (word.EndsWith("s"))
				return word[..^1];

			return word;
		}
	}
}
