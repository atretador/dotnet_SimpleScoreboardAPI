using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scoreboard.Repositories;

namespace scoreboard.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreboardController : ControllerBase
    {
        private readonly IScoreRepository _scoreboard;

        [HttpPost]
        public async Task<ActionResult<ScoreData>> PostScore([FromBody] ScoreData scoreData){
            var _score = await _scoreboard.Create(scoreData);
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<ScoreData>> GetHighestScore(){
            return await _scoreboard.Get();
        }

        [HttpGet("{quantity}")]
        public async Task<ActionResult<List<ScoreData>>> GetTopNScore(int amount){
            return await _scoreboard.Get(amount);
        }
    }
}