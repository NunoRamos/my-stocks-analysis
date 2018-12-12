using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace StockAnalysis.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyStockView : ContentPage
	{
        private String companySymbol;
		public CompanyStockView (String companySymbol)
		{
            this.companySymbol = companySymbol;
            List<Entry> entries = new List<Entry>
            {
                new Entry(200)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST1",
                    ValueLabel = "200"

                },
                new Entry(50)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST2",
                    ValueLabel = "50"

                },
                new Entry(100)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "TEST3",
                    ValueLabel = "100"

                }
            };
            BindingContext = new { Symbol = companySymbol };

            InitializeComponent ();

            Chart1.Chart = new LineChart { Entries = entries };
        }
	}
}