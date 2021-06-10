using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BAYSOFT.Abstractions.Core.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public List<RequestValidationException> RequestExceptions { get; set; }
        public List<EntityValidationException> EntityExceptions { get; set; }
        public List<DomainValidationException> DomainExceptions { get; set; }
        public BusinessException()
        {
            InitializeRequestValidationException();
            InitializeEntityValidationException();
            InitializeDomainValidationException();
        }

        public BusinessException(string message) : base(message)
        {
            InitializeRequestValidationException();
            InitializeEntityValidationException();
            InitializeDomainValidationException();
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
            InitializeRequestValidationException();
            InitializeEntityValidationException();
            InitializeDomainValidationException();
        }

        public BusinessException(string message, List<RequestValidationException> requestExceptions) : base(message)
        {
            InitializeRequestValidationException(requestExceptions);
            InitializeEntityValidationException();
            InitializeDomainValidationException();
        }

        public BusinessException(string message, List<EntityValidationException> entityExceptions) : base(message)
        {
            InitializeRequestValidationException();
            InitializeEntityValidationException(entityExceptions);
            InitializeDomainValidationException();
        }

        public BusinessException(string message, List<DomainValidationException> domainExceptions) : base(message)
        {
            InitializeRequestValidationException();
            InitializeEntityValidationException();
            InitializeDomainValidationException(domainExceptions);
        }

        public BusinessException(string message, List<EntityValidationException> entityExceptions, List<DomainValidationException> domainExceptions) : base(message)
        {
            InitializeRequestValidationException();
            InitializeEntityValidationException(entityExceptions);
            InitializeDomainValidationException(domainExceptions);
        }

        public BusinessException(string message, List<RequestValidationException> requestExceptions, List<DomainValidationException> domainExceptions) : base(message)
        {
            InitializeRequestValidationException(requestExceptions);
            InitializeEntityValidationException();
            InitializeDomainValidationException(domainExceptions);
        }

        public BusinessException(string message, List<RequestValidationException> requestExceptions, List<EntityValidationException> entityExceptions) : base(message)
        {
            InitializeRequestValidationException(requestExceptions);
            InitializeEntityValidationException(entityExceptions);
            InitializeDomainValidationException();
        }

        public BusinessException(string message, List<RequestValidationException> requestExceptions, List<EntityValidationException> entityExceptions, List<DomainValidationException> domainExceptions) : base(message)
        {
            InitializeRequestValidationException(requestExceptions);
            InitializeEntityValidationException(entityExceptions);
            InitializeDomainValidationException(domainExceptions);
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            InitializeRequestValidationException();
            InitializeEntityValidationException();
            InitializeDomainValidationException();
        }

        private void InitializeRequestValidationException(List<RequestValidationException> exceptions = null)
        {
            RequestExceptions = new List<RequestValidationException>();
            if (exceptions != null&& exceptions.Count>0)
            {
                RequestExceptions.AddRange(exceptions);
            }
        }

        private void InitializeEntityValidationException(List<EntityValidationException> exceptions = null)
        {
            EntityExceptions = new List<EntityValidationException>();
            if (exceptions != null && exceptions.Count > 0)
            {
                EntityExceptions.AddRange(exceptions);
            }
        }

        private void InitializeDomainValidationException(List<DomainValidationException> exceptions = null)
        {
            DomainExceptions = new List<DomainValidationException>();
            if (exceptions != null && exceptions.Count > 0)
            {
                DomainExceptions.AddRange(exceptions);
            }
        }
    }
}
