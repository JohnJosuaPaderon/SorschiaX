namespace Sorschia.Validators
{
    public sealed partial class NotEqualValidator<T> : ValidatorBase, IValidator
    {
        public T Value { get; }
        public T ComparisonValue { get; }

        public NotEqualValidator(T value, T comparisonValue, string failureMessage, string target) : base(failureMessage, target)
        {
            Value = value;
            ComparisonValue = comparisonValue;
        }

        public NotEqualValidator(T value, Configuration configuration) : this(value, configuration.ComparisonValue, configuration.FailureMessage, configuration.Target)
        {
        }

        public ValidationResult Validate()
        {
            var resultBuilder = new ValidationResultBuilder()
                .SetTarget(Target)
                .AddDataItem(nameof(Value), Value)
                .AddDataItem(nameof(ComparisonValue), ComparisonValue);

            if (Equals(Value, ComparisonValue))
                resultBuilder.Fail(FailureMessage);

            return resultBuilder.Build();
        }
    }
}
