namespace api.Exceptions
{
    public class InvalidJwtDataException : Exception
    {
        public InvalidJwtDataException()
        {
        }

        public InvalidJwtDataException(string message) 
        : base(message)
        {
        }

        public InvalidJwtDataException(string message, Exception innerException) 
        : base(message, innerException)
        {
        }
    }
}
