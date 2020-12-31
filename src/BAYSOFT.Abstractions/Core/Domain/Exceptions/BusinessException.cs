using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BAYSOFT.Abstractions.Core.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public List<EntityValidationException> EntityExceptions { get; set; }
        public List<DomainValidationException> DomainExceptions { get; set; }
        public BusinessException()
        {
            EntityExceptions = new List<EntityValidationException>();
            DomainExceptions = new List<DomainValidationException>();
        }

        public BusinessException(string message) : base(message)
        {
            EntityExceptions = new List<EntityValidationException>();
            DomainExceptions = new List<DomainValidationException>();
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
            EntityExceptions = new List<EntityValidationException>();
            DomainExceptions = new List<DomainValidationException>();
        }

        public BusinessException(string message, List<EntityValidationException> entityExceptions, List<DomainValidationException> domainExceptions) : base(message)
        {
            EntityExceptions = new List<EntityValidationException>();
            DomainExceptions = new List<DomainValidationException>();

            if (entityExceptions != null && entityExceptions.Count > 0)
            {
                EntityExceptions.AddRange(entityExceptions);
            }

            if (domainExceptions != null && domainExceptions.Count > 0)
            {
                DomainExceptions.AddRange(domainExceptions);
            }
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityExceptions = new List<EntityValidationException>();
            DomainExceptions = new List<DomainValidationException>();
        }
    }
}
