﻿namespace BooksSpring2024_sec02.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<Cart> CartItems { get; set; }

        public decimal OrderTotal { get; set; }

    }
}
