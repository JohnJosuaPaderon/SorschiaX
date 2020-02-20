using System;

namespace Sorschia
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
