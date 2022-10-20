using System;
using System.Windows.Input;
using VistaLifeSampleApp.Common.Toast;
using VistaLifeSampleApp.Common.Utilities;
using VistaLifeSampleApp.Views;
using Xamarin.Forms;

namespace VistaLifeSampleApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
            LoginCommand = new Command(ValidateLogin);
        }

        #region XAML Properties

        public string UserName
        {
            get => GetPropertyValue<string>();
            set
            {
                SetPropertyValue(value);
                //TODO: The login page button disabling is not working for some reason, need to research more into it.
                OnPropertyChanged(nameof(LoginButtonEnabledString));
            }
        }

        public string Password
        {
            get => GetPropertyValue<string>();
            set
            {
                SetPropertyValue(value);
                //TODO: The login page button disabling is not working for some reason, need to research more into it.
                OnPropertyChanged(nameof(LoginButtonEnabledString));
            }
        }

        public string LoginButtonEnabledString => $"{UserName};{Password}";

        public ICommand LoginCommand { get; set; }

        #endregion


        #region Private Methods

        private void ValidateLogin()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                return;

            if (UserName.ToLower() == ApplicationConstants.UserName && Password == ApplicationConstants.Password)
            {
                Application.Current.MainPage = new NavigationPage(new ListingPage());
            }
            else
            {
                DependencyService.Get<IToastMessage>().ShowMessage(ApplicationConstants.InvalidCredentials);
            }

        }

        #endregion

    }
}
