using System;

namespace Sorschia.Exceptions
{
    /// <summary>
    /// Represents an error that has been thrown by a Sorschia library or application.
    /// </summary>
    public class SorschiaException : Exception
    {
        /// <summary>
        /// Gets a message that meant to help the developers to debug the problem
        /// </summary>
        public string? DebugMessage { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="SorschiaException"/> with a specified error message, a reference to the inner exception that is the cause of this exception and a message for debugging.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference.</param>
        /// <param name="debugMessage">A detailed message meant to help the developers during debugging. This should not be presented to the end-user.</param>
        public SorschiaException(string? message, Exception? innerException, string? debugMessage) : base(message, innerException)
        {
            DebugMessage = debugMessage;
        }
    }
}
