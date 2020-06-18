namespace Sorschia.Utilities
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
    }
}
