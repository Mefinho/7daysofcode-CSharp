using Newtonsoft.Json;

internal class Type
{
    [JsonProperty("slot")]
    internal int slot { get; set; }
    [JsonProperty("type")]
    internal TypeInternal type { get; set; }
}
