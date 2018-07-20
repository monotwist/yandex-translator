using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace YandexTranslate
{
    public class LanguageProvider
    {
        private static Dictionary<string, string> langs;

        public static async Task<Dictionary<string, string>> GetLanguages(string apiKey, string descrLang)
        {
            if (langs != null)
                return langs;

            string url = $"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={apiKey}&ui={descrLang}";
            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            var lngsObj = JsonConvert.DeserializeObject<LanguageJson>(json);
            langs = lngsObj.Languages;
            return langs;
        }

        public static async Task<Dictionary<string, string>> GetLanguages(string descrLang)
        {
            var langs = await GetLanguages(ApiSettings.ApiKey, descrLang);
            return langs;
        }

        public static string FindCodeByFullName(string fullName)
        {
            if (langs == null || langs.Count == 0)
                throw new Exception("Language list is null or empty");

            return langs.Where(x => x.Value == fullName)?.Select(x => x.Key).FirstOrDefault();
        }
    }
}
