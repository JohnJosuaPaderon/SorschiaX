namespace Sorschia.Validators
{
    public sealed partial class NotNullValidator : ValidatorBase, IValidator
    {
        public object Value { get; }

        public NotNullValidator(object value, string failureMessage, string target) : base(failureMessage, target)
        {
            Value = value;
        }

        public NotNullValidator(object value, ValidatorConfiguration configuration) : this(value, configuration.FailureMessage, configuration.Target)
        {
        }

        public ValidationResult Validate()
        {
            var resultBuilder = new ValidationResultBuilder()
                .SetTarget(Target)
                .AddDataItem(nameof(Value), Value);

            if (Value is null)
                resultBuilder.Fail(FailureMessage);

            return resultBuilder.Build();
        }
    }
}
