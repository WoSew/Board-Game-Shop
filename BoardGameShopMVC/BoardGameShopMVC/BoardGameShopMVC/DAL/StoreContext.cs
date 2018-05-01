using System.Data.Entity;
using BoardGameShopMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BoardGameShopMVC.DAL
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext() : base("StoreContext")
        {
            
        }

        static StoreContext()
        {
            Database.SetInitializer(new StoreInitializer());
        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }
        
        public DbSet<Game> Games { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}