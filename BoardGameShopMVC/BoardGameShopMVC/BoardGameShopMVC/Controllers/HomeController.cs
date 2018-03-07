using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoardGameShopMVC.DAL;
using BoardGameShopMVC.Models;
using BoardGameShopMVC.ViewModels;

namespace BoardGameShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Home
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();

            var newArriwals = db.Games.Where(x => !x.IsHidder).OrderByDescending(x => x.DateAdded).Take(3).ToList();

            var bestsellers = db.Games.Where(x => !x.IsHidder && x.IsBestseller).OrderBy(y => Guid.NewGuid()).Take(3).ToList(); // order by new Guid to get random bestseller in each time

            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                NewArrivals = newArriwals,
                Categories = categories
            };
            return View(vm);
        }

        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
    }
}  