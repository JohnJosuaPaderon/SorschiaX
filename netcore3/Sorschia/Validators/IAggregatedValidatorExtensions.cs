namespace Sorschia.Validators
{
    public static class IAggregatedValidatorExtensions
    {
        public static IAggregatedValidator NotEqual<T>(this IAggregatedValidator instance, T value, T comparisonValue, string failureMessage, string target) =>
            instance.Add(new NotEqualValidator<T>(value, comparisonValue, failureMessage, target));

        public static IAggregatedValidator NotEqual<T>(this IAggregatedValidator instance, T value, NotEqualValidator<T>.Configuration configuration) =>
            instance.Add(new NotEqualValidator<T>(value, configuration));

        public static IAggregatedValidator NotNull(this IAggregatedValidator instance, object value, string failureMessage, string target) =>
            instance.Add(new NotNullValidator(value, failureMessage, target));

        public static IAggregatedValidator NotNull(this IAggregatedValidator instance, object value, ValidatorConfiguration configuration) => 
            instance.Add(new NotNullValidator(value, configuration));

        public static IAggregatedValidator StringLength(this IAggregatedValidator instance, string value, int length, string failureMessage, string target) =>
            instance.Add(new StringLengthValidator(value, length, failureMessage, target));

        public static IAggregatedValidator StringLength(this IAggregatedValidator instance, string value, StringLengthValidator.Configuration configuration) =>
            instance.Add(new StringLengthValidator(value, configuration));

        public static IAggregatedValidator StringMaxLength(this IAggregatedValidator instance, string value, int maxLength, string failureMessage, string target) =>
            instance.Add(new StringMaxLengthValidator(value, maxLength, failureMessage, target));

        public static IAggregatedValidator StringMaxLength(this IAggregatedValidator instance, string value, StringMaxLengthValidator.Configuration configuration) =>
            instance.Add(new StringMaxLengthValidator(value, configuration));

        public static IAggregatedValidator StringMinLength(this IAggregatedValidator instance, string value, int minLength, string failureMessage, string target) =>
            instance.Add(new StringMinLengthValidator(value, minLength, failureMessage, target));

        public static IAggregatedValidator StringMinLength(this IAggregatedValidator instance, string value, StringMinLengthValidator.Configuration configuration) =>
            instance.Add(new StringMinLengthValidator(value, configuration));
    }
}
