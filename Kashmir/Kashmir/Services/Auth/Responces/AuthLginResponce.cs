using Kashmir.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashmir.Services.Auth.Responces
{
    public class AuthLginResponce
    {
        [JsonProperty("access_token")]
        public string accessToken { get; set; }

        [JsonProperty("user_data")]
        public User userData { get; set; }
    }
}
