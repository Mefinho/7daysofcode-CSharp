using Newtonsoft.Json;

internal class Ability
{
    [JsonProperty("ability")]
    internal AbilityInternal ability { get; set; }
    [JsonProperty("is_hidden")]
    internal bool is_hidden { get; set; }
    [JsonProperty("slot")]
    internal int slot { get; set; }
}
