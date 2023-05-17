using Pokémon___7daysofcode.Model;
using Pokémon___7daysofcode.View;

class MenuInicial
{
    internal void Iniciar()
    {
        PokemonData list = new();
        MenuJogar g = new();
        List<Pokemon> plist = new();
        Console.WriteLine("Boas vindas ao projeto 'Pokémon - 7daysofcode.'\n\n");
        Console.WriteLine(@"                                  ,'\
    _.----.        ____         ,'  _\   ___    ___     ____
_,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`.
\      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  |
 \.    \ \   |  __  |  |/    ,','_  `.  |          | __  |    \|  |
   \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |
    \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     |
     \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |
      \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   |
       \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |
        \_.-'       |__|    `-._ |              '-.|     '-.| |   |
                                `'                            '-._|" + "\n\n\n\n");
        Console.Write("Olá! Qual o seu nome? ");
        string playerName = Console.ReadLine();
        bool leave = true;
        while (leave)
        {
            Console.Clear();
            Console.WriteLine("=============================== Menu ===============================");
            Console.WriteLine($"{playerName}, Escolha uma das opções:");
            Console.WriteLine("1- Obter lista de todos os pokémon");
            Console.WriteLine("2- Adotar um mascote");
            Console.WriteLine("3- Ver seus mascotes");
            Console.WriteLine("4- Iniciar o jogo");
            Console.WriteLine("5- Sair");
            if (!char.TryParse(Console.ReadLine(), out char a))
            {
                Console.WriteLine("Caractere não aceito, tente novamente.");
                Console.Clear();
            }
            switch (a)
            {
                case '1':
                    list.GetDex();
                    Console.ReadKey();
                    break;

                case '2':
                    Pokemon np = list.GetPokemon();
                    if (np != null) plist.Add(np);
                    Console.ReadKey();
                    break;

                case '3':
                    if (plist.Count == 0)
                    {
                        Console.WriteLine("Não há pokémon na lista.");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine($"Número de pokémon: {plist.Count}\n====================================================================");
                    foreach (Pokemon p in plist)
                    {
                        Console.ReadKey();
                        Console.WriteLine($"{p}\n====================================================================");
                    }
                    Console.ReadKey();
                    break;

                case '4':
                    if (plist.Count() != 0) g.Game(playerName, plist);
                    else
                    {
                        Console.WriteLine("É necessário ao menos um pokémon adotado para iniciar o jogo.");
                        Console.ReadKey();
                    }
                        break;

                case '5':
                    leave = false;
                    break;

                default:
                    Console.WriteLine("Função não existente.");
                    break;
            }

        }
        Console.WriteLine("Até mais!");
    }
}