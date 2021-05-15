using System;

namespace Sorschia.Exceptions.Builders
{
    /// <summary>
    /// Represents a contract that builds an instance of <see cref="Exception"/> class.
    /// </summary>
    /// <typeparam name="TException">A class that inherits the <see cref="Exception"/> class.</typeparam>
    public interface IExceptionBuilder<TException> where TException : Exception
    {
        /// <summary>
        /// Builds an instance of <typeparamref name="TException"/> class.
        /// </summary>
        /// <returns>
        ///     <list type="bullet">
        ///         <item>An instance of <typeparamref name="TException"/></item>
        ///         <item>An instance of a class that derives from <see cref="Exception"/> class</item>
        ///     </list>
        /// </returns>
        /// <returns></returns>
        TException Build();
    }
}
