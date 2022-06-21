using System;
using Newtonsoft.Json;

namespace RestApiClient.RestApi.Models.Users
{
    public class UserModelV1
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }
    }
}
