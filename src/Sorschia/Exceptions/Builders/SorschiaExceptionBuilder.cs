using System.Collections.Generic;

namespace Sorschia.Exceptions.Builders
{
    public sealed class SorschiaExceptionBuilder : SorschiaExceptionBuilderBase<SorschiaExceptionBuilder, SorschiaException>
    {
        public override SorschiaException Build()
        {
            return new SorschiaException(Message, InnerException, IsUserFriendlyMessage);
        }

        protected override SorschiaExceptionBuilder GetInstance() => this;
    }

    public sealed class ValidationExceptionBuilder : SorschiaExceptionBuilderBase<ValidationExceptionBuilder, ValidationException>
    {
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();

        public override ValidationException Build()
        {
            return new ValidationException(Errors, Message, InnerException, IsUserFriendlyMessage);
        }

        protected override ValidationExceptionBuilder GetInstance() => this;

        public ValidationExceptionBuilder AddErrors(KeyValuePair<string, string[]>[] errorPairs)
        {
            if (errorPairs is not null)
            {
                
            }

            return GetInstance();
        }

        public ValidationExceptionBuilder AddError(string propertyName, string[] errorMessages)
        {
            if (string.IsNullOrWhiteSpace(propertyName) || errorMessages is null || errorMessages.Length == 0) return GetInstance();

            if (Errors.ContainsKey(propertyName))

            return GetInstance();
        }
    }
}
