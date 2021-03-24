using System;
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

        public RegisterScore(int id, string player, DateTime date, int score)
           : this(player, date, score)
        {
            Id = id;
        }

        public int Id { get; protected set; }

        [Required (ErrorMessage= "You have to enter your name")]
        public string Player { get; protected set; }

        [Required (ErrorMessage = "You have to enter a date")]
        public DateTime Date { get; protected set; }

        [Required (ErrorMessage = "You have to enter your score")]
        public int Score { get; protected set; }

        public int GameId { get; protected set; }

        public Game Game { get; protected set; }
    }
}
