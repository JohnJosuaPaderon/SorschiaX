using Microsoft.EntityFrameworkCore;
using Sorschia.Teams.Entities;
using System.Diagnostics.CodeAnalysis;
using SystemBase.Data;

namespace Sorschia.Teams.Data
{
    internal sealed class TeamsContext : SystemBaseDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentStep> AssignmentSteps { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamAssignment> TeamAssignments { get; set; }
        public DbSet<MemberAssignment> MemberAssignments { get; set; }

        public TeamsContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Teams")
                .ApplyConfigurationsFromAssembly(typeof(TeamsContext).Assembly);
        }
    }
}
