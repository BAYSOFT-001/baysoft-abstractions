using BAYSOFT.Abstractions.Core.Domain.Entities;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Core.Domain.Interfaces.Services;
using BAYSOFT.Abstractions.Core.Domain.Validations;
using FluentValidation;
using NetDevPack.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Abstractions.Core.Domain.Services
{
    public abstract class DomainService<TEntity> : IDomainService<TEntity>
        where TEntity : DomainEntity
    {
        private EntityValidator<TEntity> EntityValidator { get; set; }
        private DomainValidator<TEntity> DomainValidator { get; set; }
        public DomainService(EntityValidator<TEntity> entityValidator, DomainValidator<TEntity> domainValidator)
        {
            EntityValidator = entityValidator;
            DomainValidator = domainValidator;
        }

        protected bool ValidateEntity(TEntity entity, bool throwException = true, string message = null)
        {
            var result = this.EntityValidator.Validate(entity);

            if (!result.IsValid && throwException)
            {
                throw new BusinessException(
                    message ?? "Operation failed in entity validation!",
                    result.Errors.Select(error =>
                        new EntityValidationException(error.PropertyName, string.Format(error.ErrorMessage, error.PropertyName))
                    ).ToList());
            }

            return result.IsValid;
        }

        protected bool ValidateDomain(TEntity entity, bool throwException = true, string message = null)
        {
            var result = this.EntityValidator.Validate(entity);

            if (!result.IsValid && throwException)
            {
                throw new BusinessException(
                    message ?? "Operation failed in domain validation!",
                    result.Errors.Select(error =>
                        new DomainValidationException(string.Format(error.ErrorMessage, error.PropertyName))
                    ).ToList());
            }

            return result.IsValid;
        }
        public abstract Task Run(TEntity entity);
    }
}
