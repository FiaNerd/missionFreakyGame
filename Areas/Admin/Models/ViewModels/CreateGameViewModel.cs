using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Areas.Admin.Models.ViewModels
{
    public class CreateGameViewModel
    {
        public int Id { get; protected set; }

        [Required]
        public string Title { get; protected set; }

        [Required]
        public string Description { get; protected set; }

        public string Genre { get; protected set; }

        [Required]
        public string ReleaseYear { get; set; }

        [Required]
        public Uri ImageUrl { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string UrlSlug { get; protected set; }


        public List<SelectListItem> ListGames { get; set; }
    }
}
