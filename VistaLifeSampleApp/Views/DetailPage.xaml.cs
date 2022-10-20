using System;
using System.Collections.Generic;
using VistaLifeSampleApp.ViewModels;
using Xamarin.Forms;

namespace VistaLifeSampleApp.Views
{
    public partial class DetailPage : ContentPage
    {
        private DetailPageViewModel viewModel;
        private string _userName;
        public DetailPage(string userName)
        {
            InitializeComponent();
            BindingContext = viewModel = (DetailPageViewModel)App.ServiceProvider.GetService(typeof(DetailPageViewModel));
            _userName = userName;
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.SelectedUserName = _userName;
            viewModel.LoadSelectedUserData();

        }
    }
}
