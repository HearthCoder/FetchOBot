namespace FetchOBotApi
{
    using System;
    using Newtonsoft.Json;

    public class CardPlayed
    {
        [JsonProperty(PropertyName = "player")]
        public Player Player;

        [JsonProperty(PropertyName = "turn")]
        public int Turn;

        [JsonProperty(PropertyName = "card")]
        public Card Card;
    }
}
