using System.Collections.Generic;

namespace BoardGameShopMVC.Models
{
    public class Category
    {
        public int CategoryId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconFileName { get; set; }

        //navigation property that let you show collection of games in specified category 
        public virtual ICollection<Game> Games { get; set; } 
    }
}