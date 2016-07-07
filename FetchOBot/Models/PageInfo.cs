namespace FetchOBotApi
{
    using System;
    using Newtonsoft.Json;

    public class PageInfo
    {
        [JsonProperty(PropertyName = "current_page")]
        public int CurrentPage;

        [JsonProperty(PropertyName = "next_page")]
        public int? NextPage;

        [JsonProperty(PropertyName = "prev_page")]
        public int? PreviousPage;

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages;

        [JsonProperty(PropertyName = "total_items")]
        public int TotalItems;
    }
}
