using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using ModelWrapper;
using System;

namespace BAYSOFT.Abstractions.Core.Application
{
    public abstract class ApplicationResponse : WrapResponse
    {
        protected ApplicationResponse() : base() { }

        protected ApplicationResponse(int statusCode, int internalCode, object request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(statusCode, internalCode, request, data, message, resultCount)
        {
        }
    }
    public abstract class ApplicationResponse<TEntity> : WrapResponse<TEntity>
        where TEntity : class
    {
        protected ApplicationResponse()
        {
        }

        protected ApplicationResponse(WrapRequest<TEntity> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
        protected ApplicationResponse(int statusCode, int internalCode, WrapRequest<TEntity> request, object data, string message = "Successful operation!", long? resultCount = null) : base(statusCode, internalCode, request, data, message, resultCount)
        {
        }
        protected ApplicationResponse(WrapRequest<TEntity> request, BusinessException businessException, string message = "Unsuccessful operation!", long? resultCount = null)
            : base(businessException.ExceptionCode, businessException.ExceptionInternalCode, request, ExceptionResponseHelper.MapBusinessExceptionToDictionary(businessException), message, resultCount)
        {
        }
        protected ApplicationResponse(WrapRequest<TEntity> request, BaysoftException baysoftException, string message = "Unsuccessful operation!", long? resultCount = null)
            : base(baysoftException.ExceptionCode, baysoftException.ExceptionInternalCode, request, ExceptionResponseHelper.MapBaysoftExceptionToDictionary(baysoftException), message, resultCount)
        {
        }
        protected ApplicationResponse(WrapRequest<TEntity> request, Exception exception, string message = "Unsuccessful operation!", long? resultCount = null)
            : base(400, 400, request, ExceptionResponseHelper.MapExceptionToDictionary(exception), message, resultCount)
        {
        }
    }
}
