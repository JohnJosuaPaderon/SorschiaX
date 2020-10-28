namespace Sorschia.Validators
{
    public sealed partial class StringMinLengthValidator
    {
        public sealed class Configuration : ValidatorConfiguration
        {
            public int MinLength { get; set; }
        }
    }
}
