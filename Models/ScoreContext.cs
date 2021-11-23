using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace scoreboard.Models
{
    public class ScoreContext: DbContext
    {
        public ScoreContext(DbContextOptions<ScoreContext> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Score> Scores { get; set; }
    }
}