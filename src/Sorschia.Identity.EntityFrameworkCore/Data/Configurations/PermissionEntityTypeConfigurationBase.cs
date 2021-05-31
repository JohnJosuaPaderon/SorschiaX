using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    public abstract class PermissionEntityTypeConfigurationBase
    {
        public virtual void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder
                .HasSoftDelete()
                .HasInsertFootprint()
                .HasUpdateFootprint()
                .HasDeleteFootprint();
        }
    }
}
