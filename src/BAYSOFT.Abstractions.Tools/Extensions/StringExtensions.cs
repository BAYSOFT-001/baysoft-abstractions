using System.Net.NetworkInformation;

namespace BAYSOFT.Abstractions.Crosscutting.Extensions
{
	public static class StringExtensions
	{
		private static Func<string, bool> isLower = (c) => c.Equals(c.ToLower());
		private static Func<string, bool> isUpper = (c) => c.Equals(c.ToUpper());
		private static Func<List<string>, bool> allUpper = (lc) => lc.All(c => isUpper(c));
		private static Func<List<string>, bool> allLower = (lc) => lc.All(c => isLower(c));
		private static Func<List<string>, bool> firstUpper = (lc) => { var firstChar = lc.First(); return firstChar.Equals(firstChar.ToUpper()); };
		private static Func<List<string>, bool> firstLower = (lc) => { var firstChar = lc.First(); return firstChar.Equals(firstChar.ToLower()); };
		private static Func<List<string>, bool> onlyOneUpper = (lc) => lc.Where(c => c.Equals(c.ToUpper())).Count() == 1;
		private static Func<List<string>, bool> moreThanOneUpper = (lc) => lc.Where(c => c.Equals(c.ToUpper())).Count() > 1;
		private static Func<List<string>, bool> oneOrMoreUpper = (lc) => lc.Where(c => c.Equals(c.ToUpper())).Count() >= 1;
		private static Func<List<string>, bool> hasSpaces = (lc) => lc.Any(c => c.Equals(" "));
		private static Func<List<string>, bool> hasUnderlines = (lc) => lc.Any(c => c.Equals("_"));
		private static Func<List<string>, bool> hasHyphens = (lc) => lc.Any(c => c.Equals("-"));
		public enum Case
		{
			Lower,
			Upper,
			Sentence,
			Title,
			Pascal,
			Camel,
			Snake,
			Kebab,
			Constant,
			None
		}

		public static Case IdentifyCase(this string source)
		{
			var chars = source.ToCharArray().Select(c => c.ToString()).ToList();

			if (firstLower(chars) && hasUnderlines(chars))
				return Case.Snake;
			if (firstLower(chars) && hasHyphens(chars))
				return Case.Kebab;
			if (allUpper(chars) && hasUnderlines(chars))
				return Case.Constant;
			if (allUpper(chars))
				return Case.Lower;
			if (allLower(chars))
				return Case.Upper;
			if (firstUpper(chars) && onlyOneUpper(chars) && hasSpaces(chars))
				return Case.Sentence;
			if (firstUpper(chars) && moreThanOneUpper(chars) && hasSpaces(chars))
				return Case.Title;
			if (firstUpper(chars) && oneOrMoreUpper(chars) && !hasSpaces(chars))
				return Case.Pascal;
			if (firstLower(chars))
				return Case.Camel;

			return Case.None;
		}
		public static string[] GetWords(this string source)
		{
			var sourceCase = source.IdentifyCase();

			if (sourceCase == Case.Pascal || sourceCase == Case.Camel)
			{
				var words = new List<string>();
				var word = string.Empty;
				var chars = source.ToCharArray().Select(c => c.ToString()).ToList();
				var firstCharWasUpper = firstUpper(chars);
				var isFirstChar = true;
				foreach (string c in chars.ToList())
				{
					if ((isFirstChar && firstCharWasUpper && isUpper(c)) || !isUpper(c))
					{
						word = $"{word}{c}";
					}
					else
					{
						words.Add(word);
						word = c;
					}
					isFirstChar = false;
				}
				
				if(!string.IsNullOrWhiteSpace(word))
					words.Add(word);

				return words.ToArray();
			}

			return source.Split([' ', '-', '_', '|', '\\', '/', ',', ':', ';', '+']);
		}
		public static string ToPascalCase(this string value)
		{
			var result = string.Empty;
			var words = value.GetWords();

			foreach (var word in words)
			{
				result = $"{result}{char.ToUpper(word[0]) + word.Substring(1).ToLower()}";
			}

			return result;
		}
		public static string ToCamelCase(this string value)
		{
			var result = string.Empty;
			var words = value.GetWords();

			var firstWord = true;

            foreach (var word in words)
            {
				if (firstWord)
				{
					result = $"{word.ToLower()}";
				}
				else
				{
					result = $"{result}{word.ToPascalCase()}";
				}

				firstWord = false;
            }

            return result;
		}
		public static string ToSentenceCase(this string value)
		{
			var result = string.Empty;
			var words = value.GetWords();

			var firstWord = true;

			foreach (var word in words)
			{
				if (firstWord)
				{
					result = $"{word.ToPascalCase()}";
				}
				else
				{
					result = $"{result} {word.ToLower()}";
				}

				firstWord = false;
			}

			return result;
		}
		public static string ToTitleCase(this string value)
		{
			var result = string.Empty;
			var words = value.GetWords();

			var firstWord = true;

			foreach (var word in words)
			{
				if (firstWord)
				{
					result = $"{word.ToPascalCase()}";
				}
				else
				{
					result = $"{result} {word.ToPascalCase()}";
				}

				firstWord = false;
			}

			return result;
		}
		public static string ToSnakeCase(this string value)
		{
			var result = string.Empty;
			var words = value.GetWords();

			var firstWord = true;

			foreach (var word in words)
			{
				if (firstWord)
				{
					result = $"{word.ToLower()}";
				}
				else
				{
					result = $"{result}_{word.ToLower()}";
				}

				firstWord = false;
			}

			return result;
		}
		public static string ToKebabCase(this string value)
		{
			var result = string.Empty;
			var words = value.GetWords();

			var firstWord = true;

			foreach (var word in words)
			{
				if (firstWord)
				{
					result = $"{word.ToLower()}";
				}
				else
				{
					result = $"{result}-{word.ToLower()}";
				}

				firstWord = false;
			}

			return result;
		}
		public static string ToConstantCase(this string value)
		{
			var result = string.Empty;
			var words = value.GetWords();

			var firstWord = true;

			foreach (var word in words)
			{
				if (firstWord)
				{
					result = $"{word.ToUpper()}";
				}
				else
				{
					result = $"{result}_{word.ToUpper()}";
				}

				firstWord = false;
			}

			return result;
		}
		public static string ToCase(this string value, Case caseValue)
		{
			switch (caseValue)
			{
				case Case.Constant: return ToConstantCase(value);
				case Case.Kebab: return ToKebabCase(value);
				case Case.Snake: return ToSnakeCase(value);
				case Case.Sentence: return ToSentenceCase(value);
				case Case.Title: return ToTitleCase(value);
				case Case.Camel: return ToCamelCase(value);
				case Case.Pascal: return ToPascalCase(value);
				case Case.Upper: return value.ToUpper();
				case Case.Lower: return value.ToLower();
				default: return value;
			}
		}
	}
}
