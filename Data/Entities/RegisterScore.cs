using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Data.Entities
{
    public class RegisterScore
    {
       
        public int Id { get; protected set; }

        [Required]
        public string Game { get; protected set; }

        [Required]
        public string Player { get; protected set; }

        [Required]
        public DateTime Date { get; protected set; }

        [Required]
        public int Score { get; protected set; }

        public ICollection<Game> GameRegister { get; protected set; }
       = new List<Game>();
    }
}
