namespace Sorschia
{
    public static class IDependencyProviderExtensions
    {
        public static T Get<T>(this IDependencyProvider instance)
        {
            return (T)instance.Get(typeof(T));
        }
    }
}
