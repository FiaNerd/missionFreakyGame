using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Areas.API.Dto
{
    public class GameDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Genre { get; set; }

        public string ReleaseYear { get; set; }

        public Uri ImageUrl { get; set; }

        public ICollection<HighScoreDto> AllGameScores { get; set; }
    }
}
