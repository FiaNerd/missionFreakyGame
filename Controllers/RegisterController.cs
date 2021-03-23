﻿using FreakyGame.Data;
using Microsoft.AspNetCore.Mvc;

namespace FreakyGame.Controllers
{
    public class RegisterController : Controller
    {
        private readonly FreakyGameContext context;

        public RegisterController(FreakyGameContext context)
        {
            this.context = context;
        }

        public IActionResult CreateRegister()
        {
            return View();
        }

    }
}
