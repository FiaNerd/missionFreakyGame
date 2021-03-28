﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Data.Entities
{
    public class Game
    {
        public Game(string title, string description, string releaseYear, Uri imageUrl)
        {
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            ImageUrl = imageUrl;
        }


        public Game(string title, string description, string releaseYear, Uri imageUrl, string urlSlug)
        {
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            ImageUrl = imageUrl;
            UrlSlug = urlSlug;
        }


        public Game(int id, string title, string description, string releaseYear, Uri imageUrl, string urlSlug)
            : this(title, description, releaseYear, imageUrl, urlSlug)
        {
            Id = id;
        }


        public int Id { get; protected set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public string ReleaseYear { get; set; }

        public Uri ImageUrl { get; set; }

        public string UrlSlug { get; set; }

        public ICollection<RegisterScore> AllGameScores { get; set; }

    }
}
