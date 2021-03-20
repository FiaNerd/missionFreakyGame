﻿using System;
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

        public int GameId { get; protected set; }

        public Game Game { get; protected set; }
    }
}
