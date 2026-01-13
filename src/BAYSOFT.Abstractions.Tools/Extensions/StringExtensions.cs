namespace BAYSOFT.Abstractions.Crosscutting.Extensions
{
	public static class StringExtensions
	{
		public static string ToCamelCase(this string value)
		{
			return System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(value);
		}
		public static string ToPascalCase(this string value)
		{
			var newValue = value;
			
			foreach (var part in value.Split(' ', '_', '-'))
			{
				if (part.Length > 0)
				{
					newValue = newValue.Replace(part, char.ToUpper(part[0]) + part.Substring(1).ToLower());
				}
			}

			return newValue;
		}
	}
}
