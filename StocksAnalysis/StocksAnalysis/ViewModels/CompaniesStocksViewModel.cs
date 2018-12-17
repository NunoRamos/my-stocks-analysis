using StocksAnalysis.Models;
using StocksAnalysis.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace StocksAnalysis.ViewModels
{
    class CompaniesStocksViewModel
    {
        public ObservableCollection<CompanyStocks> CompanyStocks { get; set; }
        public String[] NASDAQCompanies = new string[] { "MSFT", "AAPL", "AMZN", "GOOGL", "GOOG", "FB", "INTC", "CSCO", "CMCSA", "PEP" };

        public CompaniesStocksViewModel()
        {
            this.CompanyStocks = new ObservableCollection<CompanyStocks>();
        }

        public async Task UpdateCompanyStocksAsync()
        {
            var companyStocks = await API.GetCompaniesStocks(NASDAQCompanies);
            this.CompanyStocks.Clear();
            companyStocks.ForEach((companyStock) =>
            {
                companyStock.LogoImage = companyStock.Symbol + ".png";

                Double percent = double.Parse(companyStock.ChangePercent.TrimEnd("%".ToCharArray()), CultureInfo.InvariantCulture);
                if (percent > 0)
                    companyStock.PercentIcon = "up_arrow.png";
                else
                    companyStock.PercentIcon = "down_arrow.png";
                this.CompanyStocks.Add(companyStock);
            });
        }
    }
}
