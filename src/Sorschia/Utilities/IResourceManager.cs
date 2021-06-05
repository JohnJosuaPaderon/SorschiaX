namespace Sorschia.Utilities
{
    public interface IResourceManager
    {
        IResourceContext CreateContext();
        IResourceContext GetContext(IResourceConsumer consumer);
        void Attach(IResourceContext context, IResourceConsumer consumer);
        void Dispose(IResourceContext context);
    }
}
