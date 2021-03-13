using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaException : Exception
    {
        public bool IsUserFriendlyMessage { get; init; }

        public SorschiaException(bool isUserFriendlyMessage = false)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string message, bool isUserFriendlyMessage = false) : base(message)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string message, Exception innerException, bool isUserFriendlyMessage = false) : base(message, innerException)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        protected SorschiaException(SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(info, context)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }
    }
}
