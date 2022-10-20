using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VistaLifeSampleApp.ViewModels;
using Xamarin.Forms;

namespace VistaLifeSampleApp.Views
{
    public partial class ListingPage : ContentPage
    {
        private ListingPageViewModel viewModel;
        public ListingPage()
        {
            InitializeComponent();
            BindingContext = viewModel = (ListingPageViewModel)App.ServiceProvider.GetService(typeof(ListingPageViewModel));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ReloadData();
        }

        async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = searchBar.Text;
            await viewModel.PerformSearchForTextChanged(searchTerm);
            if (!searchBar.IsFocused)
                searchBar.Focus();
        }
    }
}
