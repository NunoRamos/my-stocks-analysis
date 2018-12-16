using Microcharts;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using StocksAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace StocksAnalysis.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyStockView : ContentPage
	{
        private String companySymbol;
        private CompanyStocksViewModel companyStockViewModel;

		public CompanyStockView (String companySymbol)
		{
            this.companySymbol = companySymbol;
            this.companyStockViewModel = new CompanyStocksViewModel(companySymbol);
            BindingContext = new { Symbol = companySymbol };

            InitializeComponent ();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await companyStockViewModel.UpdateCompanyStocksAsync();
            List<Entry> entriesDailyPriceVariation = new List<Entry>();
            List<Entry> entriesOpenPrice = new List<Entry>();
            List<Entry> entriesClosePrice = new List<Entry>();
            List<Entry> entriesHighPrice = new List<Entry>();
            List<Entry> entriesLowPrice = new List<Entry>();
            List<Entry> entriesVolume = new List<Entry>();

            foreach (var day in this.companyStockViewModel.CompanyStocks.Stats)
            {
                string date = day.Key;
                JToken value = day.Value;
                float open = (float) value["1. open"];
                float high = (float)value["2. high"];
                float low = (float)value["3. low"];
                float close = (float)value["4. close"];
                float volume = (float)value["5. volume"];

                entriesOpenPrice.Add(new Entry(open){
                    Color = SKColor.Parse("#0000FF"),
                    ValueLabel = string.Format("{0:0.0}", open)
            });
                entriesClosePrice.Add(new Entry(close)
                {
                    Color = SKColor.Parse("#008000"),
                    ValueLabel = string.Format("{0:0.0}", close)
                });
                entriesHighPrice.Add(new Entry(high)
                {
                    Color = SKColor.Parse("#FFFF00"),
                    ValueLabel = string.Format("{0:0.0}", high)
                });
                entriesLowPrice.Add(new Entry(low)
                {
                    Color = SKColor.Parse("#FFA500"),
                    ValueLabel = string.Format("{0:0.0}", low)
                });
                entriesVolume.Add(new Entry(volume)
                {
                    Color = SKColor.Parse("#000000"),
                    ValueLabel = string.Format("{0:0.0}", volume)
                });
            }

            this.companyStockViewModel.CompanyStocks.ClosePriceVariations.ForEach((price) =>
            {
                entriesDailyPriceVariation.Add(new Entry((float)price) {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = string.Format("{0:0.00}", price)
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