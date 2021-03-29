namespace Sorschia.Exceptions.Builders
{
    public abstract class SorschiaExceptionBuilderBase<TInstance, TException> : ExceptionBuilderBase<TInstance, TException> where TException : SorschiaException
    {
        public bool IsUserFriendlyMessage { get; protected set; }

        public virtual TInstance WithUserFriendlyMessage(string message)
        {
            IsUserFriendlyMessage = true;
            return WithMessage(message);
        }
    }
}
