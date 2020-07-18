using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaForbiddenException : SorschiaException
    {
        public SorschiaForbiddenException() : base(false)
        {
        }

        public SorschiaForbiddenException(string message) : base(message, false)
        {
        }

        public SorschiaForbiddenException(Exception innerException): base(message: "Forbidden", innerException, false)
        {
        }

        public SorschiaForbiddenException(string message, Exception innerException) : base(message, innerException, false)
        {
        }

        protected SorschiaForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
        }
    }
}
