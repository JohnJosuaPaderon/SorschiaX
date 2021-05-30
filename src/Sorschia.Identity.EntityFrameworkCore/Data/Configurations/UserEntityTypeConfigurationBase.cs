using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    public abstract class UserEntityTypeConfigurationBase
    {
        public virtual void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasSoftDelete()
                .HasInsertFootprint()
                .HasUpdateFootprint()
                .HasDeleteFootprint();
        }
    }
}
