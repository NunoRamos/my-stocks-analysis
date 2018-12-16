using StocksAnalysis.Models;
using StocksAnalysis.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace StocksAnalysis.ViewModels
{
    class CompanyStocksViewModel
    {
        public CompanyHistoryPrices CompanyStocks { get; set; }
        public String CompanySymbol { get; set; }
        public CompanyStocksViewModel(String companySymbol)
        {
            this.CompanySymbol = companySymbol;
        }
        public async Task UpdateCompanyStocksAsync()
        {
            var companyStocks = await API.GetCompanyHistory(this.CompanySymbol);
            CompanyStocks = companyStocks[0];
        }
    }
}
