﻿namespace FreakyGame.Extensions
{
    public static class StringExtensions
    {
        // "Black T-Shirt" > "black-tshirt"
        // "T-Shirts" > "tshirts
        // whitespace kan och fram ska tas bort, "   Black T-Shirt   "  >   "black-tshirt"
        public static string Slugify(this string player) => player.Trim()
            .Replace("-", "")
            .Replace(" ", "-")
            .ToLower();
    }
}
