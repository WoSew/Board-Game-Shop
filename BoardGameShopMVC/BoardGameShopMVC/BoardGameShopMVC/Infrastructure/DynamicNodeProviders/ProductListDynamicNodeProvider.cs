using System.Collections.Generic;
using BoardGameShopMVC.DAL;
using BoardGameShopMVC.Models;
using MvcSiteMapProvider;

namespace BoardGameShopMVC.Infrastructure.DynamicNodeProviders
{
    public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach(Category category in db.Categories)
            {
                DynamicNode n = new DynamicNode();
                n.Title = category.Name;
                n.Key = "Category_" + category.CategoryId;
                n.RouteValues.Add("categoryName", category.Name);
                returnValue.Add(n);
            }
            return returnValue;
        }
    }
}