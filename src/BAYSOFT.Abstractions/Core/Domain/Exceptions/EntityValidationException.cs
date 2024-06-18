using System;

namespace BAYSOFT.Abstractions.Core.Domain.Exceptions
{
	public class EntityValidationException : BaysoftException
    {
        public string SourceProperty { get; set; }
        public EntityValidationException() : base(400, 4002000)
        {
        }
        public EntityValidationException(string message) : base(400, 4002000, message)
        {
        }
        public EntityValidationException(string message, Exception innerException) : base(400, 4002000, message, innerException)
        {
        }
        public EntityValidationException(string sourceProperty, string message) : base(400, 4002000, message)
        {
            SourceProperty = sourceProperty;
        }
        public EntityValidationException(int exceptionCode, int exceptionInternalCode) : base(exceptionCode, exceptionInternalCode)
        {
        }
        public EntityValidationException(int exceptionCode, int exceptionInternalCode, string message) : base(exceptionCode, exceptionInternalCode, message)
        {
        }
        public EntityValidationException(int exceptionCode, int exceptionInternalCode, string message, Exception innerException) : base(exceptionCode, exceptionInternalCode, message, innerException)
        {
        }
        public EntityValidationException(int exceptionCode, int exceptionInternalCode, string sourceProperty, string message) : base(exceptionCode, exceptionInternalCode, message)
        {
            SourceProperty = sourceProperty;
        }
    }
}
