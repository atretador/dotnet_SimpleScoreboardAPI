
using System.Collections.Generic;
using System.Threading.Tasks;
using scoreboard.Models;

namespace scoreboard.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Score>> GetScoresAsync(string query);
        Task<Score> GetScoreAsync(string id);
        Task AddScoreAsync(Score Score);
        Task UpdateScoreAsync(string id, Score Score);
        Task DeleteScoreAsync(string id);
    }
}