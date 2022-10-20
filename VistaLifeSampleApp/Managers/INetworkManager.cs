using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VistaLifeSampleApp.Models;

namespace VistaLifeSampleApp.Managers
{
    public interface INetworkManager
    {
        Task<List<User>> GetListOfUsers();
    }
}
