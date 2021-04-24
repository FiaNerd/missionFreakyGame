using FreakyGame.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FreakyGame.Areas.API.Dto
{
    public class HighScoreDto
    {
            public int Id { get; set; }

            public string Player { get; set; }

            public DateTime Date { get; set; }

            public int Score { get; set; }

            public Game Game { get; set; }

            public int GameId { get; set; }

           public List<SelectListItem> ListScores { get; set; }
    }
}
