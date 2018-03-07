using System.IO;
using System.Web.Mvc;

namespace BoardGameShopMVC.Infrastructure
{
    public static class UrlHelpers
    {
        public static string CategoryIconPath(this UrlHelper helper, string categoryIconFilename)
        {
            var categoryIconFolder = AppConfig.CategoryIconFolderRelative;
            var path = Path.Combine(categoryIconFolder, categoryIconFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string GamePhotoPath(this UrlHelper helper, string photoFilename)
        {
            var gamePhotoPath = AppConfig.PhotosFolderRelative;
            var path = Path.Combine(gamePhotoPath, photoFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}