using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaException : Exception
    {
        public bool IsUserFriendlyMessage { get; }

        public SorschiaException()
        {
            IsUserFriendlyMessage = false;
        }

        public SorschiaException(bool isUserFriendlyMessage)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string? message) : base(message)
        {
            IsUserFriendlyMessage = false;
        }

        public SorschiaException(string? message, bool isUserFriendlyMessage) : base(message)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string? message, Exception? innerException) : base(message, innerException)
        {
            IsUserFriendlyMessage = false;
        }

        public SorschiaException(string? message, Exception? innerException, bool isUserFriendlyMessage) : base(message, innerException)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        protected SorschiaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            IsUserFriendlyMessage = false;
        }

        protected SorschiaException(SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage) : base(info, context)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }
    }
}
