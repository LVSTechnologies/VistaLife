using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VistaLifeSampleApp.Common.Utilities;

namespace VistaLifeSampleApp.Services
{
    public class NetworkService : INetworkService
    {
        private readonly HttpClient _httpClient;
        public NetworkService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> Get(string url, Dictionary<string, string> additionalHeaders = null)
        {
            return await SendRequest(HttpMethod.Get, url, additionalHeaders);
        }

        public async Task<string> Post(string url, object postBody, Dictionary<string, string> additionalHeaders = null)
        {
            return await SendRequest(HttpMethod.Post, url, postBody, additionalHeaders);
        }

        private async Task<string> SendRequest(HttpMethod requestType, string url, object requestBody = null, Dictionary<string, string> additionalHeaders = null)
        {
            var request = new HttpRequestMessage(requestType, url);

            if (additionalHeaders != null)
            {
                foreach (var header in additionalHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);

                }
            }

            if (requestBody != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, ApplicationConstants.JsonType);
            }
            string responseString = null;

            try
            {
                var response = await _httpClient.SendAsync(request);
                responseString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                //TODO: need to add logging in a production App

            }

            return responseString;

        }
    }
}
