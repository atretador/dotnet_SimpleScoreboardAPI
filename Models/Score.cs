using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scoreboard.Models
{
    [Table("Score")]
    public class Score
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public int score {get;set;}
    }
}