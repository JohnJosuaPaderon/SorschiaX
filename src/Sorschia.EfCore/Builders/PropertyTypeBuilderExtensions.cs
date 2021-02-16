using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Data;

namespace Sorschia.Builders
{
    public static class PropertyTypeBuilderExtensions
    {
        public static PropertyBuilder<TProperty> TryHasColumnName<TProperty>(this PropertyBuilder<TProperty> instance, string name)
        {
            if (name is not null)
                instance.HasColumnName(name);

            return instance;
        }

        public static PropertyBuilder<TProperty> TryIsRequired<TProperty>(this PropertyBuilder<TProperty> instance, bool? required)
        {
            if (required is not null)
                instance.IsRequired(required.Value);

            return instance;
        }

        public static PropertyBuilder<TProperty> Apply<TProperty>(this PropertyBuilder<TProperty> instance, ColumnSettings settings)
        {
            return instance
                .TryHasColumnName(settings.ColumnName)
                .TryIsRequired(settings.IsRequired);
        }
    }
}
