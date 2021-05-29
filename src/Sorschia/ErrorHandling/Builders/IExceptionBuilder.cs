using System;

namespace Sorschia.ErrorHandling.Builders
{
    public interface IExceptionBuilder<TException> where TException : Exception
    {
        TException Build();
    }
}
