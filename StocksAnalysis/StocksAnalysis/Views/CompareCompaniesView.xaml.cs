using StocksAnalysis.ViewModels;
using StocksAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using Entry = Microcharts.Entry;

namespace StocksAnalysis.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompareCompaniesView : ContentPage
	{
        private CompaniesStocksView companiesStocksView;
        private CompareCompaniesViewModel compareCompaniesViewModel;

		public CompareCompaniesView (CompaniesStocksView c)
		{
			InitializeComponent ();
            this.companiesStocksView = c;
            this.compareCompaniesViewModel = new CompareCompaniesViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            String[] companiesSymbol = companiesStocksView.companiesToggled.ToArray();

            await compareCompaniesViewModel.UpdateCompanyStocksAsync(companiesSymbol);

            foreach (CompanyHistoryPrices companyHistoryPrice in this.compareCompaniesViewModel.CompaniesHistory)
            {
                List<Entry> entriesDailyPriceVariation = new List<Entry>();
                List<Entry> entriesOpenPrice = new List<Entry>();
                List<Entry> entriesClosePrice = new List<Entry>();
                List<Entry> entriesHighPrice = new List<Entry>();
                List<Entry> entriesLowPrice = new List<Entry>();
                List<Entry> entriesVolume = new List<Entry>();

                foreach (var day in companyHistoryPrice.Stats)
                {
                    string date = day.Key;
                    JToken value = day.Value;
                    float open = (float)value["1. open"];
                    float high = (float)value["2. high"];
                    float low = (float)value["3. low"];
                    float close = (float)value["4. close"];
                    float volume = (float)value["5. volume"];

                    entriesOpenPrice.Add(new Entry(open)
                    {
                        Color = SKColor.Parse("#0000FF")
                    });
                    entriesClosePrice.Add(new Entry(close)
                    {
                        Color = SKColor.Parse("#008000")
                    });
                    entriesHighPrice.Add(new Entry(high)
                    {
                        Color = SKColor.Parse("#FFFF00")
                    });
                    entriesLowPrice.Add(new Entry(low)
                    {
                        Color = SKColor.Parse("#FFA500")
                    });
                    entriesVolume.Add(new Entry(volume)
                    {
                        Color = SKColor.Parse("#000000")
                    });
                }

                companyHistoryPrice.ClosePriceVariations.ForEach((price) =>
                {
                    entriesDailyPriceVariation.Add(new Entry((float)price)
                    {
                        Color = SKColor.Parse("#FF1493")
                    });
                });

                Chart1.Chart = new BarChart { Entries = entriesDailyPriceVariation };
                Chart2.Chart = new LineChart { Entries = entriesOpenPrice };
                Chart3.Chart = new LineChart { Entries = entriesClosePrice };
                Chart4.Chart = new LineChart { Entries = entriesHighPrice };
                Chart5.Chart = new LineChart { Entries = entriesLowPrice };
                Chart6.Chart = new LineChart { Entries = entriesVolume };
            }
        }
    }
}