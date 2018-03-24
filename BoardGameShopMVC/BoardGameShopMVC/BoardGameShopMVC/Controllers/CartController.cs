using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoardGameShopMVC.DAL;
using BoardGameShopMVC.Infrastructure;
using BoardGameShopMVC.Infrastructure.Session;
using BoardGameShopMVC.ViewModels;

namespace BoardGameShopMVC.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager { get; set; }
        private StoreContext db = new StoreContext();

        public CartController()
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cartItem = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() {CartItems = cartItem, TotalPrice = cartTotalPrice};

            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.AddToCart(id);
            return RedirectToAction("Index"); //after add to cart go to Indext action from this controller
        }

        public int GetCartItemsCount()
        {
            return shoppingCartManager.GetCartItemsCount();
        }

        public ActionResult RemoveFromCart(int gameId)
        {
            int itemCount = shoppingCartManager.RemoveFromCart(gameId);
            int cartItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            //JSON to process in JS
            var result = new CartRemoveViewModel
            {
                RemoveItemId = gameId,
                RemovedItemCount = cartItemsCount,
                CartTotal = cartTotal,
                CartItemsCount = itemCount
            };

            return Json(result);
        }


    }
}