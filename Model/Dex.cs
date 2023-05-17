using Newtonsoft.Json;

public class Dex
{
    public Dex() { }
   
    [JsonProperty("pokemon_entries")]
    internal List<Entry> Entries { get; set; }
    [JsonProperty("region")]
    internal string Region { get; set; }

    public string ToString(int rangeStart, int rangeEnd)
    {
        string str = "------ Dex ------\n";
        foreach (Entry pokemon in this.Entries)
        {
            int pe = pokemon.entry;
            if (rangeEnd > rangeStart)
            {
                if (pe > rangeEnd) break;
                if (pe >= rangeStart) str += $"{pe}- {pokemon.species.name.ToUpperInvariant().Replace('-', ' ')}\n";
            }
            else
            {
                if (pe > rangeStart) break;
                if (pe >= rangeEnd) str += $"{pe}- {pokemon.species.name.ToUpperInvariant().Replace('-', ' ')}\n";
            }
        }
        return str;
    }
}
