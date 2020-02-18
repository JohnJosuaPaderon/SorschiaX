using Prism.Ioc;

namespace Sorschia
{
    public static class IContainerRegistryExtensions
    {
        public static IContainerRegistry AddTransient<T>(this IContainerRegistry instance, T instanceValue)
        {
            instance.RegisterInstance(instanceValue);
            return instance;
        }

        public static IContainerRegistry AddTransient<T>(this IContainerRegistry instance)
        {
            instance.Register<T>();
            return instance;
        }

        public static IContainerRegistry AddTransient<TContract, TImplementation>(this IContainerRegistry instance)
            where TImplementation : TContract
        {
            instance.Register<TContract, TImplementation>();
            return instance;
        }

        public static IContainerRegistry AddSingleton<TContract, TImplementation>(this IContainerRegistry instance)
            where TImplementation : TContract
        {
            instance.RegisterSingleton<TContract, TImplementation>();
            return instance;
        }

        public static IContainerRegistry AddSingleton<T>(this IContainerRegistry instance)
        {
            instance.RegisterSingleton<T>();
            return instance;
        }
    }
}
