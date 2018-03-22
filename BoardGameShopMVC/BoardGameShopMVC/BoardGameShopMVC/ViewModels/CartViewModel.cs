using System.Collections.Generic;
using BoardGameShopMVC.Models;

namespace BoardGameShopMVC.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}