namespace FetchOBotApi
{
    using System;
    using Newtonsoft.Json;

    public class Card
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;

        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "mana")]
        public int? Mana;
    }
}
