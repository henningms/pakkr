using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Web.Http.Filters;

namespace PakkR.Windows10.Utils
{
    public class Settings
    {
        public const string CookiesJsonKey = "cookiesJson";
        public const string CookiesJsonFileName = "cookies.json";
        public const string IsLoggedInKey = "isLoggedIn";

        /// <summary>
        /// Fetches current set of cookies stored for Postens domain and stores
        /// this in Roaming settings and locally on disk. Also sets logged in to true in this rendition.
        /// </summary>
        /// <returns>Nothing at all</returns>
        public async Task SaveCurrentCookiesForPosten()
        {
            var filter = new HttpBaseProtocolFilter();
            var cookieManager = filter.CookieManager;
            var cookies = cookieManager.GetCookies(new Uri(PostenApiConstants.UserProfileApiUrl));

            var cookiesAsJson = JsonConvert.SerializeObject(cookies);

            if (ApplicationData.Current.RoamingSettings.Values.ContainsKey(CookiesJsonKey))
            {
                ApplicationData.Current.RoamingSettings.Values[CookiesJsonKey] = cookiesAsJson;
                ApplicationData.Current.RoamingSettings.Values[IsLoggedInKey] = true;
            }
            else
            {
                ApplicationData.Current.RoamingSettings.Values.Add(CookiesJsonKey, cookiesAsJson);
                ApplicationData.Current.RoamingSettings.Values.Add(IsLoggedInKey, true);
            }


            var storageFolder = ApplicationData.Current.LocalFolder;
            var storageFile = await storageFolder.CreateFileAsync(CookiesJsonFileName, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(storageFile, cookiesAsJson);
        }
    }
}
