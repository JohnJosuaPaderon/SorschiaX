using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using Sorschia.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    internal sealed partial class SorschiaDbContext : DbContext
    {
        private readonly SorschiaDataSettings _settings;

        public DbSet<Application> Applications { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public SorschiaDbContext(DbContextOptions options, IOptions<SorschiaDataSettings> settingsAccessor) : base(options)
        {
            _settings = settingsAccessor.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema(_settings.DefaultSchema)
                .ApplyConfiguration(new ApplicationConfiguration(_settings.Application))
                .ApplyConfiguration(new PermissionConfiguration(_settings.Permission))
                .ApplyConfiguration(new RoleConfiguration(_settings.Role))
                .ApplyConfiguration(new UserConfiguration(_settings.User))
                .ApplyConfiguration(new UserApplicationConfiguration(_settings.UserApplication))
                .ApplyConfiguration(new UserPermissionConfiguration(_settings.UserPermission))
                .ApplyConfiguration(new UserRoleConfiguration(_settings.UserRole));
        }

        private sealed class ApplicationConfiguration : EntityConfigurationBase<Application>
        {
            private readonly SorschiaDataSettings.ApplicationTableSettings _settings;

            public ApplicationConfiguration(SorschiaDataSettings.ApplicationTableSettings settings) : base(settings)
            {
                _settings = settings;
            }

            public override void Configure(EntityTypeBuilder<Application> builder)
            {
                builder.HasInt32IdentityColumn(_settings.Id);
                builder.Property(_ => _.Name).Apply(_settings.Name);
                builder.Property(_ => _.Description).Apply(_settings.Description);

                base.Configure(builder);
            }
        }

        private sealed class PermissionConfiguration : EntityConfigurationBase<Permission>
        {
            private readonly SorschiaDataSettings.PermissionTableSettings _settings;

            public PermissionConfiguration(SorschiaDataSettings.PermissionTableSettings settings) : base(settings)
            {
                _settings = settings;
            }

            public override void Configure(EntityTypeBuilder<Permission> builder)
            {
                builder.HasInt32IdentityColumn(_settings.Id);
                builder.Property(_ => _.Name).Apply(_settings.Name);
                builder.Property(_ => _.Description).Apply(_settings.Description);
                builder.Property(_ => _.ApplicationId).Apply(_settings.ApplicationId);
                builder.Property(_ => _.RoleId).Apply(_settings.RoleId);
                builder.Property(_ => _.WebController).Apply(_settings.WebController);
                builder.Property(_ => _.WebAction).Apply(_settings.WebAction);

                builder
                    .HasOne(_ => _.Application)
                    .WithMany(_ => _.Permissions)
                    .HasForeignKey(_ => _.ApplicationId);

                builder
                    .HasOne(_ => _.Role)
                    .WithMany(_ => _.Permissions)
                    .HasForeignKey(_ => _.RoleId);

                base.Configure(builder);
            }
        }

        private sealed class RoleConfiguration : EntityConfigurationBase<Role>
        {
            private readonly SorschiaDataSettings.RoleSettings _settings;

            public RoleConfiguration(SorschiaDataSettings.RoleSettings settings) : base(settings)
            {
                _settings = settings;
            }

            public override void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.HasInt32IdentityColumn(_settings.Id);
                builder.Property(_ => _.Name).Apply(_settings.Name);
                builder.Property(_ => _.Description).Apply(_settings.Description);
                builder.Property(_ => _.ApplicationId).Apply(_settings.ApplicationId);

                builder
                    .HasOne(_ => _.Application)
                    .WithMany(_ => _.Roles)
                    .HasForeignKey(_ => _.ApplicationId);

                base.Configure(builder);
            }
        }

        private sealed class UserConfiguration : EntityConfigurationBase<User>
        {
            private readonly SorschiaDataSettings.UserSettings _settings;

            public UserConfiguration(SorschiaDataSettings.UserSettings settings) : base(settings)
            {
                _settings = settings;
            }

            public override void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasInt32IdentityColumn(_settings.Id);
                builder.Property(_ => _.FirstName).Apply(_settings.FirstName);
                builder.Property(_ => _.MiddleName).Apply(_settings.MiddleName);
                builder.Property(_ => _.LastName).Apply(_settings.LastName);
                builder.Property(_ => _.NameSuffix).Apply(_settings.NameSuffix);
                builder.Property(_ => _.FullName).Apply(_settings.FullName);
                builder.Property(_ => _.Username).Apply(_settings.Username);
                builder.Property(_ => _.SecurePassword).Apply(_settings.SecurePassword);
                builder.Property(_ => _.EmailAddress).Apply(_settings.EmailAddress);
                builder.Property(_ => _.MobileNumber).Apply(_settings.MobileNumber);
                builder.Property(_ => _.IsActive).Apply(_settings.IsActive);
                builder.Property(_ => _.IsPasswordChangeRequired).Apply(_settings.IsPasswordChangeRequired);
                builder.Property(_ => _.IsEmailAddressVerified).Apply(_settings.IsEmailAddressVerified);
                builder.Property(_ => _.IsMobileNumberVerified).Apply(_settings.IsMobileNumberVerified);

                base.Configure(builder);
            }
        }

        private sealed class UserApplicationConfiguration : EntityConfigurationBase<UserApplication>
        {
            private readonly SorschiaDataSettings.UserApplicationSettings _settings;

            public UserApplicationConfiguration(SorschiaDataSettings.UserApplicationSettings settings) : base(settings)
            {
                _settings = settings;
            }

            public override void Configure(EntityTypeBuilder<UserApplication> builder)
            {
                builder.HasInt64IdentityColumn(_settings.Id);
                builder.Property(_ => _.UserId).Apply(_settings.UserId);
                builder.Property(_ => _.ApplicationId).Apply(_settings.ApplicationId);

                builder
                    .HasOne(_ => _.User)
                    .WithMany(_ => _.Applications)
                    .HasForeignKey(_ => _.UserId);

                builder
                    .HasOne(_ => _.Application)
                    .WithMany()
                    .HasForeignKey(_ => _.ApplicationId);

                base.Configure(builder);
            }
        }

        private sealed class UserPermissionConfiguration : EntityConfigurationBase<UserPermission>
        {
            private readonly SorschiaDataSettings.UserPermissionSettings _settings;

            public UserPermissionConfiguration(SorschiaDataSettings.UserPermissionSettings settings) : base(settings)
            {
                _settings = settings;
            }

            public override void Configure(EntityTypeBuilder<UserPermission> builder)
            {
                builder.HasInt64IdentityColumn(_settings.Id);
                builder.Property(_ => _.UserId).Apply(_settings.UserId);
                builder.Property(_ => _.PermissionId).Apply(_settings.PermissionId);

                builder
                    .HasOne(_ => _.User)
                    .WithMany(_ => _.Permissions)
                    .HasForeignKey(_ => _.UserId);

                builder
                    .HasOne(_ => _.Permission)
                    .WithMany()
                    .HasForeignKey(_ => _.PermissionId);

                base.Configure(builder);
            }
        }

        private sealed class UserRoleConfiguration : EntityConfigurationBase<UserRole>
        {
            private readonly SorschiaDataSettings.UserRoleSettings _settings;

            public UserRoleConfiguration(SorschiaDataSettings.UserRoleSettings settings) : base(settings)
            {
                _settings = settings;
            }

            public override void Configure(EntityTypeBuilder<UserRole> builder)
            {
                builder.HasInt64IdentityColumn(_settings.Id);
                builder.Property(_ => _.UserId).Apply(_settings.UserId);
                builder.Property(_ => _.RoleId).Apply(_settings.RoleId);

                builder
                    .HasOne(_ => _.User)
                    .WithMany(_ => _.Roles)
                    .HasForeignKey(_ => _.UserId);

                builder
                    .HasOne(_ => _.Role)
                    .WithMany()
                    .HasForeignKey(_ => _.RoleId);

                base.Configure(builder);
            }
        }
    }
}
