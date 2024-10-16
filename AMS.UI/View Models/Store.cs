using AMS.UI.Domain.Entities;
using System;
using System.Globalization;

namespace AMS.UI.View_Models
{
    public static class Store
    {
        public static User CurrentUser;
        public static string CurrentRegionName {
            get {
                var regKeyGeoId = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\International\Geo");
                var geoID = (string)regKeyGeoId.GetValue("Nation");
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (CultureInfo culture in cultures)
                {
                    RegionInfo region = new RegionInfo(culture.ToString());
                    if (region.GeoId == int.Parse(geoID))
                    {
                        return region.TwoLetterISORegionName.ToLower();
                    }
                }

                return RegionInfo.CurrentRegion.TwoLetterISORegionName.ToLower();
            }
        }

        public static string CurrentLanguage
        {
            get
            {
                switch (CurrentRegionName)
                {
                    case "fr":
                        return "fr";
                    default:
                        return "en";
                }

            }
        }
        }
    }
