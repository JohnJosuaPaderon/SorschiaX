namespace Sorschia.Validators
{
    public abstract class ValidatorBase
    {
        public string FailureMessage { get; }
        public string Target { get; }

        public ValidatorBase(string failureMessage, string target)
        {
            FailureMessage = failureMessage;
            Target = target;
        }
    }
}
