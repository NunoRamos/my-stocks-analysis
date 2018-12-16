using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StocksAnalysis.Models
{
    public class Stats
    {
        [JsonProperty("1. open")]
        public string Open { get; set; }
        [JsonProperty("2. high")]
        public string High { get; set; }
        [JsonProperty("3. low")]
        public string Low { get; set; }
        [JsonProperty("4 .close")]
        public string Close { get; set; }
        [JsonProperty("5 .volume")]
        public string Volume { get; set; }
    }

    class CompanyHistoryPrices
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("stats")]
        public Stats Stats { get; set; }
        [JsonProperty("closePriceVariations")]
        public List<Double> ClosePriceVariations { get; set; }
    }
}
