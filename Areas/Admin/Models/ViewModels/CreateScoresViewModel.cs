﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FreakyGame.Areas.Admin.Models.ViewModels
{
    public class CreateScoresViewModel
    {
        public string Player { get; set; }

        public DateTime Date { get; set; }

        public int Score { get; set; }

        public int GameId { get; set; }

        public List<SelectListItem> ListScores { get; set; }
    }
}
