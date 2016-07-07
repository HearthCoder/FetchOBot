namespace FetchOBotApi
{
    using System;
    using Newtonsoft.Json;

    public class HistoryPage
    {
        [JsonProperty(PropertyName = "history")]
        public Game[] History;

        [JsonProperty(PropertyName = "meta")]
        public PageInfo Meta;
    }
}
