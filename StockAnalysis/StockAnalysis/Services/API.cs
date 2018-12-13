﻿using Newtonsoft.Json;
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
        const string BASE_URL = "http://192.168.1.3:3000";

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
