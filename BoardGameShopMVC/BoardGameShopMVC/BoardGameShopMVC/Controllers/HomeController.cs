using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoardGameShopMVC.DAL;
using BoardGameShopMVC.Models;

namespace BoardGameShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Home
        public ActionResult Index()
        {
/*            Category newCategory = new Category
            {
                Name = "Horror",
                Description = "Opis kategorii",
                IconFileName = "Horror.png"
            };

            db.Categories.Add(newCategory);
            db.SaveChanges();*/

            var categoryList = db.Categories.ToList();

            return View();
        }

        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
    }
}  