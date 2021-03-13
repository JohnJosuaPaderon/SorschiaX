using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        internal sealed class PermissionAspNetRoute_ConfigObj : EntityConfigurationBase<PermissionAspNetRoute>
        {
            private readonly DataOptions.PermissionAspNetRoute_OptionsObj _options;

            public PermissionAspNetRoute_ConfigObj(DataOptions.PermissionAspNetRoute_OptionsObj options) : base(options)
            {
                _options = options;
            }

            public override void Configure(EntityTypeBuilder<PermissionAspNetRoute> builder)
            {
                base.Configure(builder);

                builder
                    .Property(_ => _.Id)
                    .ApplyOptions(_options.Id);

                builder
                    .Property(_ => _.AspNetArea)
                    .ApplyOptions(_options.AspNetArea);

                builder
                    .Property(_ => _.AspNetController)
                    .ApplyOptions(_options.AspNetController);

                builder
                    .Property(_ => _.AspNetAction)
                    .ApplyOptions(_options.AspNetAction);

                builder
                    .Property(_ => _.PermissionId)
                    .ApplyOptions(_options.PermissionId);

                builder
                    .HasOne(_ => _.Permission)
                    .WithMany(_ => _.AspNetRoutes)
                    .HasForeignKey(_ => _.PermissionId);
            }
        }
    }
}
