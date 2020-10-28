namespace Sorschia.Validators
{
    public sealed partial class StringMaxLengthValidator : ValidatorBase, IValidator
    {
        public string Value { get; }
        public int MaxLength { get; }

        public StringMaxLengthValidator(string value, int maxLength, string failureMessage, string target) : base(failureMessage, target)
        {
            if (maxLength <= 0)
                throw new SorschiaException("MaxLength for StringMaxLengthValidator cannot be equal or less than zero");

            Value = value;
            MaxLength = maxLength;
        }

        public StringMaxLengthValidator(string value, Configuration configuration) : this(value, configuration.MaxLength, configuration.FailureMessage, configuration.Target)
        {
        }

        public ValidationResult Validate()
        {
            var resultBuilder = new ValidationResultBuilder()
                .SetTarget(Target)
                .AddDataItem(nameof(Value), Value)
                .AddDataItem(nameof(MaxLength), MaxLength);

            if (Value is null || Value.Length < MaxLength)
                resultBuilder.Fail(FailureMessage);

            return resultBuilder.Build();
        }
    }
}
