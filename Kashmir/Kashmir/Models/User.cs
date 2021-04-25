using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashmir.Models
{
    public sealed class User
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("location")]
        public UserLocation Location { get; set; }

        [JsonProperty("email_confirmed")]
        public int emailConfirmed { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("is_verified")]
        public string IsVerified { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("unblock_date")]
        public DateTime UnblockDate { get; set; }

        [JsonProperty("last_login")]
        public DateTime lastLogin { get; set; }

        [JsonProperty("last_activity")]
        public DateTime lastActivity { get; set; }

        [JsonProperty("created_at")]
        public DateTime createdAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updatedAt { get; set; }

    }

    public class UserLocation
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }



}
