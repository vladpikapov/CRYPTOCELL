using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLL.GetCourse
{
   public class GetCurInfo
    {
       public static ExchangeInfo GetExchangeInfo(string from, string to)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    var json = client.DownloadString(string.Format(@"https://spectrocoin.com/scapi/ticker/{0}/{1}/", from, to));
                    return JsonConvert.DeserializeObject<ExchangeInfo>(json);
                }
                catch
                {

                    return null;
                }
            }
        }
        public class ExchangeInfo
        {
            [JsonProperty("currencyFrom")]
            public string CurrencyFrom { get; set; }
            [JsonProperty("currencyFromScale")]
            public int CurrencyFromScale { get; set; }
            [JsonProperty("currencyTo")]
            public string CurrencyTo { get; set; }
            [JsonProperty("currencyToScale")]
            public int CurrencyToScale { get; set; }
            [JsonProperty("last")]
            public decimal Last { get; set; }
            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }
            [JsonProperty("friendlyLast")]
            public string FriendlyLast { get; set; }
        }
    }
}
