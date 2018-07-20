using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YandexTranslate
{
    public class LanguageJson
    {
        [JsonProperty(PropertyName = "langs")]
        public Dictionary<string, string> Languages { get; set; }
    }
}
