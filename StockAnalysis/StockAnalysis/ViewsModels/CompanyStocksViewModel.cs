using StockAnalysis.Models;
using StockAnalysis.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.ViewsModels
{
    class CompanyStocksViewModel
    {
        public ObservableCollection<CompanyStocks> CompanyStocks { get; set; }

        public CompanyStocksViewModel()
        {
            this.CompanyStocks = new ObservableCollection<CompanyStocks>();

            this.CompanyStocks.Add(new CompanyStocks
            {
                Symbol = "GOOG",
                AtualPrice = 10
            });

            this.CompanyStocks.Add(new CompanyStocks
            {
                Symbol = "MSF",
                AtualPrice = 15
            });
        }

        public async Task UpdateCompanyStocksAsync()
        {
            var companyStocks = await API.GetCompanyStocks();
            this.CompanyStocks.Clear();
            companyStocks.ForEach((companyStock) =>
            {
                this.CompanyStocks.Add(companyStock);
            });
        }
    }
}
