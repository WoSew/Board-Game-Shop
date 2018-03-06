using System;
using System.ComponentModel;

namespace BoardGameShopMVC.Models
{
    public class Game
    {
        public int GameID { get; set; } // primary key
        public int CategoryId { get; set; } //foreign key
        public string GameTitle { get; set; }
        public string DesignerName { get; set; }
        public DateTime DateAdded { get; set; }
        public string GameFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsHidder { get; set; }

        public bool MigrationTest { get; set; }

        public virtual Category Category { get; set; } //navigation property in EF
    
    }
}