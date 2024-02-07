using Microsoft.AspNetCore.Mvc;
using scoreboard.Repositories;
using System;

namespace scoreboard.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreboardController : ControllerBase
    {
        private readonly IScoreRepository _scoreboard;

        public ScoreboardController(IScoreRepository scoreRepository)
        {
            _scoreboard = scoreRepository ?? throw new ArgumentNullException(nameof(scoreRepository));
        }

        [HttpPost]
        public async Task<IActionResult> PostScore([FromBody] UserScore scoreData)
        {
            if (scoreData == null)
            {
                return BadRequest("Invalid score data provided.");
            }

            try
            {
                var createdScore = await _scoreboard.Create(scoreData);
                return CreatedAtAction(nameof(GetHighestScore), new { id = createdScore.Id }, createdScore); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetHighestScore()
        {
            try
            {
                var highestScores = await _scoreboard.Get();
                if (highestScores == null || highestScores.Count() == 0)
                {
                    return NotFound("No scores found.");
                }
                return Ok(highestScores); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet("{quantity}")]
        public async Task<IActionResult> GetTopNScore(int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Quantity must be a positive integer.");
            }

            try
            {
                var topScores = await _scoreboard.Get(quantity);
                if (topScores == null || topScores.Count() == 0)
                {
                    return NotFound("No scores found.");
                }
                return Ok(topScores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }
}