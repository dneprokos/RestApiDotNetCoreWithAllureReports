using Newtonsoft.Json;

namespace RestApiClient.RestApi.Models._CommonModels
{
    public class SupportModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
