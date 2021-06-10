using System;
using System.Runtime.Serialization;

namespace BAYSOFT.Abstractions.Core.Domain.Exceptions
{
    public class RequestValidationException : Exception
    {
        public string SourceProperty { get; set; }
        public RequestValidationException()
        {
        }

        public RequestValidationException(string message) : base(message)
        {
        }

        public RequestValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RequestValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public RequestValidationException(string sourceProperty, string message) : base(message)
        {
            SourceProperty = sourceProperty;
        }
    }
}
