using System;
using System.Runtime.Serialization;

namespace Sorschia.Caching
{
    public class SorschiaCachingException : SorschiaException
    {
        public SorschiaCachingException(bool isMessageViewable = default) : base(isMessageViewable)
        {
        }

        public SorschiaCachingException(string message, bool isMessageViewable = default) : base(message, isMessageViewable)
        {
        }

        public SorschiaCachingException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException, isMessageViewable)
        {
        }

        protected SorschiaCachingException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context, isMessageViewable)
        {
        }
    }
}
