using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using System;

namespace Sorschia.Data
{
    public sealed class CoreContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER=.;DATABASE=SorschiaSAMPLE;USER ID=sa;PASSWORD=calypsoelgrande;");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("dbo")
                .ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Application>(builder =>
            {
                builder.ToTable("Application");

                builder.Property(a => a.Platform)
                .HasConversion(p => p.ToString(), p => (Platform)Enum.Parse(typeof(Platform), p));

                builder.HasOne(t => t.InsertedBy)
                .WithMany();

                builder.HasOne(t => t.UpdatedBy)
                .WithMany();

                builder.HasOne(t => t.DeletedBy)
                .WithMany();
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User");
                builder.HasMany(u => u.Modules).WithMany(m => m.Users);
                builder
                    .HasMany(u => u.Roles)
                    .WithMany(r => r.Users);

                builder.HasOne(t => t.InsertedBy)
                .WithMany();

                builder.HasOne(t => t.UpdatedBy)
                .WithMany();

                builder.HasOne(t => t.DeletedBy)
                .WithMany();
            });

            modelBuilder.Entity<Role>(builder =>
            {
                builder.ToTable("Role").HasMany(r => r.Users).WithMany(u => u.Roles);

                builder.HasOne(t => t.InsertedBy)
                .WithMany();

                builder.HasOne(t => t.UpdatedBy)
                .WithMany();

                builder.HasOne(t => t.DeletedBy)
                .WithMany();
            });

            modelBuilder.Entity<Module>(builder =>
            {
                builder.ToTable("Module");

                builder.HasMany(m => m.Users).WithMany(u => u.Modules);

                builder.HasOne(t => t.InsertedBy)
                .WithMany();

                builder.HasOne(t => t.UpdatedBy)
                .WithMany();

                builder.HasOne(t => t.DeletedBy)
                .WithMany();
            });

            base.OnModelCreating(modelBuilder);
        }
    }

    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
        }
    }

    internal sealed class DbUser : Entities
    {

    }
}
