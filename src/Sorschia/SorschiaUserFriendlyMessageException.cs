using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaUserFriendlyMessageException : SorschiaException
    {
        public SorschiaUserFriendlyMessageException() : base(true)
        {
        }

        public SorschiaUserFriendlyMessageException(string message) : base(message, true)
        {
        }

        public SorschiaUserFriendlyMessageException(string message, Exception innerException) : base(message, innerException, true)
        {
        }

        protected SorschiaUserFriendlyMessageException(SerializationInfo info, StreamingContext context) : base(info, context, true)
        {
        }
    }
}
