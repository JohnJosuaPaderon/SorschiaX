using System;
using System.Runtime.Serialization;

namespace Sorschia.Process
{
    public class SorschiaProcessException : SorschiaException
    {
        public SorschiaProcessException(bool isMessageViewable = default) : base(isMessageViewable)
        {
        }

        public SorschiaProcessException(string message, bool isMessageViewable = default) : base(message, isMessageViewable)
        {
        }

        public SorschiaProcessException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException, isMessageViewable)
        {
        }

        protected SorschiaProcessException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context, isMessageViewable)
        {
        }
    }
}
