using System;
using System.Runtime.Serialization;

namespace BAYSOFT.Abstractions.Core.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException()
        {
        }

        public DomainValidationException(string message) : base(message)
        {
        }

        public DomainValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
