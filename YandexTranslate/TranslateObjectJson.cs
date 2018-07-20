using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YandexTranslate
{
    public class TranslateObjectJson
    {
        [JsonProperty(PropertyName = "text")]
        public string[] Text { get; set; }
    }
}
