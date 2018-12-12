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
        public String[] NASDAQCompanies = new string[] { "GOOG" };
        //public String[] NASDAQCompanies = new string[] { "MSFT" };

        public CompanyStocksViewModel()
        {
            this.CompanyStocks = new ObservableCollection<CompanyStocks>();

            /*this.CompanyStocks.Add(new CompanyStocks
            {
                Symbol = "GOOG",
                AtualPrice = 10
            });

            this.CompanyStocks.Add(new CompanyStocks
            {
                Symbol = "MSF",
                AtualPrice = 15
            });*/
        }

        public async Task UpdateCompanyStocksAsync()
        {
            /*var companyStocks = await API.GetCompanyStocks(NASDAQCompanies);
            this.CompanyStocks.Clear();
            companyStocks.ForEach((companyStock) =>
            {
                this.CompanyStocks.Add(companyStock);
            });*/
            this.CompanyStocks.Clear();
            List<Task> taskList = new List<Task>();
            foreach (String company in NASDAQCompanies)
            {
                var task = new Task(async () => {
                    CompanyStocks companyStocks = await API.GetCompanyStocks(company);
                    this.CompanyStocks.Add(companyStocks);
                });
                taskList.Add(task);
                task.Start();
            }

            await Task.WhenAll(taskList.ToArray());
        }
    }
}
