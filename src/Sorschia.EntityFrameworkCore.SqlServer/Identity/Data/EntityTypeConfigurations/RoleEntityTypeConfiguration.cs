using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;
using SystemBase.Extensions;

namespace Sorschia.Identity.Data.EntityTypeConfigurations
{
    internal sealed class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role")
                .HasSoftDeleteQueryFilter();
        }
    }
}
