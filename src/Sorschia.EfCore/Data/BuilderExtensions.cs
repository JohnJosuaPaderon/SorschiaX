using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sorschia.Data
{
    public static class BuilderExtensions
    {
        public static PropertyBuilder<TProperty> ApplyOptions<TProperty>(this PropertyBuilder<TProperty> instance, PropertyOptions options)
        {
            if (options is null)
                throw new SorschiaException($"argument '{nameof(options)}' cannot be null");

            instance.HasColumnName(options.ColumnName);

            if (options.IsRequired is not null)
                instance.IsRequired(options.IsRequired.Value);

            return instance;
        }

        public static PropertyBuilder<TProperty> ApplyOptions<TProperty>(this PropertyBuilder<TProperty> instance, StringPropertyOptions options)
        {
            if (options is null)
                throw new SorschiaException($"argument '{nameof(options)}' cannot be null");

            instance.HasColumnName(options.ColumnName);

            if (options.IsRequired is not null)
                instance.IsRequired(options.IsRequired.Value);

            if (options.MaxLength is not null)
                instance.HasMaxLength(options.MaxLength.Value);

            return instance;
        }
    }
}
