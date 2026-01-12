namespace BAYSOFT.Abstractions.Crosscutting.Singularization
{
	public interface ISingularizer
	{
		string Culture { get; }
		string Singularize(string word);
	}
}
