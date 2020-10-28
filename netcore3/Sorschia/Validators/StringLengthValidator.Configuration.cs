namespace Sorschia.Validators
{
    public sealed partial class StringLengthValidator
    {
        public sealed class Configuration : ValidatorConfiguration
        {
            public int Length { get; set; }
        }
    }
}
