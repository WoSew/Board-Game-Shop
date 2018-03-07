using System.Collections.Generic;
using BoardGameShopMVC.Models;

namespace BoardGameShopMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Game> Bestsellers { get; set; }

        public IEnumerable<Game> NewArrivals { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}