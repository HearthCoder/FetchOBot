namespace FetchOBotApi
{
    using System;
    using Newtonsoft.Json;

    public class Game
    {
        [JsonProperty(PropertyName = "id")]
        public int Id;

        [JsonProperty(PropertyName = "mode")]
        public Mode Mode;

        [JsonProperty(PropertyName = "hero")]
        public Hero Hero;

        [JsonProperty(PropertyName = "hero_deck")]
        public string HeroDeck;

        [JsonProperty(PropertyName = "opponent")]
        public Hero Opponent;

        [JsonProperty(PropertyName = "opponent_deck")]
        public string OpponentDeck;

        [JsonProperty(PropertyName = "coin")]
        public bool Coin;

        [JsonProperty(PropertyName = "result")]
        public Result Result;

        [JsonProperty(PropertyName = "duration")]
        public int Duration;

        [JsonProperty(PropertyName = "rank")]
        public int? Rank;

        [JsonProperty(PropertyName = "legend")]
        public int? Legend;

        [JsonProperty(PropertyName = "note")]
        public string Note;

        [JsonProperty(PropertyName = "added")]
        public DateTime Added;

        [JsonProperty(PropertyName = "card_history")]
        public CardPlayed[] CardHistory;
    }
}
