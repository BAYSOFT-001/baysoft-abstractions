using BAYSOFT.Abstractions.Core.Domain.Entities;
using ModelWrapper;
using System;
using System.Collections.Generic;

namespace BAYSOFT.Abstractions.Core.Application
{
    public abstract class ApplicationResponse : WrapResponse
    {
        protected ApplicationResponse() : base() { }

        protected ApplicationResponse(int statusCode, int internalCode, object request, object data, Dictionary<string, object> notifications, string message = "Successful operation!", long? resultCount = null)
            : base(statusCode, internalCode, request, data, notifications, message, resultCount)
        {
        }
    }
    public abstract class ApplicationResponse<TEntity> : WrapResponse<TEntity>
        where TEntity : DomainEntity
    {
        protected ApplicationResponse()
        {
        }

        protected ApplicationResponse(WrapRequest<TEntity> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, null, message, resultCount)
        {
        }
        protected ApplicationResponse(int statusCode, int internalCode, WrapRequest<TEntity> request, object data, Dictionary<string, object> notifications = null, string message = "Successful operation!", long? resultCount = null)
            : base(statusCode, internalCode, request, data, notifications, message, resultCount)
        {
        }

        public ApplicationResponse(Tuple<int, int, WrapRequest<TEntity>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple)
            : base(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7)
        {
        }
    }
}
