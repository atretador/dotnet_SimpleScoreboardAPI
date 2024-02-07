using Microsoft.EntityFrameworkCore;

namespace scoreboard.Models
{
    public class ScoreContext : DbContext
    {
        public ScoreContext(DbContextOptions<ScoreContext> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<UserScore> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserScore>()
                .Property<int>("id");
        }
    }
}
