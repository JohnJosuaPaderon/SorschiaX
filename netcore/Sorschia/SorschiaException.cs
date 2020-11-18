using System;

namespace Sorschia
{
    public class SorschiaException : Exception
    {
        public bool IsUserFriendlyMessage { get; }

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

        public static SorschiaException UserFriendly(string message) => new SorschiaException(message, true);

        public static SorschiaException UserFriendly(string message, Exception innerException) => new SorschiaException(message, innerException, true);
    }
}
