namespace Sorschia
{
    public interface IDependencyProvider
    {
        T Get<T>();
    }
}
