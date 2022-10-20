using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VistaLifeSampleApp.Services
{
    public interface INetworkService
    {
        Task<string> Get(string url, Dictionary<string, string> additionalHeaders = null);
        Task<string> Post(string url, object postBody, Dictionary<string, string> additionalHeaders = null);
    }
}
