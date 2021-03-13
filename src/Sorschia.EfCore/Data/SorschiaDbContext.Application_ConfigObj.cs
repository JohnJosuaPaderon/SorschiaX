using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        internal sealed class Application_ConfigObj : EntityConfigurationBase<Application>
        {
            private readonly DataOptions.Application_OptionsObj _options;

            public Application_ConfigObj(DataOptions.Application_OptionsObj options) : base(options)
            {
                _options = options;
            }

            public override void Configure(EntityTypeBuilder<Application> builder)
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
            }
        }
    }
}
