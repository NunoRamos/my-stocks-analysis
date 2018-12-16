using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace StocksAnalysis.Models
{
    class CompanyHistoryPrices
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("stats")]
        public JObject Stats { get; set; }
        [JsonProperty("closePriceVariations")]
        public List<Double> ClosePriceVariations { get; set; }
    }
}
