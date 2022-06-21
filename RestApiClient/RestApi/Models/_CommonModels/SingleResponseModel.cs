using Newtonsoft.Json;

namespace RestApiClient.RestApi.Models._CommonModels
{
    public class SingleResponseModel<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("support")]
        public SupportModel Support { get; set; }
    }
}
