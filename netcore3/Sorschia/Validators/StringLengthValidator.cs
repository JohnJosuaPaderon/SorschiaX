namespace Sorschia.Validators
{
    public sealed partial class StringLengthValidator : ValidatorBase, IValidator
    {
        public string Value { get; }
        public int Length { get; }

        public StringLengthValidator(string value, int length, string failureMessage, string target) : base(failureMessage, target)
        {
            if (length <= 0)
                throw new SorschiaException("Length for StringLengthValidator cannot be equal or less than zero");

            Value = value;
            Length = length;
        }

        public StringLengthValidator(string value, Configuration configuration) : this(value, configuration.Length, configuration.FailureMessage, configuration.Target)
        {
        }

        public ValidationResult Validate()
        {
            var resultBuilder = new ValidationResultBuilder()
                .SetTarget(Target)
                .AddDataItem(nameof(Value), Value)
                .AddDataItem(nameof(Length), Length);

            if (Value is null || Value.Length != Length)
                resultBuilder.Fail(FailureMessage);

            return resultBuilder.Build();
        }
    }
}
