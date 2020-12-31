using System;
using System.Runtime.Serialization;

namespace BAYSOFT.Abstractions.Core.Domain.Exceptions
{
    public class EntityValidationException : Exception
    {
        public string SourceProperty { get; set; }
        public EntityValidationException()
        {
        }

        public EntityValidationException(string message) : base(message)
        {
        }

        public EntityValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public EntityValidationException(string sourceProperty, string message) : base(message)
        {
            SourceProperty = sourceProperty;
        }
    }
}
