using BoardGameShopMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameShopMVC.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(); 
        }

        public ActionResult List(string categoryName)
        {
            var category = db.Categories.Include("Games").Where(x => x.Name.ToUpper() == categoryName.ToUpper())
                .Single();
            var games = category.Games.ToList();

            return View(games);
        }

        //akcja na potrzeby wewnetrzne (do List)
        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();

            return PartialView("_CategoriesMenu",categories);
        }
    }
}