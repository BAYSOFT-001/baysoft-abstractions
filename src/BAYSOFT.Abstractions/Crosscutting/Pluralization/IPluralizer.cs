namespace BAYSOFT.Abstractions.Crosscutting.Pluralization
{
	public interface IPluralizer
	{
		string Culture { get; }
		string Pluralize(string word);
	}
}
