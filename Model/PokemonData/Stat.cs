using Newtonsoft.Json;

internal class Stat
{
    [JsonProperty("base_stat")]
    internal int base_stat { get; set; }
    [JsonProperty("effort")]
    internal int effort { get; set; }
    [JsonProperty("stat")]
    internal StatInternal stat { get; set; }
}
