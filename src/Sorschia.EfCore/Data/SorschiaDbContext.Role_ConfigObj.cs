using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        internal sealed class Role_ConfigObj : EntityConfigurationBase<Role>
        {
            private readonly DataOptions.Role_OptionsObj _options;

            public Role_ConfigObj(DataOptions.Role_OptionsObj options) : base(options)
            {
                _options = options;
            }

            public override void Configure(EntityTypeBuilder<Role> builder)
            {
                base.Configure(builder);

                builder
                    .Property(_ => _.Id)
                    .ApplyOptions(_options.Id);

                builder
                    .Property(_ => _.Name)
                    .ApplyOptions(_options.Name);

                builder
                    .Property(_ => _.Description)
                    .ApplyOptions(_options.Description);

                builder
                    .Property(_ => _.ApplicationId)
                    .ApplyOptions(_options.ApplicationId);

                builder
                    .HasOne(_ => _.Application)
                    .WithMany(_ => _.Roles)
                    .HasForeignKey(_ => _.ApplicationId);
            }
        }
    }
}
