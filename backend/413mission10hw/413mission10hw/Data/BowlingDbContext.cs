using _413mission10hw.Models;
using Microsoft.EntityFrameworkCore;

namespace _413mission10hw.Data
{
    // entity framework session for the bowling league sqlite file
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // each bowler belongs to one team via teamid foreign key
            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany(t => t.Bowlers)
                .HasForeignKey(b => b.TeamId);
        }
    }
}
