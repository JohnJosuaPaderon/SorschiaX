using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.Data;
using Sorschia.Teams.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Sorschia.Teams.Data
{
    internal sealed class TeamsContext : SorschiaDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentStep> AssignmentSteps { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamAssignment> TeamAssignments { get; set; }
        public DbSet<MemberAssignment> MemberAssignments { get; set; }

        public TeamsContext([NotNull] DbContextOptions options, ICurrentFootprintProvider currentFootprintProvider) : base(options, currentFootprintProvider)
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
