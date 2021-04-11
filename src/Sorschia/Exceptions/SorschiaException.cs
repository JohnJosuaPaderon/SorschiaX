using System;

namespace Sorschia.Exceptions
{
    public class SorschiaException : Exception
    {
        public string UserFriendlyMessage { get; }

        public SorschiaException(string message, Exception innerException, string userFriendlyMessage) : base(message, innerException)
        {
            UserFriendlyMessage = userFriendlyMessage;
        }
    }
}
