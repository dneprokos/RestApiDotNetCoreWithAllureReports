﻿using Newtonsoft.Json;

namespace RestApiClient.RestApi.Models._CommonModels
{
    public class PagingBaseModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
