using Newtonsoft.Json;

internal class StatInternal
{
    [JsonProperty("name")]
    internal string name { get; set; }
    [JsonProperty("url")]
    internal string url { get; set; }
}