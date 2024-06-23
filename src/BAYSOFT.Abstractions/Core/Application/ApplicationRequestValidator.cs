using FluentValidation;

namespace BAYSOFT.Abstractions.Core.Application
{
	public class ApplicationRequestValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : class
	{
    }
}
