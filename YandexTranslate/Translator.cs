using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace YandexTranslate
{
    public class Translator
    {
        private static HttpClient client = new HttpClient();

        public static string SourceLanguage { get; set; }
        public static string DestinationLanguage { get; set; }

        public static async Task<string> Translate(string text, string sourceLang, string destLang, string apiKey)
        {
            var url = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key={apiKey}&text={text}&lang={sourceLang}-{destLang}";
            var json = await client.GetStringAsync(url);
            var resultObj = JsonConvert.DeserializeObject<TranslateObjectJson>(json);
            var resultText = string.Join(Environment.NewLine, resultObj.Text);
            return resultText;
        }

        public static async Task<string> Translate(string text, string sourceLang, string destLang)
        {
            var resultText = await Translate(text, sourceLang, destLang, ApiSettings.ApiKey);
            return resultText;
        }

        public static async Task<string> DetectLanguage(string text, string apiKey)
        {
            var url = $"https://translate.yandex.net/api/v1.5/tr.json/detect?key={apiKey}&text={text}";
            var json = await client.GetStringAsync(url);
            var lang = JsonConvert.DeserializeObject<DetectJson>(json).Language;
            return lang;
        }

        public static async Task<string> DetectLanguage(string text)
        {
            var lng = await DetectLanguage(text, ApiSettings.ApiKey);
            return lng;
        }
    }
}
