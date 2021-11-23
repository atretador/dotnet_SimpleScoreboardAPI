using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreboard.Models;

namespace scoreboard.Repositories
{
    public interface IScoreRepository
    {
        Task<List<ScoreData>> Get();
        Task<List<ScoreData>> Get(int top);
        Task<ScoreData> Create(ScoreData score);
    }
}