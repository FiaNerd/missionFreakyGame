using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Data.Entities
{
    public class RegisterScore
    {
        public RegisterScore(string player, DateTime date, int score)
        {
            Player = player;
            Date = date;
            Score = score;
        }
        
        public int Id { get; protected set; }

        [Required]
        public string Player { get; protected set; }

        [Required]
        public DateTime Date { get; protected set; }

        [Required]
        public int Score { get; protected set; }

        public ICollection<Game> Games { get; protected set; }
     = new List<Game>();
    }
}
