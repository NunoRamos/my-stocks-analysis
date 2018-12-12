using Newtonsoft.Json;
using StockAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.Services
{
    static class API
    {
        const string API_KEY = "0V27RLXB3DH4EYVO";
        const string BASE_URL = "https://www.alphavantage.co/query?";

        public static async Task<List<CompanyStocks>> GetCompaniesStocks(String[] companies)
        {
            List<CompanyStocks> companyStocks = new List<CompanyStocks>();
            List<Task> taskList = new List<Task>();
            foreach (String company in companies)
            {
                var task = new Task(async () => {
                    using (var httpClient = new HttpClient())
                    {
                        Debug.WriteLine("começando");
                        var jsonString = await httpClient.GetStringAsync(BASE_URL + "function=GLOBAL_QUOTE&symbol=" + company + "&apikey=" + API_KEY);
                        var globalQuote = JsonConvert.DeserializeObject<GlobalQuote>(jsonString);
                        companyStocks.Add(globalQuote.CompanyStocks);
                        Debug.WriteLine("boas");
                    }
                });
                taskList.Add(task);
                task.Start();
            }

            Debug.WriteLine("vou esperar");

            await Task.WhenAll(taskList.ToArray());

            Debug.WriteLine("adeus");

            return companyStocks;
        }

        public static async Task<CompanyStocks> GetCompanyStocks(String company)
        {
            using (var httpClient = new HttpClient())
            {
                Debug.WriteLine("começando");
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "function=GLOBAL_QUOTE&symbol=" + company + "&apikey=" + API_KEY);
                var globalQuote = JsonConvert.DeserializeObject<GlobalQuote>(jsonString);
                //companyStocks.Add(globalQuote.CompanyStocks);
                Debug.WriteLine("boas");

                return globalQuote.CompanyStocks;
            }
        }

    }
}
