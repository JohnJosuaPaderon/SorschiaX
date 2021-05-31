using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    public abstract class RoleEntityTypeConfigurationBase
    {
        public virtual void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasSoftDelete()
                .HasInsertFootprint()
                .HasUpdateFootprint()
                .HasDeleteFootprint();
        }
    }
}
