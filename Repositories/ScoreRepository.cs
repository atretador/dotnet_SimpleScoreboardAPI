using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreboard.Models;

namespace scoreboard.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly ScoreContext _context;

        public ScoreRepository(ScoreContext context){
            _context = context;
        }
        public async Task<List<ScoreData>> Get(){
            var data = (from sc in _context.Scores
            where sc.score > 0
            orderby sc.score
            select sc).Take(10);

            List<ScoreData> scores = new List<ScoreData>();
            data.ToList().ConvertAll(x => new ScoreData(x));
            return scores;
        }

        public async Task<List<ScoreData>> Get(int highest){
            var data = (from sc in _context.Scores
            where sc.score > 0
            orderby sc.score
            select sc).Take(highest);
            List<ScoreData> scores = new List<ScoreData>();
            data.ToList().ConvertAll(x => new ScoreData(x));
            return scores;
        }

        public async Task<ScoreData> Create(ScoreData score){
            Score _score = new Score(score); 
            _context.Scores.Add(_score);
            await _context.SaveChangesAsync();
            return score;
        }
    }
}