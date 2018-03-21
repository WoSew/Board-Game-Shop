using System;
using System.Collections.Generic;
using System.Linq;
using BoardGameShopMVC.DAL;
using BoardGameShopMVC.Infrastructure.Session;
using BoardGameShopMVC.Models;

namespace BoardGameShopMVC.Infrastructure
{
    public class ShoppingCartManager
    {
        private StoreContext _db;
        private ISessionManager _session;

        public const string CartSessionKey = "CartData";

        public ShoppingCartManager(ISessionManager session, StoreContext db)
        {
            _db = db;
            _session = session;
        }

        public void AddToCart(int gameId)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(x => x.Game.GameID == gameId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else //nothing in cart
            {
                var gameToAdd = _db.Games.SingleOrDefault(x => x.GameID == gameId);
                //var gameToAdd = _db.Games.Where(x => x.GameID == gameId).SingleOrDefault();
                if (gameToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Game = gameToAdd,
                        Quantity = 1,
                        TotalPrice = gameToAdd.Price
                    };

                    cart.Add(newCartItem);
                }
            }
            _session.Set(CartSessionKey, cart);
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (_session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = _session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }
            return cart;
        }

        public int RemoveFromCart(int gameId)
        {
            var cart = this.GetCart();
            var cartItem = cart.Find(x => x.Game.GameID == gameId);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }

            return 0;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(x => (x.Quantity * x.Game.Price));
        }

        public int GetCartItemsCount()
        {
            var cart = this.GetCart();
            int count = cart.Sum(x => x.Quantity);

            return count;
        }

        public Order CreateOrder(Order order, string userId)
        {
            var cart = this.GetCart();
            decimal cartTotalPrice = 0;

            order.DateCreated = DateTime.UtcNow;
            _db.Orders.Add(order);

            if (order.OrderItems == null)
            {
                order.OrderItems = new List<OrderItem>();
            }

            foreach (var cartItem in cart)
            {
                var orderItem = new OrderItem()
                {
                    GameId = cartItem.Game.GameID,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Game.Price
                };
                cartTotalPrice += (cartItem.Quantity * cartItem.Game.Price);
                order.OrderItems.Add(orderItem);
            }

            order.TotalPrice = cartTotalPrice;

            _db.SaveChanges();

            return order;
        }

        public void EmptyCart()
        {
            _session.Set<List<CartItem>>(CartSessionKey, null);
        }

    }
}