using System;
using System.Collections.Generic;

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

        public Game(int id, string title, string description, string releaseYear, Uri imageUrl)
          : this(title, description, releaseYear, imageUrl)
        {
            Id = id;
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
        
        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public string Genre { get; protected set; }

        public string ReleaseYear { get; protected set; }

        public Uri ImageUrl { get; protected set; }

        public string UrlSlug { get; protected set; }

        public ICollection<HighScore> AllGameScores { get; set; }

    }
}
