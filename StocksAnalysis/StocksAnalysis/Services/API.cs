using Newtonsoft.Json;
using StocksAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace StocksAnalysis.Services
{
    static class API
    {
        //const string BASE_URL = "http://192.168.1.7:3000";
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

        public static async Task<List<CompanyHistoryPrices>> GetCompanyHistory(String company)
        {
            List<CompanyHistoryPrices> companyHistoryPrices = new List<CompanyHistoryPrices>();
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/companies/monthly-stats/[\""+ company + "\"]");
                companyHistoryPrices = JsonConvert.DeserializeObject<List<CompanyHistoryPrices>>(jsonString);
            }

            return companyHistoryPrices;
        }

        public static async Task<List<CompanyHistoryPrices>> GetCompaniesHistory(String[] companies)
        {
            List<CompanyHistoryPrices> companyHistoryPrices = new List<CompanyHistoryPrices>();
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/companies/monthly-stats/[\"" + string.Join("\", \"", companies) + "\"]");
                companyHistoryPrices = JsonConvert.DeserializeObject<List<CompanyHistoryPrices>>(jsonString);
            }

            return companyHistoryPrices;
        }
    }
}
