using Pokémon___7daysofcode.Controller;
using Pokémon___7daysofcode.Model;

namespace Pokémon___7daysofcode.View
{
    public class MenuJogar
    {
        internal void Game(string player, List<Pokemon> plist)
        {
            PokemonGame menu = new();
            Pokemon cp = new();
            bool loop_0 = true;
            bool loop_1 = true;
            while (loop_0)
            {
                cp = menu.EscolhaPokemon(plist);
                if (cp != null)
                {
                    loop_0 = false;
                }
            }
            while (loop_1)
            {
                Console.Clear();
                char acao = menu.EscolhaAcao(player, cp);
                switch (acao)
                {
                    case '1':
                        menu.Status(cp);
                        break;

                    case '2':
                        menu.GetInfo(cp);
                        break;


                    case '3':
                        menu.Play(cp);
                        break;

                    case '4':
                        menu.Sleep(cp);
                        break;

                    case '5':
                        menu.Food(cp);
                        break;

                    case '6':
                        loop_1 = false;
                        break;

                    default:
                        Console.WriteLine("Função não implementada");
                        break;
                }
                if (!int.TryParse(acao.ToString(), out int acao_val))
                {
                    Console.ReadKey();
                }
                else if (menu.Update(cp, acao_val))
                {
                    menu.DesmaioPokemon(plist, cp);
                    loop_1 = false;
                }
            }
        }
    }
}
