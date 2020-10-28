namespace Sorschia.Validators
{
    public sealed partial class StringMinLengthValidator : ValidatorBase, IValidator
    {
        public string Value { get; }
        public int MinLength { get; }

        public StringMinLengthValidator(string value, int minLength, string failureMessage, string target) : base(failureMessage, target)
        {
            if (minLength <= 0)
                throw new SorschiaException("MinLength for StringMinLengthValidator cannot be equal or less than zero");

            Value = value;
            MinLength = minLength;
        }

        public StringMinLengthValidator(string value, Configuration configuration) : this(value, configuration.MinLength, configuration.FailureMessage, configuration.Target)
        {
        }

        public ValidationResult Validate()
        {
            var resultBuilder = new ValidationResultBuilder()
                .SetTarget(Target)
                .AddDataItem(nameof(Value), Value)
                .AddDataItem(nameof(MinLength), MinLength);

            if (Value is null || Value.Length < MinLength)
                resultBuilder.Fail(FailureMessage);

            return resultBuilder.Build();
        }
    }
}
