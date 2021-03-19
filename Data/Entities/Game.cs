﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreakyGame.Data.Entities
{
    public class Game
    {
        public Game(string title, string description, string releaseYear, Uri imageUrl, string urlSlug)
        {
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            ImageUrl = imageUrl;
            UrlSlug = urlSlug;
        }

        public int Id { get; protected set; }
        
        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public string Genre { get; protected set; }

        public string ReleaseYear { get; set; }

        public Uri ImageUrl { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string UrlSlug { get; protected set; }

        [ForeignKey("RegisterScoreId")]
        public RegisterScore RegisterScore { get; set; }
        public int RegisterScoreId { get; set; }

    }
}
