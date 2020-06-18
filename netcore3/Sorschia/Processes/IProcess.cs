using System;

namespace Sorschia.Processes
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
