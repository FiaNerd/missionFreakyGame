using System;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Data.Entities
{
    public class HighScore
    {
        public HighScore(string player, DateTime date, int score)
        {
            Player = player;
            Date = date;
            Score = score;
        }

        public HighScore(string player, DateTime date, int score, int gameId)
        {
            Player = player;
            Date = date;
            Score = score;
            GameId = gameId;
        }

        public HighScore(int id, string player, DateTime date, int score)
        {
            Id = id;
            Player = player;
            Date = date;
            Score = score;
        }

        public int Id { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string Player { get; protected set; }

        [Required]
        public DateTime Date { get; protected set; }

        [Required]
        public int Score { get; protected set; }

        public int GameId { get; protected set; }

        public Game Game { get; protected set; }
    }
}
