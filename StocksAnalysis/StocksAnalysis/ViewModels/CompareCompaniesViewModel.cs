using StocksAnalysis.Models;
using StocksAnalysis.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StocksAnalysis.ViewModels
{
    class CompareCompaniesViewModel
    {
        public List<CompanyHistoryPrices> CompaniesHistory { get; set; }

        public CompareCompaniesViewModel()
        {

        }

        public async Task UpdateCompanyStocksAsync(String[] companiesSymbol)
        {
            CompaniesHistory = await API.GetCompaniesHistory(companiesSymbol);
        }
    }
}
