using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Extensions;
using Microsoft.Extensions.Localization;
using ModelWrapper;
using ModelWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Helpers
{
	public static class ExceptionResponseHelper
    {
        public static Tuple<int, int, WrapRequest<TEntity>, Dictionary<string, object>, Dictionary<string, object>, string, long?> CreateTuple<TEntity>(IStringLocalizer localizer, WrapRequest<TEntity> request, Exception exception, string message = "Unsuccessful operation!", long? resultCount = null)
            where TEntity : class
		{
            string localizedMessage = localizer[message].ToString();

            if (exception is BusinessException)
            {
                var businessException = exception as BusinessException;
                return (businessException.ExceptionCode, businessException.ExceptionInternalCode, request, default(Dictionary<string, object>), MapBusinessExceptionToDictionary(localizer, businessException), localizedMessage, resultCount).ToTuple();
            }

            if (exception is BaysoftException)
            {
                var baysoftException = exception as BaysoftException;
                return (baysoftException.ExceptionCode, baysoftException.ExceptionInternalCode, request, default(Dictionary<string, object>), MapBaysoftExceptionToDictionary(localizer, baysoftException), localizedMessage, resultCount).ToTuple();
            }

            return (400, 400, request, default(Dictionary<string, object>), MapExceptionToDictionary(localizer, exception), localizedMessage, resultCount).ToTuple();
        }
        internal static Dictionary<string, object> MapExceptionToDictionary(IStringLocalizer localizer, Exception exception)
        {
            if (exception is BusinessException)
            {
                return MapBusinessExceptionToDictionary(localizer, exception as BusinessException);
            }

            if (exception is BaysoftException)
            {
                return MapBaysoftExceptionToDictionary(localizer, exception as BaysoftException);
            }

            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>
            {
                { Constants.CONST_NOTIFICATIONS_MESSAGE, localizer[exception.Message].ToString() }
            };

            if (exception.InnerException != null)
            {
                exceptionDictionary.Add(Constants.CONST_NOTIFICATIONS_INNER, MapExceptionToDictionary(localizer, exception.InnerException));
            }

            return exceptionDictionary;
        }
        internal static Dictionary<string, object> MapBaysoftExceptionToDictionary(IStringLocalizer localizer, BaysoftException baysoftException)
        {
            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>
            {
                { Constants.CONST_NOTIFICATIONS_MESSAGE, localizer[baysoftException.Message].ToString() }
            };

            if (baysoftException.InnerException != null)
            {
                exceptionDictionary.Add(Constants.CONST_NOTIFICATIONS_INNER, MapExceptionToDictionary(localizer, baysoftException.InnerException));
            }

            return exceptionDictionary;
        }
        internal static Dictionary<string, object> MapBusinessExceptionToDictionary(IStringLocalizer localizer, BusinessException businessException)
        {
            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>
            {
                { Constants.CONST_NOTIFICATIONS_MESSAGE, localizer[businessException.Message].ToString() }
            };

            if (businessException.RequestExceptions != null && businessException.RequestExceptions.Count > 0)
            {
                Dictionary<string, object> requestExceptionDictionary = new Dictionary<string, object>();

                foreach (var group in businessException.RequestExceptions.GroupBy(exception => exception.SourceProperty))
                {
                    requestExceptionDictionary.Add(group.Key.ToCamelCase(), businessException.RequestExceptions.Where(exception => exception.SourceProperty.Equals(group.Key)).Select(exception => localizer[exception.Message].ToString()).ToArray());
                }

                exceptionDictionary.Add(Constants.CONST_NOTIFICATIONS_REQUEST, requestExceptionDictionary);
            }

            if (businessException.EntityExceptions != null && businessException.EntityExceptions.Count > 0)
            {
                Dictionary<string, object> entityExceptionDictionary = new Dictionary<string, object>();

                foreach (var group in businessException.EntityExceptions.GroupBy(x => x.SourceProperty))
                {
                    entityExceptionDictionary.Add(group.Key.ToCamelCase(), businessException.EntityExceptions.Where(exception => exception.SourceProperty.Equals(group.Key)).Select(x => localizer[x.Message].ToString()).ToArray());
                }

                exceptionDictionary.Add(Constants.CONST_NOTIFICATIONS_ENTITY, entityExceptionDictionary);
            }

            if (businessException.DomainExceptions != null && businessException.DomainExceptions.Count > 0)
            {
                exceptionDictionary.Add(
                    Constants.CONST_NOTIFICATIONS_DOMAIN,
                    businessException.DomainExceptions
                        .Select(exception => localizer[exception.Message].ToString())
                        .ToArray()
                );
            }

            return exceptionDictionary;
        }
    }
}