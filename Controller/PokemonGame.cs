using Pokémon___7daysofcode.Model;
using System.Security.Cryptography;

namespace Pokémon___7daysofcode.Controller
{
    internal class PokemonGame
    {
        internal string? NomeP { get; set; }
        internal int Fome { get; set; }
        internal int Sono { get; set; }
        internal int Felicidade { get; set; }
        internal int Vida { get; set; }

        internal Pokemon EscolhaPokemon(List<Pokemon> plist)
        {
            if (plist.Count() == 1)
            {
                var p = plist[0];
                NomeP = p.Species.name.ToLower().Replace('-', ' ');
                Fome = p.hunger;
                Felicidade = p.happiness;
                Sono = p.tiredness;
                Vida = p.Health;
                return p;
            }

            string str = "Você tem os seguintes pokémon: ";
            foreach (Pokemon p in plist)
            {
                str += $"{p.Species.name.ToUpperInvariant().Replace('-', ' ')}, ";
            }
            str = str.Remove(str.Length - 2).Replace('-', ' ');
            Console.WriteLine($"{str}. Destes pokémon, qual você deseja cuidar no momento?");
            string cp = Console.ReadLine();
            foreach (Pokemon p in plist)
            {
                string pName = p.Species.name.ToLower().Replace('-', ' ');
                if (pName == cp.ToLower())
                {
                    NomeP = p.Species.name.ToLower().Replace('-', ' ');
                    Fome = p.hunger;
                    Felicidade = p.happiness;
                    Sono = p.tiredness;
                    Vida = p.Health;
                    return p;
                }
            }
            Console.Write("Pokémon não encontrado.");
            return null;
        }

        internal char EscolhaAcao(string name, Pokemon p)
        {
            Console.WriteLine("=============================== Menu ===============================");
            Console.WriteLine($"{name}, você deseja:");
            Console.WriteLine($"1- Saber como {NomeP} está");
            Console.WriteLine($"2- Conferir informações de {NomeP}");
            Console.WriteLine($"3- Brincar com {NomeP}");
            Console.WriteLine($"4- Botar {NomeP} para dormir");
            Console.WriteLine($"5- Alimentar {NomeP}");
            Console.WriteLine("6- Sair");
            if (!char.TryParse(Console.ReadLine(), out char a))
            {
                return 'x';
            }
            return a;
        }

        internal void Status(Pokemon cp)
        {
            Console.WriteLine("====================================================================");
            string str = $"{NomeP} tem {cp.age} dias de idade!\n{NomeP} tem atualmente {Vida}HP.\n";
            if (Felicidade < 3)
            {
                str += $"{NomeP} está triste. \n";
            }
            else if (Felicidade < 6)
            {
                str += $"{NomeP} está começando a se sentir entediado. \n";
            }
            else
            {
                str += $"{NomeP} está bem bem feliz! \n";
            }

            if (Sono < 3)
            {
                str += $"{NomeP} está morrendo de sono.\n";
            }
            else if (Sono < 8)
            {
                str += $"{NomeP} está um pouco sonolento.\n";
            }
            else
            {
                str += $"{NomeP} está cheio de energia!\n";
            }

            if (Fome < 3)
            {
                str += $"{NomeP} está com muita fome.";
            }
            else if (Fome < 6)
            {
                str += $"{NomeP} está começando a sentir fome.";
            }
            else
            {
                str += $"{NomeP} está bem alimentado!";
            }
            Console.WriteLine(str);
            Console.WriteLine("====================================================================");
        }
        internal void GetInfo(Pokemon cp)
        {
            Console.WriteLine("====================================================================");
            string str = $"{cp.ToString()}\n\nVida: {Vida}/{cp.Stats[0].base_stat * 3 / 4}HP\nFelicidade: {Felicidade}/9\nFome: {Fome}/11\nSono {Sono}/15\nIdade: {cp.age} dias";
            Console.WriteLine(str);
            Console.WriteLine("====================================================================");
        }
        internal void Sleep(Pokemon cp)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine($"{NomeP} dormiu!");
            Sono += RandomNumberGenerator.GetInt32(7, 9);
            if (Sono > 15)
            {
                Sono = 11;
            }
            Console.WriteLine("====================================================================");
        }
        internal void Food(Pokemon cp)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine($"{NomeP} foi alimentado!");
            Fome += RandomNumberGenerator.GetInt32(2, 4);
            if (Fome > 11)
            {
                Fome = 11;
            }
            Console.WriteLine("====================================================================");
        }

        internal void Play(Pokemon cp)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine($"Você brincou com {NomeP}.");
            Felicidade += 3;
            if (Felicidade > 9)
            {
                Felicidade = 9;
            }
            Console.WriteLine("====================================================================");
        }

        internal bool Update(Pokemon cp, int val)
        {
            if (val != 1 && val != 2)
            {
                if (val != 6)
                {
                    Fome -= RandomNumberGenerator.GetInt32(1, 3);
                    Felicidade -= RandomNumberGenerator.GetInt32(1, 2);
                    Sono -= RandomNumberGenerator.GetInt32(1, 3);
                }
                Limit();
                cp.hunger = Fome;
                cp.happiness = Felicidade;
                cp.tiredness = Sono;
                cp.Health = Vida;
                if (val != 6)
                {
                    cp.age += 1;
                    Console.WriteLine("Passou-se um dia.");
                    Console.WriteLine("====================================================================");
                    if (Fome == 0) Vida -= RandomNumberGenerator.GetInt32(3, 5);
                    if (Felicidade == 0) Vida -= RandomNumberGenerator.GetInt32(2, 4);
                    if (Sono == 0) Vida -= RandomNumberGenerator.GetInt32(8, 10);
                }
                if (Vida <= 0)
                {
                    return true;
                }

            }
            Console.ReadKey();
            return false;
        }

        private void Limit()
        {
            if (Fome < 0) Fome = 0;
            if (Sono < 0) Sono = 0;
            if (Felicidade < 0) Felicidade = 0;
        }

        internal void DesmaioPokemon(List<Pokemon> plist, Pokemon cp)
        {
            Console.WriteLine($"{NomeP} desmaiou e foi levado para o centro pokémon mais próximo. Infelizmente parece que não irá voltar tão cedo. Tome mais cuidado da próxima vez.");
            plist.Remove(cp);
            Console.ReadKey();
        }
    }
}
