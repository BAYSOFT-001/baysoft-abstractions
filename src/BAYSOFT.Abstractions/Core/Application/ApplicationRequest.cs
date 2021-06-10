using BAYSOFT.Abstractions.Core.Domain.Entities;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Core.Domain.Validations;
using MediatR;
using ModelWrapper;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Core.Application
{
    public abstract class ApplicationRequest<TEntity, TResponse> : WrapRequest<TEntity>, IRequest<TResponse>
        where TEntity : DomainEntity
        where TResponse : ApplicationResponse<TEntity>
    {
        protected ApplicationRequestValidator<TEntity> Validator { get; set; }
        public bool IsValid(bool throwException = true, string message = null)
        {
            var result = this.Validator.Validate(this.Model);
            
            if (!result.IsValid && throwException)
            {
                throw new BusinessException(
                    message ?? "Operation failed in request validation!",
                    result.Errors.Select(error =>
                        new RequestValidationException(string.Format(error.ErrorMessage, error.PropertyName))
                    ).ToList());
            }

            return result.IsValid;
        }
    }
}
