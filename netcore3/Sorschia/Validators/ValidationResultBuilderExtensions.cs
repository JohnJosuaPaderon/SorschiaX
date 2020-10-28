namespace Sorschia.Validators
{
    public static class ValidationResultBuilderExtensions
    {
        public static ValidationResultBuilder Fail(this ValidationResultBuilder instance, string failureMessage)
        {
            return instance
                .SetStatus(false)
                .SetFailureMessage(failureMessage);
        }

        public static ValidationResultBuilder AddDataItem(this ValidationResultBuilder instance, string name, object value)
        {
            return instance
                .AddDataItem(new ValidationResultDataItem
                {
                    Name = name,
                    Value = value
                });
        }
    }
}
