using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Pokémon___7daysofcode.Model
{
    public class Pokemon
    {
        public Pokemon()
        { }
        [JsonProperty("abilities")]
        internal List<Ability> Abilities { get; set; }
        [JsonProperty("height")]
        internal int Height { get; set; }
        [JsonProperty("id")]
        internal int Id { get; set; }
        [JsonProperty("species")]
        internal Species Species { get; set; }
        [JsonProperty("stats")]
        internal List<Stat> Stats { get; set; }
        [JsonProperty("types")]
        internal List<Type> Types { get; set; }
        internal int Health { get; set; }

        internal int happiness = RandomNumberGenerator.GetInt32(7, 10);
        internal int hunger = RandomNumberGenerator.GetInt32(7, 10);
        internal int tiredness = RandomNumberGenerator.GetInt32(7, 10);
        internal int age = 0;
        internal int StatTotal()
        {
            int bst = 0;
            foreach (var stat in Stats) { bst += stat.base_stat; }
            return bst;
        }
        internal string StringTypes()
        {
            var str = "Types: ";
            foreach (var type in Types)
            {
                str += $"{type.type.name.ToUpperInvariant()} ";
            }
            return str;
        }
        internal string StringAbilities()
        {
            var str = "";
            foreach (var ability in Abilities)
            {
                if (ability.is_hidden)
                {
                    str += $"Hidden Ability: {ability.ability.name.ToUpperInvariant().Replace('-', ' ')}";
                    str = str.Remove(str.IndexOf("Hidden") - 2, 1);
                }
                else str += $"{ability.ability.name.ToUpperInvariant().Replace('-', ' ')}, ";
            }
            if (str.EndsWith(", ")) str = str.Substring(0, str.Length - 2);
            return str;
        }
        internal string StringStats()
        {
            var str = "";
            foreach (var stat in Stats)
            {
                str += $"{stat.stat.name.ToUpperInvariant().Replace('-', ' ')}: {stat.base_stat}\n";
            }
            return str;
        }

        public override string ToString()
        {
            double trueHeight = (double)Height / 10;
            return $"Pokémon: {Species.name.ToUpperInvariant().Replace('-', ' ')}\nID: {Id}\nAbilities: {StringAbilities()}\n{StringTypes()}\nHeight: {trueHeight}M\n\nBase Stats:\n{StringStats()}Total: {StatTotal()}";
        }
    }
}
