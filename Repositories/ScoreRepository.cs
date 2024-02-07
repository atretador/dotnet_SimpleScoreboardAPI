using scoreboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreboard.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly ScoreContext _context;

        public ScoreRepository(ScoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Score>> Get()
        {
            try
            {
                return await _context.Scores
                    .Where(sc => sc.Score > 0)
                    .OrderByDescending(sc => sc.Score)
                    .Take(10)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve scores.", ex);
            }
        }

        public async Task<List<Score>> Get(int highest)
        {
            try
            {
                return await _context.Scores
                    .Where(sc => sc.Score > 0)
                    .OrderByDescending(sc => sc.Score)
                    .Take(highest)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve scores.", ex);
            }
        }

        public async Task<Score> Create(Score score)
        {
            if (score == null)
            {
                throw new ArgumentNullException(nameof(score));
            }

            try
            {
                _context.Scores.Add(score);
                await _context.SaveChangesAsync();
                return score;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create score.", ex);
            }
        }
    }
}