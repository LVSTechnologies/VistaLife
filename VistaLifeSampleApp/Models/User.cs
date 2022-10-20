using System;
using Newtonsoft.Json;

namespace VistaLifeSampleApp.Models
{
    public class User
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string FullName { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("website")]
        public string WebSite { get; set; }

    }
}
