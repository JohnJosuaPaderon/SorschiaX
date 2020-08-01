using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Data
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection instance, DataDependencySettings dependencySettings)
        {
            if (dependencySettings is null)
                throw SorschiaException.DependencySettingsIsNull<DataDependencySettings>();

            if (dependencySettings.UseDefaultFieldNameCache)
                instance.AddTransient<IFieldNameCache, FieldNameCache>();

            return instance;
        }
    }
}
