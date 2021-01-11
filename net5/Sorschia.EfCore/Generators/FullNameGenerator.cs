using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Sorschia.Entities;
using Sorschia.Utilities;

namespace Sorschia.Generators
{
    public sealed class FullNameGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            var builder = entry.Context.GetService<IFullNameBuilder>();

            if (entry.Entity is INameable nameable)
                return builder.Generate(nameable);

            return null;
        }
    }
}
