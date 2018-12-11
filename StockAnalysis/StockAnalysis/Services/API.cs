using Newtonsoft.Json;
using StockAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.Services
{
    static class API
    {
        const string API_KEY = "0V27RLXB3DH4EYVO";
        const string BASE_URL = "https://www.alphavantage.co/query?";

        public static async Task<List<CompanyStocks>> GetCompanyStocks()
        {
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "function=GLOBAL_QUOTE&symbol=MSFT&apikey=" + API_KEY);
                List<CompanyStocks> companyStocks = new List<CompanyStocks>();
                var globalQuote = JsonConvert.DeserializeObject<GlobalQuote>(jsonString);
                companyStocks.Add(globalQuote.CompanyStocks);
                return companyStocks;
            }

        }

    }
}
