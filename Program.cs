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
            Console.WriteLine($"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n");

        }

        static void CadastrarJogadores(String[,] players) {
            Console.WriteLine("-------- Jogo da Velha --------- ");
            Console.Write("Informe o nome do jogador 1: ");
            players[0,0] = Console.ReadLine();
            Console.Write("Informe o nome do jogador 2: ");
            players[1,0] = Console.ReadLine();     
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine($"Jogadores cadastrados:\n{players[0,0]} = {players[0, 1]}\n{players[1,0]} = {players[1, 1]}");
            Console.WriteLine("Pressione enter para continuar!");
            Console.ReadLine();


        }

        static void Jogar(String[,] players, int jogadorAtual,char[] posicoes,char[] jogadas, int vencedor) {
            int posicao;
            
            do
            {
                Console.Write($"{players[jogadorAtual,0]} esolha a posição para jogar:");                
                posicao = int.Parse(Console.ReadLine()) -1;
              
                //Verifica se a posição esta livre
                if (jogadas[posicao] == 'n')
                {
                    //adiciona o desenho no vetor de acordo com o jogador
                    posicoes[posicao] = char.Parse(players[jogadorAtual, 1]);
                    jogadas[posicao] = 's';
                    
                }
                else {
                    Console.Write("Essa posição ja foi ocupada, tecle enter para continuar");
                    Console.ReadLine();
                }
            } while (jogadas[posicao] == 'n');

        }

        static int MudarJogador(int jogadorAtual) {
            if (jogadorAtual == 0)
            {
                jogadorAtual = 1;
            }
            else
            {
                jogadorAtual = 0;
            }

            return jogadorAtual;
        }

        static int InformarVencedor(char marca, String[,] players, char[] posicoes) {
            
            MostrarJogo(posicoes);
            Console.WriteLine("\n------------------");
            Console.WriteLine("Jogo Encerrado");

            if (marca == 'O')
            {
                Console.WriteLine($"Vencedor: {players[0, 0]} = {players[0, 1]}");
            }
            else
            {
                Console.WriteLine($"Vencedor: {players[1, 0]} = {players[1, 1]}");
            }
            return 1;

        }

        static int VerificarJogo(char[] posicoes, char[] jogadas, String[,] players, int vencedor)
        {
            vencedor = 2;
            foreach (char marca in jogadas) {
                if (marca == 'n') {
                    vencedor = 0;
                }
            }
            if (vencedor == 0 )
            {

                for (int i = 0; i <= 7; i += 3)
                {
                    if (posicoes[i] == posicoes[i + 1] && posicoes[i] == posicoes[i + 2])
                    {
                        vencedor = InformarVencedor(posicoes[i], players, posicoes);
                        break;
                    }
                }

                for (int i = 0; i <= 2; i += 1)
                {
                    if (posicoes[i] == posicoes[i + 3] && posicoes[i] == posicoes[i + 6])
                    {
                        vencedor = InformarVencedor(posicoes[i], players, posicoes);
                        break;
                    }
                }

                if (posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8] || posicoes[2] == posicoes[4] && posicoes[0] == posicoes[6])
                {
                    vencedor = InformarVencedor(posicoes[0], players, posicoes);
                }               
            }

            if (vencedor == 2)
            {
                MostrarJogo(posicoes);
                Console.WriteLine("Jogo terminou empatado!");
               
            }

            if (vencedor != 0)
            {
                Console.WriteLine("Digite (s) para novo jo ou (n) para encerrar!");
                String retorno = Console.ReadLine();

                if (retorno == "s")
                {
                    vencedor = 2;
                }
            }
            return vencedor;
            
        }


        public static void Main(string[] args)

        {
            int vencedor = 0;
            do
            {
                
                
                char[] posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                char[] jogadas = new[] { 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n' };
                String[,] players = new String[2, 2] { { " ", "O" }, { "", "X" } };
                int jogadorAtual = 0;

                if (vencedor == 0)
                {
                    CadastrarJogadores(players);
                }
                else if (vencedor == 2) {
                    Console.Clear();
                    Console.WriteLine("Deseja cadastrar novos jogadores ou continuar com os mesmo?");
                    Console.Write("Diginte (s) para novo cadastro ou (n) para continuar: ");
                    string resposta = Console.ReadLine();
                    if (resposta == "s") {
                        CadastrarJogadores(players);
                    }
                }

                vencedor = 0;
                while (vencedor == 0)
                {
                    MostrarJogo(posicoes);
                    Jogar(players, jogadorAtual, posicoes, jogadas, vencedor);
                    jogadorAtual = MudarJogador(jogadorAtual);
                    vencedor = VerificarJogo(posicoes, jogadas, players, vencedor);

                }
            } while (vencedor == 2);




        }
    }
}