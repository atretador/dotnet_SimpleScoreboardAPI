using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scoreboard.Models
{

    public class ScoreData{
        [Required]
        public string name {get;set;}
        [Required]
        public int score {get; set;}
        public ScoreData(Score score){
            this.name = score.name;
            this.score = score.score;
        }
    }

    [Table("Score")]
    public class Score
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public int score {get;set;}

        public Score(ScoreData data){
            this.id = 0;
            this.name = data.name;
            this.score = data.score;
        }
    }
}