using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;
using SystemBase.Extensions;

namespace Sorschia.Identity.Data.EntityTypeConfigurations
{
    internal sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
                .HasSoftDeleteQueryFilter();

            builder.Property(_ => _.Status)
                .HasConversion<byte>();
        }
    }
}
