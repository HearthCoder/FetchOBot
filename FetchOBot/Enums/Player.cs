namespace FetchOBotApi
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Player
    {
        Me,
        Opponent
    }
}
