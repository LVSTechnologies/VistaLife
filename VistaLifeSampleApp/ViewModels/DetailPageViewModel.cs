using System;
using System.Linq;
using System.Windows.Input;
using VistaLifeSampleApp.Models;
using Xamarin.Forms;

namespace VistaLifeSampleApp.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        public DetailPageViewModel()
        {
            CancelCommand = new Command(BackToListingPage);
            UpdateCommand = new Command(UpdateUserInformation);
        }


        #region XML Properties
        public User SelectedUser
        {
            get => GetPropertyValue<User>();
            set => SetPropertyValue(value);
        }

        public string SelectedUserName
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public string UserName
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public string FullName
        {
            get => GetPropertyValue<string>();
            set 
            {
                SetPropertyValue(value);
                OnPropertyChanged(nameof(ButtonEnabledString));
            }
        }

        public string EmailAddress
        {
            get => GetPropertyValue<string>();
            set
            {
                SetPropertyValue(value);
                OnPropertyChanged(nameof(ButtonEnabledString));
            }
        }

        public string ButtonEnabledString => $"{FullName};{EmailAddress}";

        public string PhoneNumber
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }
        public string WebSite
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public ICommand CancelCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        #endregion


        #region Private and Public Methods

        private async void BackToListingPage()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void UpdateUserInformation()
        {
            if (!string.IsNullOrEmpty(SelectedUserName))
            {
                var selectedUser = UsersList.First(x => x.UserName == SelectedUserName);
                selectedUser.FullName = FullName;
                selectedUser.EmailAddress = EmailAddress;
                selectedUser.PhoneNumber = PhoneNumber;
                selectedUser.WebSite = WebSite;
                App.UsersList = UsersList;

            }
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void LoadSelectedUserData()
        {
            if (string.IsNullOrEmpty(SelectedUserName)) return;

            UsersList = App.UsersList;

            if (UsersList == null) return;

            SelectedUser = UsersList.FirstOrDefault(x => x.UserName == SelectedUserName);
            if (SelectedUser != null)
            {
                FullName = SelectedUser.FullName;
                UserName = SelectedUser.UserName;
                EmailAddress = SelectedUser.EmailAddress;
                PhoneNumber = SelectedUser.PhoneNumber;
                WebSite = SelectedUser.WebSite;
            }
        }

        #endregion
    }
}
