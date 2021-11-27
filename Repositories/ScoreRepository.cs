using scoreboard.Models;

namespace scoreboard.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly ScoreContext _context;

        public ScoreRepository(ScoreContext context){
            _context = context;
        }
        public async Task<List<Score>> Get(){
            var data = (from sc in _context.Scores
            where sc.score > 0
            orderby sc.score descending
            select sc).Take(10);
            return data.ToList();
        }

        public async Task<List<Score>> Get(int highest){
            var data = (from sc in _context.Scores
            where sc.score > 0
            orderby sc.score descending
            select sc).Take(highest);
            return data.ToList();
        }

        public async Task<Score> Create(Score score){
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }
    }
}