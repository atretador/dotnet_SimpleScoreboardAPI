using Microsoft.AspNetCore.Mvc;
using scoreboard.Repositories;

namespace scoreboard.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreboardController : ControllerBase
    {
        private readonly IScoreRepository _scoreboard;

        public ScoreboardController(IScoreRepository scoreRepository){
            _scoreboard = scoreRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Score>> PostScore([FromBody] Score scoreData){
            var _score = await _scoreboard.Create(scoreData);
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<Score>> GetHighestScore(){
            return await _scoreboard.Get();
        }

        [HttpGet("{quantity}")]
        public async Task<ActionResult<List<Score>>> GetTopNScore(int quantity){
            return await _scoreboard.Get(quantity);
        }
    }
}