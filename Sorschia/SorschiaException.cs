using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaException : Exception
    {
        public SorschiaException(bool isMessageViewable = default)
        {
            IsMessageViewable = isMessageViewable;
        }

        public SorschiaException(string message, bool isMessageViewable = default) : base(message)
        {
            IsMessageViewable = isMessageViewable;
        }

        public SorschiaException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException)
        {
            IsMessageViewable = isMessageViewable;
        }

        protected SorschiaException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context)
        {
            IsMessageViewable = isMessageViewable;
        }

        public bool IsMessageViewable { get; set; }
    }
}
