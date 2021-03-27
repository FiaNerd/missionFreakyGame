using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Areas.Admin.Models.ViewModels
{
    public class CreateGameViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Genre { get; set; }

        [Required]
        public string ReleaseYear { get; set; }

        [Required]
        public Uri ImageUrl { get; set; }

        [Required]
        [MaxLength(50)]
        public string UrlSlug { get; set; }


        public List<SelectListItem> ListGames { get; set; }
    }
}
