using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreboard.Models;

namespace scoreboard.Repositories
{
    public interface IScoreRepository
    {
        Task<List<Score>> Get();
        Task<List<Score>> Get(int top);
        Task<Score> Create(Score score);
    }
}