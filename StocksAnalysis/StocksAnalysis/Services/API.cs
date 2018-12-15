using Newtonsoft.Json;
using StocksAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StocksAnalysis.Services
{
    static class API
    {
        // const string BASE_URL = "http://10.227.144.149:3000";
        const String BASE_URL = "https://stock-analysis-api.herokuapp.com";

        public static async Task<List<CompanyStocks>> GetCompaniesStocks(String[] companies)
        {

            List<CompanyStocks> companyStocks = new List<CompanyStocks>();

            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/companies/daily-quote/" + "[\"" + string.Join("\", \"", companies) + "\"]");
                companyStocks = JsonConvert.DeserializeObject<List<CompanyStocks>>(jsonString);
            }

            return companyStocks;
        }
    }
}
