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

namespace StocksAnalysis.Views
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

            Chart1.Chart = new LineChart { Entries = entries };
            //Chart2.Chart = new LineChart { Entries = entries };
        }
	}
}