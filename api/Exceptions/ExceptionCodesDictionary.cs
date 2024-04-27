using System.Net;

namespace api.Exceptions
{
    public class ExceptionCodesDictionary
    {
        private static Dictionary<Type, HttpStatusCode> exceptionCodesDictionary = new Dictionary<Type, HttpStatusCode>
        {
            { typeof(InvalidUserDataException), HttpStatusCode.Unauthorized},
            { typeof(InvalidJwtDataException), HttpStatusCode.BadRequest}
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool isExceptionFound = exceptionCodesDictionary.TryGetValue(exception.GetType(), out var statusCode);
            return isExceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }
    }
}