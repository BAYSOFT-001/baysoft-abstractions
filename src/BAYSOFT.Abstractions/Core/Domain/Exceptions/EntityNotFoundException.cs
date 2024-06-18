using BAYSOFT.Abstractions.Core.Domain.Entities;
using Microsoft.Extensions.Localization;
using System;

namespace BAYSOFT.Abstractions.Core.Domain.Exceptions
{
	public class EntityNotFoundException<TEntity> : EntityNotFoundException
        where TEntity : DomainEntity
    {
        public EntityNotFoundException(IStringLocalizer localizer)
            : base(localizer, typeof(TEntity).Name)

        {
        }
        public EntityNotFoundException(IStringLocalizer localizer, int exceptionCode, int exceptionInternalCode)
            : base(exceptionCode, exceptionInternalCode,localizer, typeof(TEntity).Name)

        {
        }
        public EntityNotFoundException(IStringLocalizer localizer, int exceptionInternalCode)
            : base(404, exceptionInternalCode, localizer, typeof(TEntity).Name)

        {
        }
    }
    public class EntityNotFoundException : BaysoftException
    {
        public EntityNotFoundException(IStringLocalizer localizer, string nameofEntity)
            : base(404, 4040000, string.Format(localizer["{0} not found!"], localizer[nameofEntity]))

        {
        }
        public EntityNotFoundException() : base(404, 4040000)
        {
        }
        public EntityNotFoundException(string message)
            : base(404, 4040000, message)
        {
        }
        public EntityNotFoundException(string message, Exception innerException)
            : base(404, 4040000, message, innerException)
        {
        }
        public EntityNotFoundException(int exceptionCode, int exceptionInternalCode, IStringLocalizer localizer, string nameofEntity)
            : base(exceptionCode, exceptionInternalCode, string.Format(localizer["{0} not found!"], localizer[nameofEntity]))

        {
        }
        public EntityNotFoundException(int exceptionCode, int exceptionInternalCode)
            : base(exceptionCode, exceptionInternalCode)
        {
        }
        public EntityNotFoundException(int exceptionCode, int exceptionInternalCode, string message)
            : base(exceptionCode, exceptionInternalCode, message)
        {
        }
        public EntityNotFoundException(int exceptionCode, int exceptionInternalCode, string message, Exception innerException)
            : base(exceptionCode, exceptionInternalCode, message, innerException)
        {
        }
    }
}
