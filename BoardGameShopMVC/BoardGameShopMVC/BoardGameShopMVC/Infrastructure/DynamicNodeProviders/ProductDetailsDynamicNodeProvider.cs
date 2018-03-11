using System.Collections.Generic;
using BoardGameShopMVC.DAL;
using BoardGameShopMVC.Models;
using MvcSiteMapProvider;

namespace BoardGameShopMVC.Infrastructure.DynamicNodeProviders
{
    public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();


        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Game game in db.Games)
            {
                DynamicNode n = new DynamicNode();
                n.Title = game.GameTitle;
                n.Key = "Game_" + game.GameID;
                n.ParentKey = "Category_" + game.CategoryId;
                n.RouteValues.Add("id", game.GameID);
                returnValue.Add(n);
            }
            return returnValue;
        }
    }
}