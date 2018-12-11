using StockAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
                ClosingPrice = 10
            });

            this.CompanyStocks.Add(new CompanyStocks
            {
                Symbol = "MSF",
                ClosingPrice = 15
            });
        }
    }
}
