using System;

namespace Sorschia.Process
{
    public interface IProcess : IDisposable
    {
        void Execute();
    }

    public interface IProcess<T> : IDisposable
    {
        T Execute();
    }
}
