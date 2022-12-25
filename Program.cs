using System.Reflection.Metadata.Ecma335;

namespace ByteBank1
{

    public class Program
    {
        static void MostrarJogo(char[] posicoes) {

            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine($"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__");
            Console.WriteLine($"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__");
            Console.WriteLine($"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n");

        }

        static void CadastrarJogadores(String[,] players) {

            Console.WriteLine("Informe o nome do jogador 1: ");
            players[0,0] = Console.ReadLine();

            Console.WriteLine("Informe o nome do jogador 2:");
            players[1,0] = Console.ReadLine();
           

            Console.WriteLine("\n--------------------------------");
            Console.WriteLine($"Jogadores cadastrados:\nX = {players[0,0]}\nO = {players[1,0]}");

            
            System.Threading.Thread.Sleep(3000);


        }

        static int Jogar(String[,] players, int jogadorAtual,char[] posicoes,char[] jogadas, int vencedor) {
            int posicao;
            
            do
            {
                Console.WriteLine($"{players[jogadorAtual,0]} esolha a posição para jogar");
                
                posicao = int.Parse(Console.ReadLine()) -1;
              
                if (jogadas[posicao] == 'n')
                {
                   
                    posicoes[posicao] = char.Parse(players[jogadorAtual, 1]);
                    jogadas[posicao] = 's';
                    if (jogadorAtual == 0)
                    {
                        jogadorAtual = 1;
                    }
                    else
                    {
                        jogadorAtual = 0;
                    }
                }
                else {
                    Console.WriteLine("Essa posição ja foi ocupada, tecle enter para continuar");
                    Console.ReadLine();
                }
            } while (jogadas[posicao] == 'n');

            return jogadorAtual;



        }


        public static void Main(string[] args)

        {
            char[] posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] jogadas =  new[] { 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n' };
            String[,] players = new String[2, 2] { {" ", "O"}, { "", "X" } };
            int jogadorAtual = 0;
            int vencedor = 0;

          

            CadastrarJogadores(players);

            while (vencedor == 0)
            {
                MostrarJogo(posicoes);
                jogadorAtual = Jogar(players, jogadorAtual, posicoes, jogadas,vencedor);
            }




        }
    }
}