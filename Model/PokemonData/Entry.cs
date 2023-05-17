using Newtonsoft.Json;
internal class Entry
{
    [JsonProperty("entry_number")]
    internal int entry { get; set; }
    [JsonProperty("pokemon_species")]
    internal Species species { get; set; }
}