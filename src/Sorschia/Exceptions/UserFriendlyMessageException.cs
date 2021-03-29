using System;
using System.Runtime.Serialization;

namespace Sorschia.Exceptions
{
    public class UserFriendlyMessageException : SorschiaException
    {
        public UserFriendlyMessageException() : base(true)
        {
        }

        public UserFriendlyMessageException(string message) : base(message, true)
        {
        }

        public UserFriendlyMessageException(string message, Exception innerException) : base(message, innerException, true)
        {
        }

        protected UserFriendlyMessageException(SerializationInfo info, StreamingContext context) : base(info, context, true)
        {
        }
    }
}
