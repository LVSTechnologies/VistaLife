using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using VistaLifeSampleApp.Managers;
using VistaLifeSampleApp.Models;
using VistaLifeSampleApp.Services;
using VistaLifeSampleApp.ViewModels;
using VistaLifeSampleApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VistaLifeSampleApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static List<User> UsersList { get; set; }

        public App()
        {
            InitializeComponent();
            SetupService();

            MainPage = new NavigationPage(new LoginPage());
        }

        private void SetupService(Action<IServiceCollection> addPlatformServices = null)
        {
            var services = new ServiceCollection();
            addPlatformServices?.Invoke(services);

            services.AddSingleton<LoginPageViewModel>();
            services.AddSingleton<ListingPageViewModel>();
            services.AddSingleton<DetailPageViewModel>();

            services.AddSingleton<INetworkService, NetworkService>();
            services.AddSingleton<INetworkManager, NetworkManager>();

            ServiceProvider = services.BuildServiceProvider();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
