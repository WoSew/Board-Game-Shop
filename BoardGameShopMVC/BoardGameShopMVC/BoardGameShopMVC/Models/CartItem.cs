namespace BoardGameShopMVC.Models
{
    public class CartItem
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}