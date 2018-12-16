using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StocksAnalysis.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompareCompaniesView : ContentPage
	{
        CompaniesStocksView companiesStocksView;

		public CompareCompaniesView (CompaniesStocksView c)
		{
			InitializeComponent ();
            companiesStocksView = c;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            foreach(String companySymbol in companiesStocksView.companiesToggled)
            {
                // construct array
            }

            // call api
        }
    }
}