using System;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Models.Dto
{
    public class CreateHighScoreDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Player { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Score is required")]
        public int Score { get; set; }

    }
}
