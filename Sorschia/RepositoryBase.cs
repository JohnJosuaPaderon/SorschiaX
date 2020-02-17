namespace Sorschia
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(IDependencyProvider dependencyProvider)
        {
            _dependencyProvider = dependencyProvider;
        }

        private readonly IDependencyProvider _dependencyProvider;

        protected T GetProcess<T>()
        {
            return _dependencyProvider.Get<T>();
        }
    }
}
