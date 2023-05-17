using Newtonsoft.Json;
using Pokémon___7daysofcode.Model;
using RestSharp;
using System.Text.RegularExpressions;
using System.Threading.Channels;

public class PokemonData
{
    static int contagemDeVezes = 0;
    static List<string> pokemonAdquiridos = new();
    public Dex dex = new();
    public Pokemon Pkmn { get; private set; }
    internal Pokemon GetPokemon()
    {
        Console.Write("==========================================\nEscolha seu pokémon por nome ou número da dex: ");
        string pkmnN = Console.ReadLine().ToLower().Replace(' ', '-');
        if (!pkmnN.All(Char.IsLetterOrDigit))
        {
            Console.WriteLine("Não foi possível obter esse pokémon. Por favor, tente novamente.");
            return null;
        }
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pkmnN}");
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("Não foi possível obter esse pokémon. Por favor, tente novamente.");
            return null;
        }
        var pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);
        string pokeName = pokemon.Species.name;
        if (pokemonAdquiridos.Contains(pokeName))
        {
            Console.WriteLine("Você já obteve esse pokémon.");
            return null;
        }
        pokemonAdquiridos.Add(pokeName);
        pokemon.Health = pokemon.Stats[0].base_stat * 3 / 4;
        Console.WriteLine($"Você adquiriu {pokeName.Replace('-', ' ')}!");
        return pokemon;
    }


    internal void GetDex()
    {
        if (contagemDeVezes == 0)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokedex/national");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Não foi possível obter informações da dex, tente novamente.");
                return;
            }
            contagemDeVezes++;
            var dex = JsonConvert.DeserializeObject<Dex>(response.Content);
            this.dex = dex;
        }
        Console.WriteLine("Gostaria de ver a dex inteira(1) ou ver apenas uma porção da dex(2)?");
        if (Console.ReadLine() != "2")
        {
            Console.Write(this.dex.ToString(0, 1010));
            return;
        }
        Console.Write("Qual seria o número inicial da dex? ");
        if (!int.TryParse(Console.ReadLine(), out int rangeStart)) rangeStart = 0;
        Console.Write("E o número final? ");
        if (!int.TryParse(Console.ReadLine(), out int rangeEnd)) rangeEnd = 1010;
        Console.WriteLine(this.dex.ToString(rangeStart, rangeEnd));
        return;
    }
}