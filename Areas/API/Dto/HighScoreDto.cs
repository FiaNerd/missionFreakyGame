using System;

namespace FreakyGame.Areas.API.Dto
{
    public class HighScoreDto
    {
            public int Id { get; set; }

            public int GameId { get; set; }

            public string Player { get; set; }

            public DateTime Date { get; set; }

            public int Score { get; set; }
    }
}
