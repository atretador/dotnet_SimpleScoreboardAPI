using scoreboard.Models;

namespace scoreboard.Repositories
{
    public interface IScoreRepository
    {
        Task<List<UserScore>> Get();
        Task<List<UserScore>> Get(int top);
        Task<UserScore> Create(UserScore score);
    }
}