using FreakyGame.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyGame.Models.ViewModels
{
    public class CreateScoreViewModel
    {
        public string Player { get; set; }

        public DateTime Date { get; set; }

        public int Score { get; set; }

        public int GameId { get; set; }

        //Kanske ta bort denna? 
        public List<SelectListItem> RegisterScoores { get; set; }
    }
}
