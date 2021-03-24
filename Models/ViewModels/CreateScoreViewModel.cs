using FreakyGame.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyGame.Models.ViewModels
{
    public class CreateScoreViewModel
    {
        [Required]
        public string Player { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Score { get; set; }

        public List<Game> Games { get; set; }
    }
}
