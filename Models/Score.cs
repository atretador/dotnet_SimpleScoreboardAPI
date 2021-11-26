using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace scoreboard.Models
{
    [Table("Score")]
    public class Score
    {
        
        public string name {get;set;}
        public int score {get;set;}
    }
}