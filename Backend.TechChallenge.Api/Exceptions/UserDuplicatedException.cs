using System;
using System.Runtime.Serialization;

namespace Backend.TechChallenge.Api.Exceptions
{
    [Serializable]
    public class UserDuplicatedException : Exception
    {
        public UserDuplicatedException()
        {
        }

        public UserDuplicatedException(string message) : base(message)
        {
        }

        public UserDuplicatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserDuplicatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}