using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyGame.Areas.Admin.Models.ViewModels
{
    public class EditGameViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        //public string Genre { get; set; }

        [Required]
        public string ReleaseYear { get; set; }

        [Display(Name = "Image URL")]
        public Uri ImageUrl { get; set; }

        //public ICollection<RegisterScore> AllGameScores { get; set; }

    }
}
