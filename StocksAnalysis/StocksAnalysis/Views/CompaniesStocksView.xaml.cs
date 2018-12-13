using StocksAnalysis.ViewsModels;
using StocksAnalysis.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StocksAnalysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompaniesStocksView : ContentPage
    {
        CompanyStocksViewModel companiesStocksViewModel;
        CompanyStockView companyView;

        public CompaniesStocksView()
        {
            InitializeComponent();

            companiesStocksViewModel = new CompanyStocksViewModel();
            BindingContext = companiesStocksViewModel;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var companyStocks = e.Item as CompanyStocks;
            companyView = new CompanyStockView(companyStocks.Symbol);
            await this.Navigation.PushAsync(companyView);
            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await companiesStocksViewModel.UpdateCompanyStocksAsync();

            this.WaitingDataView.IsVisible = false;
            this.CompaniesStocksListView.IsVisible = true;
        }
    }
}
