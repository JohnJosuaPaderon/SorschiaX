namespace Sorschia.Validators
{
    public sealed partial class StringMaxLengthValidator
    {
        public sealed class Configuration : ValidatorConfiguration
        {
            public int MaxLength { get; set; }
        }
    }
}
