using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        internal sealed class Permission_ConfigObj : EntityConfigurationBase<Permission>
        {
            private readonly DataOptions.Permission_OptionsObj _options;

            public Permission_ConfigObj(DataOptions.Permission_OptionsObj options) : base(options)
            {
                _options = options;
            }

            public override void Configure(EntityTypeBuilder<Permission> builder)
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
                    .Property(_ => _.LookupKey)
                    .ApplyOptions(_options.LookupKey);

                builder
                    .Property(_ => _.ApplicationId)
                    .ApplyOptions(_options.ApplicationId);

                builder
                    .Property(_ => _.RoleId)
                    .ApplyOptions(_options.RoleId);

                builder
                    .HasOne(_ => _.Application)
                    .WithMany(_ => _.Permissions)
                    .HasForeignKey(_ => _.ApplicationId);

                builder
                    .HasOne(_ => _.Role)
                    .WithMany(_ => _.Permissions)
                    .HasForeignKey(_ => _.RoleId);
            }
        }
    }
}
