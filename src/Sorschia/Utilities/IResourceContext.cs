using System;

namespace Sorschia.Utilities
{
    public interface IResourceContext : IDisposable
    {
        IResourceContext Register(string name, object resource);
        IResourceContext AttachConsumer(IResourceConsumer consumer);
        TResource Request<TResource>(string name);
    }
}
