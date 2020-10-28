using Sorschia.Utilities;

namespace Sorschia.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly IDependencyResolver _dependencyResolver;

        public RepositoryBase(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        protected T GetProcess<T>() => _dependencyResolver.Resolve<T>();
    }
}
