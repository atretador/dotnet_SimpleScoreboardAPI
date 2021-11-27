using System.ComponentModel.DataAnnotations.Schema;

namespace scoreboard.Models
{
    [Table("Score")]
    public class Score
    {
        public string name {get;set;}
        public int score {get;set;}
    }
}