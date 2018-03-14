using System.Web.Optimization;

namespace BoardGameShopMVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/core.css",
                "~/Content/themes/base/autocomplete.css",
                "~/Content/themes/base/theme.css",
                "~/Content/themes/base/menu.css"));
        }
    }
} 