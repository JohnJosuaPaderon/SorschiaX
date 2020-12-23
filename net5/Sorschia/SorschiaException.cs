using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public sealed class SorschiaException : Exception
    {
        public bool IsUserFriendlyMessage { get; set; }

        public SorschiaException(bool isUserFriendlyMessage = false)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string? message, bool isUserFriendlyMessage = false) : base(message)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(info, context)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string? message, Exception? innerException, bool isUserFriendlyMessage = false) : base(message, innerException)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }
    }
}
