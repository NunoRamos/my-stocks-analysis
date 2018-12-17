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

            List<Entry> entriesDailyPriceVariation = new List<Entry>();
            List<Entry> entriesOpenPrice = new List<Entry>();
            List<Entry> entriesClosePrice = new List<Entry>();
            List<Entry> entriesHighPrice = new List<Entry>();
            List<Entry> entriesLowPrice = new List<Entry>();
            List<Entry> entriesVolume = new List<Entry>();

            List<Entry> entriesDailyPriceVariation2 = new List<Entry>();
            List<Entry> entriesOpenPrice2 = new List<Entry>();
            List<Entry> entriesClosePrice2 = new List<Entry>();
            List<Entry> entriesHighPrice2 = new List<Entry>();
            List<Entry> entriesLowPrice2 = new List<Entry>();
            List<Entry> entriesVolume2 = new List<Entry>();

            var x = 0;

            foreach (CompanyHistoryPrices companyHistoryPrice in this.compareCompaniesViewModel.CompaniesHistory)
            {
                var color = "";
                if (x == 0)
                    color = "#0000FF";
                else
                    color = "#008000";
                
                foreach (var day in companyHistoryPrice.Stats)
                {
                    string date = day.Key;
                    JToken value = day.Value;
                    float open = (float)value["1. open"];
                    float high = (float)value["2. high"];
                    float low = (float)value["3. low"];
                    float close = (float)value["4. close"];
                    float volume = (float)value["5. volume"];

                    if (x == 0)
                    {
                        entriesOpenPrice.Add(new Entry(open)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", open)
                        });
                        entriesClosePrice.Add(new Entry(close)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", close)
                        });
                        entriesHighPrice.Add(new Entry(high)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", high)
                        });
                        entriesLowPrice.Add(new Entry(low)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", low)
                        });
                        entriesVolume.Add(new Entry(volume)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", volume)
                        });
                    }else
                    {
                        entriesOpenPrice2.Add(new Entry(open)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", open)
                        });
                        entriesClosePrice2.Add(new Entry(close)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", close)
                        });
                        entriesHighPrice2.Add(new Entry(high)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", high)
                        });
                        entriesLowPrice2.Add(new Entry(low)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", low)
                        });
                        entriesVolume2.Add(new Entry(volume)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", volume)
                        });
                    }
                }

                companyHistoryPrice.ClosePriceVariations.ForEach((price) =>
                {
                    if(x == 0)
                    {
                        entriesDailyPriceVariation.Add(new Entry((float)price)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", price)
                        });
                    }else
                        entriesDailyPriceVariation2.Add(new Entry((float)price)
                        {
                            Color = SKColor.Parse(color),
                            ValueLabel = string.Format("{0:0.0}", price)
                        });

                });
                x++;
            }
            Chart1.Chart = new BarChart { Entries = entriesDailyPriceVariation };
            Chart2.Chart = new LineChart { Entries = entriesOpenPrice };
            Chart3.Chart = new LineChart { Entries = entriesClosePrice };
            Chart4.Chart = new LineChart { Entries = entriesHighPrice };
            Chart5.Chart = new LineChart { Entries = entriesLowPrice };
            Chart6.Chart = new LineChart { Entries = entriesVolume };

            Chart7.Chart = new BarChart { Entries = entriesDailyPriceVariation2 };
            Chart8.Chart = new LineChart { Entries = entriesOpenPrice2 };
            Chart9.Chart = new LineChart { Entries = entriesClosePrice2 };
            Chart10.Chart = new LineChart { Entries = entriesHighPrice2 };
            Chart11.Chart = new LineChart { Entries = entriesLowPrice2 };
            Chart12.Chart = new LineChart { Entries = entriesVolume2 };
        }
    }
}