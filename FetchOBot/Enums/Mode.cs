namespace FetchOBotApi
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Mode
    {
        Ranked,
        Casual,
        Solo,
        Arena,
        Friendly,
        Unknown
    }
}
