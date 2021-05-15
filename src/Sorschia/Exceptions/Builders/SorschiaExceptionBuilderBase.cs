﻿namespace Sorschia.Exceptions.Builders
{
    /// <summary>
    /// Base class for building instances of <see cref="SorschiaException"/>
    /// </summary>
    /// <typeparam name="TSelf">A type of class that derives from <see cref="SorschiaExceptionBuilderBase{TSelf}"/></typeparam>
    public abstract class SorschiaExceptionBuilderBase<TSelf> : ExceptionBuilderBase<TSelf>
    {
        /// <summary>
        /// The message that meant to help the developers to debug the problem
        /// </summary>
        public string? DebugMessage { get; protected set; }

        /// <summary>
        /// Sets <see cref="SorschiaExceptionBuilderBase{TSelf}.DebugMessage"/>
        /// </summary>
        /// <param name="debugMessage">A message that meant to help the developers to debug the problem</param>
        /// <returns>The current builder</returns>
        public virtual TSelf WithDebugMessage(string debugMessage)
        {
            DebugMessage = debugMessage;
            return Self;
        }
    }
}
