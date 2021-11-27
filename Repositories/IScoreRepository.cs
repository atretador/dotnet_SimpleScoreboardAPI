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