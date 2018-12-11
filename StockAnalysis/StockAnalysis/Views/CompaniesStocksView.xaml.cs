using StockAnalysis.ViewsModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockAnalysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompaniesStocksView : ContentPage
    {
        CompanyStocksViewModel companiesStocksViewModel;

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

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
