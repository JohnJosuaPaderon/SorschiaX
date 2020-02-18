using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaWPFException : SorschiaException
    {
        public SorschiaWPFException(bool isMessageViewable = default) : base(isMessageViewable)
        {
        }

        public SorschiaWPFException(string message, bool isMessageViewable = default) : base(message, isMessageViewable)
        {
        }

        public SorschiaWPFException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException, isMessageViewable)
        {
        }

        protected SorschiaWPFException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context, isMessageViewable)
        {
        }
    }
}
