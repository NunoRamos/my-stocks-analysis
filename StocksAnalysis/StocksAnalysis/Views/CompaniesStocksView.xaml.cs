using StocksAnalysis.ViewModels;
using StocksAnalysis.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace StocksAnalysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompaniesStocksView : ContentPage
    {
        CompaniesStocksViewModel companiesStocksViewModel;
        CompanyStockView companyView;
        public List<String> companiesToggled { get; set; }

        public CompaniesStocksView()
        {
            InitializeComponent();

            companiesStocksViewModel = new CompaniesStocksViewModel();
            BindingContext = companiesStocksViewModel;
            companiesToggled = new List<string>();

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

        void Handle_ItemToggled(object sender, ToggledEventArgs e)
        {
            Xamarin.Forms.Switch s = sender as Xamarin.Forms.Switch;
            Debug.WriteLine(s.BindingContext);
            if(companiesToggled.Contains((String)s.BindingContext)) 
                companiesToggled.Remove((String)s.BindingContext);
            else
                companiesToggled.Add((String)s.BindingContext);
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
