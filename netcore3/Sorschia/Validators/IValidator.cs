namespace Sorschia.Validators
{
    public interface IValidator
    {
        string FailureMessage { get; }
        string Target { get; }
        ValidationResult Validate();
    }
}
