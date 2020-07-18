using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaUnauthorizedException : SorschiaException
    {
        public SorschiaUnauthorizedException() : base(false)
        {
        }

        public SorschiaUnauthorizedException(string message) : base(message, false)
        {
        }

        public SorschiaUnauthorizedException(Exception innerException): base("Unauthorized", innerException, false)
        {
        }

        public SorschiaUnauthorizedException(string message, Exception innerException) : base(message, innerException, false)
        {
        }

        protected SorschiaUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
        }
    }
}
