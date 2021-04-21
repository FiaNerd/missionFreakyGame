using System;

namespace FreakyGame.Areas.API.Dto
{
    public class GameDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public string ReleaseYear { get; set; }

        public Uri ImageUrl { get; set; }
    }
}
