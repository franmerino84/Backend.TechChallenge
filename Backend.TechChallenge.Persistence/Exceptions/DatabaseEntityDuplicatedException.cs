using System.Runtime.Serialization;

namespace Backend.TechChallenge.Persistence.File.Exceptions
{
    [Serializable]
    public class DatabaseEntityDuplicatedException : Exception
    {
        public DatabaseEntityDuplicatedException()
        {
        }

        public DatabaseEntityDuplicatedException(string? message) : base(message)
        {
        }

        public DatabaseEntityDuplicatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DatabaseEntityDuplicatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}