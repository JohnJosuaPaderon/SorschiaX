using Sorschia.Exceptions;
using System;

namespace Sorschia.Data.Exceptions
{
    public class InvalidDbContextException : SorschiaException
    {
        public Type DbContextType { get; }

        public InvalidDbContextException(string message, Exception innerException, string userFriendlyMessage, Type dbContextType) : base(message, innerException, userFriendlyMessage)
        {
            DbContextType = dbContextType;
        }
    }
}
