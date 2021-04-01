﻿using System;
using System.Runtime.Serialization;

namespace Sorschia.Exceptions
{
    public class SorschiaException : Exception
    {
        public bool IsUserFriendlyMessage { get; init; }

        public SorschiaException(bool isUserFriendlyMessage = false)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string? message, bool isUserFriendlyMessage = false) : base(message)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }

        public SorschiaException(string? message, Exception? innerException, bool isUserFriendlyMessage = false) : base(message, innerException)
        {
            IsUserFriendlyMessage = isUserFriendlyMessage;
        }
    }
}