using BAYSOFT.Abstractions.Core.Domain.Entities;
using FluentValidation;

namespace BAYSOFT.Abstractions.Core.Application
{
    public class ApplicationRequestValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : DomainEntity
    {
    }
}
