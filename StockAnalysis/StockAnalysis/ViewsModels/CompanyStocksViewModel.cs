using StockAnalysis.Models;
using StockAnalysis.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.ViewsModels
{
    class CompanyStocksViewModel
    {
        public ObservableCollection<CompanyStocks> CompanyStocks { get; set; }
        public String[] NASDAQCompanies = new string[] { "MSFT", "AAPL", "AMZN", "GOOGL", "GOOG" };

        public CompanyStocksViewModel()
        {
            this.CompanyStocks = new ObservableCollection<CompanyStocks>();
        }

        public async Task UpdateCompanyStocksAsync()
        {
            var companyStocks = await API.GetCompaniesStocks(NASDAQCompanies);
            this.CompanyStocks.Clear();
            companyStocks.ForEach((companyStock) =>
            {
                this.CompanyStocks.Add(companyStock);
            });
        }
    }
}
