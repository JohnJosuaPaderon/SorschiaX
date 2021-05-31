using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    public abstract class UserRoleEntityTypeConfigurationBase
    {
        public virtual void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder
                .HasSoftDelete()
                .HasInsertFootprint()
                .HasDeleteFootprint();

            builder.HasOne(_ => _.User)
                .WithMany(_ => _.UserRoles)
                .HasForeignKey(_ => _.UserId);

            builder.HasOne(_ => _.Role)
                .WithMany()
                .HasForeignKey(_ => _.RoleId);
        }
    }
}
