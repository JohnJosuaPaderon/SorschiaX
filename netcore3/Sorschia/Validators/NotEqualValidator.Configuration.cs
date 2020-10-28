namespace Sorschia.Validators
{
    public sealed partial class NotEqualValidator<T>
    {
        public sealed class Configuration : ValidatorConfiguration
        {
            public T ComparisonValue { get; set; }
        }
    }
}
