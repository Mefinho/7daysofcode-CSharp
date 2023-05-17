using Newtonsoft.Json;

internal class Species
{
    [JsonProperty("name")]
    internal string name { get; set; }
    [JsonProperty("url")]
    internal string url { get; set; }
}
