using System;
using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Exceptions
{
    public class ValidationException : SorschiaException
    {
        public ValidationErrorCollection? Errors { get; }

        public ValidationException(ValidationErrorCollection? errors, bool isUserFriendlyMessage = false) : base(isUserFriendlyMessage)
        {
            Errors = errors;
        }

        public ValidationException(ValidationErrorCollection? errors, string? message, bool isUserFriendlyMessage = false) : base(message, isUserFriendlyMessage)
        {
            Errors = errors;
        }

        public ValidationException(ValidationErrorCollection? errors, string? message, Exception? innerException, bool isUserFriendlyMessage = false) : base(message, innerException, isUserFriendlyMessage)
        {
            Errors = errors;
        }

        
    }

    public class ValidationErrorCollection : IEnumerable<KeyValuePair<string, string[]>>
    {
        private readonly IDictionary<string, string[]> _source = new Dictionary<string, string[]>();

        public IEnumerator<KeyValuePair<string, string[]>> GetEnumerator() => _source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(string propertyName, string[] errors)
        {
            if (string.IsNullOrWhiteSpace(propertyName) )

            if (_source.ContainsKey(propertyName))
            {
                var persistedErrors = _source[propertyName];
            }
        }

        private bool ValidatePropertyName(string propertyName)
        {
            return !string.IsNullOrWhiteSpace(propertyName)
        }
    }
}
