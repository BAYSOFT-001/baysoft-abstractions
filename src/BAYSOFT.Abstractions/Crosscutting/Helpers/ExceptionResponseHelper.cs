using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BAYSOFT.Abstractions.Crosscutting.Helpers
{
    public static class ExceptionResponseHelper
    {
        public static Dictionary<string, object> MapExceptionToDictionary(Exception exception)
        {
            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>();

            exceptionDictionary.Add("message", exception.Message);
            if (exception.InnerException == null)
            {
                exceptionDictionary.Add("innerException", MapExceptionToDictionary(exception.InnerException));
            }

            return exceptionDictionary;
        }
        public static Dictionary<string, object> MapBaysoftExceptionToDictionary(BaysoftException baysoftException)
        {
            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>();

            exceptionDictionary.Add("message", baysoftException.Message);
            if (baysoftException.InnerException == null)
            {
                exceptionDictionary.Add("innerException", MapExceptionToDictionary(baysoftException.InnerException));
            }

            return exceptionDictionary;
        }
        public static Dictionary<string, object> MapBusinessExceptionToDictionary(BusinessException businessException)
        {
            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>();

            exceptionDictionary.Add("message", businessException.Message);

            if (businessException.RequestExceptions != null && businessException.RequestExceptions.Count > 0)
            {
                Dictionary<string, object> requestExceptionDictionary = new Dictionary<string, object>();

                foreach (var group in businessException.RequestExceptions.GroupBy(exception => exception.SourceProperty))
                {
                    requestExceptionDictionary.Add(group.Key, businessException.RequestExceptions.Where(exception => exception.SourceProperty.Equals(group.Key)).Select(exception => exception.Message).ToArray());
                }

                exceptionDictionary.Add("requestExceptions", requestExceptionDictionary);
            }

            if (businessException.EntityExceptions != null && businessException.EntityExceptions.Count > 0)
            {
                Dictionary<string, object> entityExceptionDictionary = new Dictionary<string, object>();

                foreach (var group in businessException.EntityExceptions.GroupBy(x => x.SourceProperty))
                {
                    entityExceptionDictionary.Add(group.Key, businessException.EntityExceptions.Where(exception => exception.SourceProperty.Equals(group.Key)).Select(x => x.Message).ToArray());
                }

                exceptionDictionary.Add("entityExceptions", entityExceptionDictionary);
            }

            if (businessException.DomainExceptions != null && businessException.DomainExceptions.Count > 0)
            {
                exceptionDictionary.Add(
                    "domainExceptions",
                    businessException.DomainExceptions
                        .Select(exception => exception.Message)
                        .ToArray()
                );
            }

            return exceptionDictionary;
        }
    }
}
