namespace Sorschia.Validators
{
    public interface IAggregatedValidator
    {
        bool IsFailFast { get; }
        IAggregatedValidator Add(IValidator validator);
        AggregatedValidationResult Validate();
    }
}
