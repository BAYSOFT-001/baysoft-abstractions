using BAYSOFT.Abstractions.Crosscutting.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Pluralization.Portuguese
{
	public static class PortuguesePluralizerExtensions
	{
		public static IServiceCollection AddPortuguesePluralizer(this IServiceCollection services)
		{
			Pluralizer.GetInstance().AddPortuguesePluralizer();

			return services;
		}

		public static Pluralizer AddPortuguesePluralizer(this Pluralizer pluralizer)
		{
			pluralizer.AddPluralizer(new PortuguesePluralizer());

			return pluralizer;
		}
	}
	public class PortuguesePluralizer : IPluralizer
	{
		private static readonly Dictionary<string, string> Excecoes = new()
		{
			{"lápis", "lápis"},
			{"ônibus", "ônibus"},
			{"tórax", "tórax"},
			{"atlas", "atlas"},
			{"pão", "pães"},
			{"mão", "mãos"},
			{"cidadão", "cidadãos"},
			{"alemão", "alemães"}
		};
		public string Culture { get { return "pt-BR"; } }
		public string Pluralize(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				return word;

			word = word.Trim().ToLower();

			// 1. Compostos (com hífen ou espaço)
			if (word.Contains('-') || word.Contains(' '))
				return PluralizeCompound(word);

			// 2. Palavra simples
			return PluralizeSimple(word);
		}

		private string PluralizeCompound(string composto)
		{
			char separador = composto.Contains('-') ? '-' : ' ';
			var partes = composto.Split(separador);

			// regra simplificada: pluralizar o último termo
			for (int i = partes.Length - 1; i >= 0; i--)
			{
				string original = partes[i];
				string plural = PluralizeSimple(original);

				if (plural != original) // só substitui se houve alteração
				{
					partes[i] = plural;
					break;
				}
			}

			return string.Join(separador, partes);
		}

		private string PluralizeSimple(string word)
        {
			var originalCase = word.IdentifyCase();

            word = PluralizeCore(word.ToKebabCase());

			return word.ToCase(originalCase);
        }

        private string PluralizeCore(string word)
        {
            if (Excecoes.ContainsKey(word))
                return Excecoes[word];

            if (EndsWithAny(word, "a", "e", "i", "o", "u"))
                return word + "s";

            if (EndsWithAny(word, "r", "z"))
                return word + "es";

            if (word.EndsWith("s"))
            {
                if (IsOxytone(word)) return word + "es";
                return word; // invariável
            }

            if (word.EndsWith("m"))
                return word[..^1] + "ns";

            if (word.EndsWith("ão"))
                return word[..^2] + "ões"; // padrão

            if (word.EndsWith("il"))
            {
                if (IsOxytone(word)) return word[..^2] + "is";
                return word[..^2] + "eis";
            }

            if (word.EndsWith("l"))
            {
                char beforeL = word[^2];
                if ("aeiou".Contains(beforeL))
                    return word[..^1] + "is";
                return word[..^1] + "eis";
            }

            if (word.EndsWith("x"))
                return word;

            if (word.EndsWith("n"))
                return word + "s";

            return word + "s";
        }

        private bool EndsWithAny(string word, params string[] finais) =>
			finais.Any(f => word.EndsWith(f));

		private bool IsOxytone(string word)
		{
			if (word.Length <= 2) return true;
			char last = word[^1];
			return "áéíóúâêô".Contains(last);
		}
	}
}
