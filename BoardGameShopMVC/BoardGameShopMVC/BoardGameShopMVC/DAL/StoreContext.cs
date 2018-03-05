using System.Data.Entity;
using BoardGameShopMVC.Models;

namespace BoardGameShopMVC.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext")
        {
            
        }

        static StoreContext()
        {
            Database.SetInitializer(new StoreInitializer());
        }
        
        public DbSet<Game> Games { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}