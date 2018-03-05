namespace BoardGameShopMVC.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; } //foreign key
        public int GameId { get; set; } // foreign key
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        
        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
    }
}