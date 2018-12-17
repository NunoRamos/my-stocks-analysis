using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace StocksAnalysis.Models
{
    class CompanyStocks
    {
        [JsonProperty("01. symbol")]
        public String Symbol { get; set; }

        [JsonProperty("02. open")]
        public Double OpenPrice { get; set; }

        [JsonProperty("03. high")]
        public Double HighPrice { get; set; }

        [JsonProperty("04. low")]
        public Double LowPrice { get; set; }

        [JsonProperty("05. price")]
        public Double AtualPrice { get; set; }

        [JsonProperty("06. volume")]
        public BigInteger Volume { get; set; }

        [JsonProperty("10. change percent")]
        public String ChangePercent { get; set; }

        public String SymbolAndAtualPrice
        {
            get
            {
                return Symbol + "\n" + AtualPrice;
            }
        }

        public String PercentIcon { get; set; }

        public String LogoImage { get; set; }
    }
}
