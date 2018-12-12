using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockAnalysis.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyStockView : ContentPage
	{
        private String companySymbol;
		public CompanyStockView (String companySymbol)
		{
            this.companySymbol = companySymbol;
			InitializeComponent ();
		}
	}
}