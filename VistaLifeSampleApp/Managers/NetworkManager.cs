using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VistaLifeSampleApp.Common.Utilities;
using VistaLifeSampleApp.Models;
using VistaLifeSampleApp.Services;

namespace VistaLifeSampleApp.Managers
{
    public class NetworkManager : INetworkManager
    {
        private readonly INetworkService _networkService;
        public NetworkManager(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<List<User>> GetListOfUsers()
        {
            List<User> usersList = new List<User>();
            var response = await _networkService.Get(ApplicationConstants.BaseURL);

            if (!string.IsNullOrEmpty(response))
            {
                try
                {
                    usersList = JsonConvert.DeserializeObject<List<User>>(response);
                }
                catch (Exception ex)
                {
                    //TODO: Need to do proper logging in Production app
                }
                
            }

            return usersList;
        }
    }
}
