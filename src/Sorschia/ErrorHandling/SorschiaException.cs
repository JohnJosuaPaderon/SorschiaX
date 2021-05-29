using System;

namespace Sorschia.ErrorHandling
{
    public class SorschiaException : Exception
    {
        public string DebugMessage { get; }

        public SorschiaException()
        {
        }

        public SorschiaException(string message, Exception innerException, string debugMessage) : base(message, innerException)
        {
            DebugMessage = debugMessage;
        }
    }
}
