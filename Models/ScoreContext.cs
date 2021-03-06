using Microsoft.EntityFrameworkCore;

namespace scoreboard.Models
{
    public class ScoreContext: DbContext
    {
        public ScoreContext(DbContextOptions<ScoreContext> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>()
                .Property<int>("id");
        }
    }
}