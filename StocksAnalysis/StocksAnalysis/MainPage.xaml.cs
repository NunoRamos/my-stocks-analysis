﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StocksAnalysis.Views;

namespace StocksAnalysis
{
    public partial class MainPage : TabbedPage
    {
        CompaniesStocksView companiesStocksView { get; set; }
        CompareCompaniesView compareCompaniesView { get; set; }

        public MainPage()
        {
            InitializeComponent();
            companiesStocksView = new CompaniesStocksView();
            compareCompaniesView = new CompareCompaniesView(companiesStocksView);
            Children.Add(companiesStocksView);
            Children.Add(compareCompaniesView);
        }
    }
}
