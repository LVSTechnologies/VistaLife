using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VistaLifeSampleApp.Common.Toast;
using VistaLifeSampleApp.Common.Utilities;
using VistaLifeSampleApp.Managers;
using VistaLifeSampleApp.Models;
using VistaLifeSampleApp.Services;
using VistaLifeSampleApp.Views;
using Xamarin.Forms;

namespace VistaLifeSampleApp.ViewModels
{
    public class ListingPageViewModel : BaseViewModel
    {
        private readonly INetworkManager _networkManager;

        public ListingPageViewModel(INetworkManager networkManager)
        {
            _networkManager = networkManager;
            SelectedUserCommand = new Command(ShowDetailPage);
            PerformSearchCommand = new Command(async (p) => await PerformSearch(p));
            LoadUsers();

        }
        

        #region XML Properties

        public ObservableCollection<User> Users
        {
            get => GetPropertyValue<ObservableCollection<User>>();
            set => SetPropertyValue(value);
        }
        public User SelectedUser
        {
            get => GetPropertyValue<User>();
            set => SetPropertyValue(value);
        }
        public ICommand SelectedUserCommand { get; set; }

        public ICommand PerformSearchCommand { get; set; }

        public List<User> OriginalListOfUsers
        {
            get => GetPropertyValue<List<User>>();
            set => SetPropertyValue(value);
        }

        #endregion

        #region Private Methods

        private async void LoadUsers()
        {
            if (Users != null && Users.Count > 0)
                return;

            UsersList = await _networkManager.GetListOfUsers();
            App.UsersList = UsersList;
            OriginalListOfUsers = UsersList;

            if (UsersList?.Count > 0)
            {
                Users = new ObservableCollection<User>(UsersList);
            }

        }

        private async void ShowDetailPage()
        {
            if (SelectedUser == null)
            {
                DependencyService.Get<IToastMessage>().ShowMessage(ApplicationConstants.CannotFindDetailItem);
                return;
            }
            await Application.Current.MainPage.Navigation.PushAsync(new DetailPage(SelectedUser.UserName));
        }

        /// <summary>
        /// I am not able to use the Command for Search Bar as the search bar does not have
        /// Clear functionality unless I implement a Custom renderer
        /// Due to time constraints for now I have implemented the text changed event on the Search bar
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private async Task PerformSearch(object p)
        {
            if (p == null) return;
            var searchTerm = Convert.ToString(p);
            if (string.IsNullOrEmpty(searchTerm)) return;

            var users = Users.Where(x => x.FullName.Contains(searchTerm) || x.UserName.Contains(searchTerm)).ToList();

            Users = new ObservableCollection<User>(users);

        }

        #endregion

        #region Public Methods

        public void ReloadData()
        {
            if (App.UsersList != null && App.UsersList.Count > 0)
            {
                Users = new ObservableCollection<User>(App.UsersList);
                OriginalListOfUsers = App.UsersList;
            }

        }

        public async Task PerformSearchForTextChanged(string searchTerm)
        {
            await Task.Delay(100);
            if (string.IsNullOrEmpty(searchTerm))
            {
                Users = new ObservableCollection<Models.User>(OriginalListOfUsers);
            }
            else
            {
                var usersList = OriginalListOfUsers.Where(x => x.FullName.ToLower().Contains(searchTerm.ToLower())
                || x.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();

                Users = new ObservableCollection<Models.User>(usersList);

            }

        }

        #endregion
    }
}
