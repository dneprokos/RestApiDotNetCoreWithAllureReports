using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestApiClient.RestApi.Models._CommonModels
{
    public class PagingResponseModel<T> : PagingBaseModel
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }
        [JsonProperty("support")]
        public SupportModel Support { get; set; }
    }
}
