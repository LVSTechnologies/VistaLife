using System;
using System.Collections.Generic;
using VistaLifeSampleApp.ViewModels;
using Xamarin.Forms;

namespace VistaLifeSampleApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginPageViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = (LoginPageViewModel)App.ServiceProvider.GetService(typeof(LoginPageViewModel));
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
