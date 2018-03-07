using System.Configuration;

namespace BoardGameShopMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _categoriesFolderRelative = ConfigurationManager.AppSettings["CategoriesIconsFolder"];

        public static string CategoryIconFolderRelative
        {
            get
            {
                return _categoriesFolderRelative;
            }
        }

        private static string _photosFolderRelative = ConfigurationManager.AppSettings["PhotosFolder"];

        public static string PhotosFolderRelative
        {
            get
            {
                return _photosFolderRelative;
            }
        }
    }
}