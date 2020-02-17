using System;
using System.Runtime.Serialization;

namespace Sorschia.Data
{
    public class SorschiaDataException : SorschiaException
    {
        public SorschiaDataException(bool isMessageViewable = default) : base(isMessageViewable)
        {
        }

        public SorschiaDataException(string message, bool isMessageViewable = default) : base(message, isMessageViewable)
        {
        }

        public SorschiaDataException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException, isMessageViewable)
        {
        }

        protected SorschiaDataException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context, isMessageViewable)
        {
        }
    }
}
