using AMS.UI.View_Models;
using System.Reflection;
using System.Resources;

namespace AMS.UI.Utils
{
    internal static class LanguageUtil
    {
        private static ResourceManager rm = new ResourceManager(
            $"AMS.UI.Languages.{Store.CurrentLanguage}",
            Assembly.GetExecutingAssembly()
        );

        public static string Translate(string key)
        {
            return rm.GetString(key);
        }
    }
}
