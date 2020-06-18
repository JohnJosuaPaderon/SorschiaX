using System;
using System.Runtime.Serialization;

namespace Sorschia.Security
{
    public class SorschiaSecurityException : SorschiaException
    {
        public SorschiaSecurityException(bool isMessageViewable = default) : base(isMessageViewable)
        {
        }

        public SorschiaSecurityException(string message, bool isMessageViewable = default) : base(message, isMessageViewable)
        {
        }

        public SorschiaSecurityException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException, isMessageViewable)
        {
        }

        protected SorschiaSecurityException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context, isMessageViewable)
        {
        }
    }
}
