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
            List<Entry> entries = new List<Entry>
            {
                new Entry(1)
                {
                    
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST1",
                    ValueLabel = "200"

                },
                new Entry(2)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST2",
                    ValueLabel = "50"

                },
                new Entry(3)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST3",
                    ValueLabel = "100"

                },new Entry(3)
                {

                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST1",
                    ValueLabel = "200"

                },
                new Entry(4)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST2",
                    ValueLabel = "50"

                },
                new Entry(0)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST3",
                    ValueLabel = "100"

                },new Entry(3)
                {

                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST1",
                    ValueLabel = "200"

                },
                new Entry(6)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST2",
                    ValueLabel = "50"

                },
                new Entry(10)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST3",
                    ValueLabel = "100"

                },new Entry(8)
                {

                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST1",
                    ValueLabel = "200"

                },
                new Entry(12)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST2",
                    ValueLabel = "50"

                },
                new Entry(16)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST3",
                    ValueLabel = "100"

                }
            };
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

            this.companyStockViewModel.CompanyStocks.ClosePriceVariations.ForEach((price) =>
            {
                entriesDailyPriceVariation.Add(new Entry((float)price) {
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