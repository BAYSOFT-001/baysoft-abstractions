using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;

namespace BAYSOFT.Abstractions.Core.Domain.Entities.Services
{
	public abstract class DomainServiceBase<TEntity>
		where TEntity : IDomainEntity
	{
		private IStringLocalizer Localizer { get; set; }
		private EntityValidator<TEntity> EntityValidator { get; set; }
		private DomainValidator<TEntity> DomainValidator { get; set; }
		public DomainServiceBase()
		{
		}
		public DomainServiceBase(IStringLocalizer localizer)
		{
			Localizer = localizer;
		}
		public DomainServiceBase(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator)
		{
			Localizer = localizer;
			EntityValidator = entityValidator;
		}
		public DomainServiceBase(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator, DomainValidator<TEntity> domainValidator)
		{
			Localizer = localizer;
			EntityValidator = entityValidator;
			DomainValidator = domainValidator;
		}

		protected bool ValidateEntity(TEntity entity, bool throwException = true, string message = null)
		{
			if (Localizer == null)
			{
				throw new ArgumentNullException(nameof(Localizer));
			}

			if (EntityValidator == null)
			{
				throw new ArgumentNullException(nameof(EntityValidator));
			}

			var result = EntityValidator.Validate(entity);

			if (!result.IsValid && throwException)
			{
				throw new BusinessException(
					message ?? Localizer["Operation failed in entity validation!"],
					result.Errors.Select(error =>
						new EntityValidationException(
							error.PropertyName,
							error.FormattedMessagePlaceholderValues != null && error.FormattedMessagePlaceholderValues.Count > 0
							? string.Format(Localizer[error.ErrorMessage], error.FormattedMessagePlaceholderValues?.Select(x => Localizer[x.Value!= null ? x.Value.ToString() : ""]).ToArray())
							: Localizer[error.ErrorMessage]
						)
					).ToList());
			}

			return result.IsValid;
		}

		protected bool ValidateDomain(TEntity entity, bool throwException = true, string message = null)
		{
			if (Localizer == null)
			{
				throw new ArgumentNullException(nameof(Localizer));
			}

			if (EntityValidator == null)
			{
				throw new ArgumentNullException(nameof(DomainValidator));
			}

			var result = DomainValidator.Validate(entity);

			if (!result.IsValid && throwException)
			{
				throw new BusinessException(
					message ?? Localizer["Operation failed in domain validation!"],
					result.Errors.Select(error =>
						new DomainValidationException(
							error.FormattedMessagePlaceholderValues != null && error.FormattedMessagePlaceholderValues.Count > 0
							? string.Format(Localizer[error.ErrorMessage], error.FormattedMessagePlaceholderValues?.Select(x => Localizer[x.Value?.ToString()]).ToArray())
							: Localizer[error.ErrorMessage]
						)
					).ToList());
			}

			return result.IsValid;
		}
	}
}
