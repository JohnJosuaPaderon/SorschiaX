namespace Sorschia.Exceptions.Builders
{
    public abstract class SorschiaExceptionBuilderBase<TSelf, TException> : ExceptionBuilderBase<TSelf, TException> where TException : SorschiaException
    {
        public string UserFriendlyMessage { get; protected set; }

        public TSelf WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return Self;
        }
    }
}
