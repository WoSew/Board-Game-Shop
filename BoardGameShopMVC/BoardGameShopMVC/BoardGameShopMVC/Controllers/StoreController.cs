using BoardGameShopMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
            var game = db.Games.Find(id);

            return View(game); 
        }

        public ActionResult List(string categoryName)
        {
            var category = db.Categories.Include("Games").Where(x => x.Name.ToUpper() == categoryName.ToUpper()).Single();
            var games = category.Games.ToList();

            return View(games);
        }

        //akcja na potrzeby wewnetrzne (do List)
        [ChildActionOnly] 
        [OutputCache(Duration = 80000)]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();

            return PartialView("_CategoriesMenu",categories);
        }
    }
}