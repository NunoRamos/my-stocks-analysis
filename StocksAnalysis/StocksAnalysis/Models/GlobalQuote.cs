using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StocksAnalysis.Models
{
    class GlobalQuote
    {
        [JsonProperty("Global Quote")]
        public CompanyStocks CompanyStocks { get; set; }
    }
}
