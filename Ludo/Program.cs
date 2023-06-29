using System;
namespace Ludo
{
    class program
    {
        public static bool JogadaNula(int[] jogador)
        {
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                if (jogador[i] == 0)
                {
                    x++;
                }
            }
            if (x == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Essa função faz com que o jogador só consiga realizar sua primeira jogada se tirar um 6 no dado
        public static bool PrimeiroMovimento(int[] jogador, int x)
        {
            if (jogador[x] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Semelhante à função anterior, mas essa funciona especificamente para primeiro movimento de cada peão do jogador, o impedindo de mover um
        //peão novo caso tire algo diferente de 6 no dado
        static bool Vitória(int[] jogador)
        {
            int[] condição = new int[4];
            condição[0] = 57;
            condição[1] = 57;
            condição[2] = 57;
            condição[3] = 57;
            if (jogador.SequenceEqual(condição))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Esta função determina o jogador vitorioso, fazendo uma comparãção entre o array do jogador ( com as posições de seus peões) e o array "condição",
        // tal que se os dois forem exatamente iguais, estaremos simulando um tabuleiro com 4 peças do jogador no final dele.
        static int Dado()
        {
            Random random = new Random();
            int rolagem = random.Next(1, 7);
            return rolagem;
        }
        //Função para rolar dados, saindo um número aleatório de 1 a 6.

        public static bool Exceder(int x, int y)
        {
            if (x + y > 57)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool JogadaIlegal(int[] jogador, int y)
        {
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                if (jogador[i] == 0)
                {
                    x++;
                }
            }
            if (x == 4 - y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(String[] args)
        {
            int jogadores;
            int[] r = { 0, 0, 0, 0 };
            int[] j1 = { 0, 0, 0, 0 };
            int[] j2 = { 0, 0, 0, 0 };
            int[] j3 = { 0, 0, 0, 0 };
            int[] j4 = { 0, 0, 0, 0 };
            int x, y, z;
            int rolagem = Dado();
            for (int i = 0; i <= 3; i++)
            {
                j1[i] = 0;
                j2[i] = 0;
                j3[i] = 0;
                j4[i] = 0;

            }
            //Para os 4 jogadores, criei um array de 4 espaços para cada, com cada espaço representando um peão e sua posição relativa no tabuleiro
            // (relativa ao seu ponto de origem)
            Console.Write("Bem vindo ao jogo de Ludo, escolha o número de jogadores(2 ou 4): ");
            jogadores = int.Parse(Console.ReadLine());
            while (jogadores != 2 && jogadores != 4)
            {
                Console.Write("Número de jogadores inválido, escolha de novo: ");
                jogadores = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Importante!!! Quando o programa solicitar para rolar o dado, basta apertar uma tecla qualquer");
            Console.WriteLine("");
            Console.WriteLine("Comecem o jogo, boa sorte!!");
            Console.WriteLine("");
            while (jogadores == 2)
            //Parte do Main dedicada à partida de 2 jogadores
            {
                while (jogadores == 2)
                {
                    Array.Clear(r, 0, r.Length);
                    Console.WriteLine("j1, role o dado");
                    rolagem = Dado();

                    //Vez do jogador 1 
                    while (rolagem != 0)
                    {
                        Console.ReadKey();
                        rolagem = Dado();
                        Console.WriteLine(rolagem);


                        if (rolagem == 6)
                        {
                            Console.WriteLine("Jogue o dado novamente");

                            Console.ReadKey();
                            rolagem = Dado();
                            Console.WriteLine(rolagem);
                            if (rolagem == 6)
                            {
                                Console.WriteLine("Jogue o dado novamente");
                                Console.ReadKey();
                                rolagem = Dado();
                                if (rolagem == 6)
                                {
                                    Console.WriteLine("Passa a vez");
                                    break;
                                }
                                else if (rolagem != 6)
                                {
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3");
                                    x = int.Parse(Console.ReadLine());
                                    y = int.Parse(Console.ReadLine());
                                    z = int.Parse(Console.ReadLine());
                                    r[x] = 6;
                                    j1[x] += r[x];
                                    r[y] = 6;
                                    j1[y] += r[y];
                                    while (PrimeiroMovimento(j1, z) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        z = int.Parse(Console.ReadLine());
                                    }
                                    r[z] = rolagem;
                                    j1[z] += r[z];
                                }
                            }
                            else if (rolagem != 6)
                            {
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                y = int.Parse(Console.ReadLine());
                                r[x] = 6;
                                j1[x] += r[x];
                                while (PrimeiroMovimento(j1, y) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    y = int.Parse(Console.ReadLine());
                                }
                                r[y] = rolagem;
                                j1[y] += r[y];
                            }

                        }

                        else if (rolagem != 6)
                        {
                            if (JogadaNula(j1) == true)
                            {
                                Console.WriteLine("Você não tem movimentos para fazer!!");
                                break;
                            }
                            Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                            x = int.Parse(Console.ReadLine());
                            while (PrimeiroMovimento(j1, x) == true)
                            {
                                Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                x = int.Parse(Console.ReadLine());
                            }
                            r[x] = rolagem;
                            j1[x] += r[x];

                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (j2[i] == j1[i] + 13)
                            {
                                if (j2[i] == 1 || j2[i] == 9 || j2[i] == 14 || j2[i] == 22 || j2[i] == 27 || j2[i] == 35 || j2[i] == 40 || j2[i] == 48 || j2[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j1[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j1, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j1[x] += r[x];
                                }

                            }
                           

                            
                            if (j1[i] == 51)
                            {
                                Console.WriteLine("Parabéns, um de seus peões acaba de chegar no ponto de origem, lance o dado mais uma vez.");
                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                while (PrimeiroMovimento(j1, x) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    x = int.Parse(Console.ReadLine());
                                }
                                r[x] = rolagem;
                                j1[x] += r[x];
                            }
                            if (j1[i] > 57)
                            {
                                Console.WriteLine("Você passou do limite final, boa sorte na próxima jogada");
                                j1[i] = 57 - (j1[i] - 57);
                                //Faz o jogador voltar casas caso ultrapasse a reta final
                            }

                            Console.WriteLine("Posição relativa do peão do j1: " + j1[i]);

                        }
                        break;
                    }
                    //Vez do jogador 2
                    Console.WriteLine("j2, role o dado");
                    while (rolagem != 0)
                    {
                        Console.ReadKey();
                        rolagem = Dado();
                        Console.WriteLine(rolagem);


                        if (rolagem == 6)
                        {
                            Console.WriteLine("Jogue o dado novamente");

                            Console.ReadKey();
                            rolagem = Dado();
                            Console.WriteLine(rolagem);
                            if (rolagem == 6)
                            {
                                Console.WriteLine("Jogue o dado novamente");

                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                if (rolagem == 6)
                                {
                                    Console.WriteLine("Passa a vez");
                                    break;
                                }
                                else if (rolagem != 6)
                                {
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    y = int.Parse(Console.ReadLine());
                                    z = int.Parse(Console.ReadLine());
                                    r[x] = 6;
                                    j2[x] += r[x];
                                    r[y] = 6;
                                    j2[y] += r[y];
                                    while (PrimeiroMovimento(j2, z) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        z = int.Parse(Console.ReadLine());
                                    }
                                    r[z] = rolagem;
                                    j2[z] += r[z];
                                }
                            }
                            else if (rolagem != 6)
                            {
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                y = int.Parse(Console.ReadLine());
                                r[x] += 6;
                                j2[x] += r[x];
                                while (PrimeiroMovimento(j2, y) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    y = int.Parse(Console.ReadLine());
                                }
                                r[y] = rolagem;
                                j2[y] += r[y];
                            }

                        }

                        else if (rolagem != 6)
                        {
                            if (JogadaNula(j2) == true)
                            {
                                Console.WriteLine("Você não tem movimentos para fazer!!");
                                break;
                            }
                            Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                            x = int.Parse(Console.ReadLine());
                            while (PrimeiroMovimento(j2, x) == true)
                            {
                                Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                x = int.Parse(Console.ReadLine());
                            }
                            r[x] = rolagem;
                            j2[x] += r[x];

                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (j2[i] == j1[i] + 13)
                            {
                                if (j1[i] == 1 || j1[i] == 9 || j1[i] == 14 || j1[i] == 22 || j1[i] == 27 || j1[i] == 35 || j1[i] == 40 || j1[i] == 48 || j1[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j1[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j2, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j2[x] += r[x];
                                }

                            }
                            
                            if (j2[i] == 51)
                            {
                                Console.WriteLine("Parabéns, um de seus peões acaba de chegar no ponto de origem, lance o dado mais uma vez.");
                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                while (PrimeiroMovimento(j2, x) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    x = int.Parse(Console.ReadLine());
                                }
                                r[x] = rolagem;
                                j2[x] += r[x];
                            }
                            if (j1[i] > 57)
                            {
                                Console.WriteLine("Você passou do limite final, boa sorte na próxima jogada");
                                j1[i] = 57 - (j1[i] - 57);
                            }

                            Console.WriteLine("Posição relativa do peão do j2: " + j2[i]);

                            }
                            break;


                        }

                        if (Vitória(j1) == true)
                        {
                            Console.WriteLine("Parabéns J1, você venceu a partida!!!");
                            break;
                        }
                        else if (Vitória(j2) == true)
                        {
                            Console.WriteLine("Parabéns J2, você venceu a partida!!!");
                            break;
                        }
                        //Fim do jogo para 2 jogadores
                    }
                

                }
                while (jogadores == 4)
                {
                    Array.Clear(r, 0, r.Length);
                    Console.WriteLine("j1, role o dado");
                    rolagem = Dado();

                    //Vez do jogador 1 
                    while (rolagem != 0)
                    {
                        Console.ReadKey();
                        rolagem = Dado();
                        Console.WriteLine(rolagem);


                        if (rolagem == 6)
                        {
                            Console.WriteLine("Jogue o dado novamente");

                            Console.ReadKey();
                            rolagem = Dado();
                            Console.WriteLine(rolagem);
                            if (rolagem == 6)
                            {
                                Console.WriteLine("Jogue o dado novamente");
                                Console.ReadKey();
                                rolagem = Dado();
                                if (rolagem == 6)
                                {
                                    Console.WriteLine("Passa a vez");
                                    break;
                                }
                                else if (rolagem != 6)
                                {
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3");
                                    x = int.Parse(Console.ReadLine());
                                    y = int.Parse(Console.ReadLine());
                                    z = int.Parse(Console.ReadLine());
                                    r[x] = 6;
                                    j1[x] += r[x];
                                    r[y] = 6;
                                    j1[y] += r[y];
                                    while (PrimeiroMovimento(j1, z) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        z = int.Parse(Console.ReadLine());
                                    }
                                    r[z] = rolagem;
                                    j1[z] += r[z];
                                }
                            }
                            else if (rolagem != 6)
                            {
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                y = int.Parse(Console.ReadLine());
                                r[x] = 6;
                                j1[x] += r[x];
                                while (PrimeiroMovimento(j1, y) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    y = int.Parse(Console.ReadLine());
                                }
                                r[y] = rolagem;
                                j1[y] += r[y];
                            }

                        }

                        else if (rolagem != 6)
                        {
                            if (JogadaNula(j1) == true)
                            {
                                Console.WriteLine("Você não tem movimentos para fazer!!");
                                break;
                            }
                            Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                            x = int.Parse(Console.ReadLine());
                            while (PrimeiroMovimento(j1, x) == true)
                            {
                                Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                x = int.Parse(Console.ReadLine());
                            }
                            r[x] = rolagem;
                            j1[x] += r[x];

                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (j2[i] == j1[i] + 13)
                            {
                                if (j2[i] == 1 || j2[i] == 9 || j2[i] == 14 || j2[i] == 22 || j2[i] == 27 || j2[i] == 35 || j2[i] == 40 || j2[i] == 48 || j2[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j1[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j1, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j1[x] += r[x];
                                }

                            }
                            if (j1[i] == j3[i] + 26)
                            {
                                if (j3[i] == 1 || j3[i] == 9 || j3[i] == 14 || j3[i] == 22 || j3[i] == 27 || j3[i] == 35 || j3[i] == 40 || j3[i] == 48 || j3[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j3[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j1, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j1[x] += r[x];
                                }

                            }
                            if (j1[i] == j4[i] + 39)
                            {
                                if (j4[i] == 1 || j4[i] == 9 || j4[i] == 14 || j4[i] == 22 || j4[i] == 27 || j4[i] == 35 || j4[i] == 40 || j4[i] == 48 || j4[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j4[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j1, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j1[x] += r[x];

                                }

                            }
                            if (j1[i] == 51)
                            {
                                Console.WriteLine("Parabéns, um de seus peões acaba de chegar no ponto de origem, lance o dado mais uma vez.");
                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                while (PrimeiroMovimento(j1, x) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    x = int.Parse(Console.ReadLine());
                                }
                                r[x] = rolagem;
                                j1[x] += r[x];
                            }
                            if (j1[i] > 57)
                            {
                                Console.WriteLine("Você passou do limite final, boa sorte na próxima jogada");
                                j1[i] = 57 - (j1[i] - 57);
                            }

                            Console.WriteLine("Posição relativa do peão do j1: " + j1[i]);

                        }
                        break;
                    }
                    //Vez do jogador 2
                    Console.WriteLine("j2, role o dado");
                    while (rolagem != 0)
                    {
                        Console.ReadKey();
                        rolagem = Dado();
                        Console.WriteLine(rolagem);


                        if (rolagem == 6)
                        {
                            Console.WriteLine("Jogue o dado novamente");

                            Console.ReadKey();
                            rolagem = Dado();
                            Console.WriteLine(rolagem);
                            if (rolagem == 6)
                            {
                                Console.WriteLine("Jogue o dado novamente");

                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                if (rolagem == 6)
                                {
                                    Console.WriteLine("Passa a vez");
                                    break;
                                }
                                else if (rolagem != 6)
                                {
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    y = int.Parse(Console.ReadLine());
                                    z = int.Parse(Console.ReadLine());
                                    r[x] = 6;
                                    j2[x] += r[x];
                                    r[y] = 6;
                                    j2[y] += r[y];
                                    while (PrimeiroMovimento(j2, z) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        z = int.Parse(Console.ReadLine());
                                    }
                                    r[z] = rolagem;
                                    j2[z] += r[z];
                                }
                            }
                            else if (rolagem != 6)
                            {
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                y = int.Parse(Console.ReadLine());
                                r[x] += 6;
                                j2[x] += r[x];
                                while (PrimeiroMovimento(j2, y) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    y = int.Parse(Console.ReadLine());
                                }
                                r[y] = rolagem;
                                j2[y] += r[y];
                            }

                        }

                        else if (rolagem != 6)
                        {
                            if (JogadaNula(j2) == true)
                            {
                                Console.WriteLine("Você não tem movimentos para fazer!!");
                                break;
                            }
                            Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                            x = int.Parse(Console.ReadLine());
                            while (PrimeiroMovimento(j2, x) == true)
                            {
                                Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                x = int.Parse(Console.ReadLine());
                            }
                            r[x] = rolagem;
                            j2[x] += r[x];

                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (j2[i] == j1[i] + 13)
                            {
                                if (j1[i] == 1 || j1[i] == 9 || j1[i] == 14 || j1[i] == 22 || j1[i] == 27 || j1[i] == 35 || j1[i] == 40 || j1[i] == 48 || j1[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j1[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j2, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j2[x] += r[x];
                                }

                            }
                            if (j2[i] == j3[i] + 13)
                            {
                                if (j3[i] == 1 || j3[i] == 9 || j3[i] == 14 || j3[i] == 22 || j3[i] == 27 || j3[i] == 35 || j3[i] == 40 || j3[i] == 48 || j3[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j3[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j2, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j2[x] += r[x];
                                }

                            }
                            if (j2[i] == j4[i] + 26)
                            {
                                if (j4[i] == 1 || j4[i] == 9 || j4[i] == 14 || j4[i] == 22 || j4[i] == 27 || j4[i] == 35 || j4[i] == 40 || j4[i] == 48 || j4[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j4[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j2, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j2[x] += r[x];

                                }

                            }
                            if (j2[i] == 51)
                            {
                                Console.WriteLine("Parabéns, um de seus peões acaba de chegar no ponto de origem, lance o dado mais uma vez.");
                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                while (PrimeiroMovimento(j2, x) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    x = int.Parse(Console.ReadLine());
                                }
                                r[x] = rolagem;
                                j2[x] += r[x];
                            }
                            if (j2[i] > 57)
                            {
                                Console.WriteLine("Você passou do limite final, boa sorte na próxima jogada");
                                j2[i] = 57 - (j2[i] - 57);
                            }

                            Console.WriteLine("Posição relativa do peão do j2: " + j2[i]);

                        }
                        break;


                    }
                    //Vez do jogador 3
                    Console.WriteLine("j3, role o dado");
                    while (rolagem != 0)
                    {
                        Console.ReadKey();
                        rolagem = Dado();
                        Console.WriteLine(rolagem);


                        if (rolagem == 6)
                        {
                            Console.WriteLine("Jogue o dado novamente");

                            Console.ReadKey();
                            rolagem = Dado();
                            Console.WriteLine(rolagem);
                            if (rolagem == 6)
                            {
                                Console.WriteLine("Jogue o dado novamente");

                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                if (rolagem == 6)
                                {
                                    Console.WriteLine("Passa a vez");
                                    break;
                                }
                                else if (rolagem != 6)
                                {
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    y = int.Parse(Console.ReadLine());
                                    z = int.Parse(Console.ReadLine());
                                    r[x] = 6;
                                    j3[x] += r[x];
                                    r[y] = 6;
                                    j3[y] += r[y];
                                    while (PrimeiroMovimento(j3, z) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        z = int.Parse(Console.ReadLine());
                                    }
                                    r[z] = rolagem;
                                    j3[z] += r[z];
                                }
                            }
                            else if (rolagem != 6)
                            {
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                y = int.Parse(Console.ReadLine());
                                r[x] += 6;
                                j3[x] += r[x];
                                while (PrimeiroMovimento(j3, y) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    y = int.Parse(Console.ReadLine());
                                }
                                r[y] = rolagem;
                                j3[y] += r[y];
                            }

                        }

                        else if (rolagem != 6)
                        {
                            if (JogadaNula(j3) == true)
                            {
                                Console.WriteLine("Você não tem movimentos para fazer!!");
                                break;
                            }
                            Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                            x = int.Parse(Console.ReadLine());
                            while (PrimeiroMovimento(j2, x) == true)
                            {
                                Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                x = int.Parse(Console.ReadLine());
                            }
                            r[x] = rolagem;
                            j3[x] += r[x];

                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (j3[i] == j1[i] + 26)
                            {
                                if (j1[i] == 1 || j1[i] == 9 || j1[i] == 14 || j1[i] == 22 || j1[i] == 27 || j1[i] == 35 || j1[i] == 40 || j1[i] == 48 || j1[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j1[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j3, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j3[x] += r[x];
                                }

                            }
                            if (j4[i] == j3[i] + 13)
                            {
                                if (j4[i] == 1 || j4[i] == 9 || j4[i] == 14 || j4[i] == 22 || j4[i] == 27 || j4[i] == 35 || j4[i] == 40 || j4[i] == 48 || j4[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j4[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j3, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j3[x] += r[x];
                                }

                            }
                            if (j2[i] == j3[i] + 13)
                            {
                                if (j2[i] == 1 || j2[i] == 9 || j2[i] == 14 || j2[i] == 22 || j2[i] == 27 || j2[i] == 35 || j2[i] == 40 || j2[i] == 48 || j2[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j2[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j3, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j3[x] += r[x];

                                }

                            }
                            if (j3[i] == 51)
                            {
                                Console.WriteLine("Parabéns, um de seus peões acaba de chegar no ponto de origem, lance o dado mais uma vez.");
                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                while (PrimeiroMovimento(j3, x) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    x = int.Parse(Console.ReadLine());
                                }
                                r[x] = rolagem;
                                j3[x] += r[x];
                            }
                            if (j3[i] > 57)
                            {
                                Console.WriteLine("Você passou do limite final, boa sorte na próxima jogada");
                                j3[i] = 57 - (j3[i] - 57);
                            }

                            Console.WriteLine("Posição relativa do peão do j3: " + j3[i]);

                        }
                        break;


                    }
                    //vez do Jogador 4
                    Console.WriteLine("j4, role o dado");
                    while (rolagem != 0)
                    {
                        Console.ReadKey();
                        rolagem = Dado();
                        Console.WriteLine(rolagem);


                        if (rolagem == 6)
                        {
                            Console.WriteLine("Jogue o dado novamente");

                            Console.ReadKey();
                            rolagem = Dado();
                            Console.WriteLine(rolagem);
                            if (rolagem == 6)
                            {
                                Console.WriteLine("Jogue o dado novamente");

                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                if (rolagem == 6)
                                {
                                    Console.WriteLine("Passa a vez");
                                    break;
                                }
                                else if (rolagem != 6)
                                {
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    y = int.Parse(Console.ReadLine());
                                    z = int.Parse(Console.ReadLine());
                                    r[x] = 6;
                                    j4[x] += r[x];
                                    r[y] = 6;
                                    j4[y] += r[y];
                                    while (PrimeiroMovimento(j4, z) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        z = int.Parse(Console.ReadLine());
                                    }
                                    r[z] = rolagem;
                                    j4[z] += r[z];
                                }
                            }
                            else if (rolagem != 6)
                            {
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                y = int.Parse(Console.ReadLine());
                                r[x] += 6;
                                j4[x] += r[x];
                                while (PrimeiroMovimento(j4, y) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    y = int.Parse(Console.ReadLine());
                                }
                                r[y] = rolagem;
                                j4[y] += r[y];
                            }

                        }

                        else if (rolagem != 6)
                        {
                            if (JogadaNula(j4) == true)
                            {
                                Console.WriteLine("Você não tem movimentos para fazer!!");
                                break;
                            }
                            Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                            x = int.Parse(Console.ReadLine());
                            while (PrimeiroMovimento(j4, x) == true)
                            {
                                Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                x = int.Parse(Console.ReadLine());
                            }
                            r[x] = rolagem;
                            j4[x] += r[x];

                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (j4[i] == j1[i] + 39)
                            {
                                if (j1[i] == 1 || j1[i] == 9 || j1[i] == 14 || j1[i] == 22 || j1[i] == 27 || j1[i] == 35 || j1[i] == 40 || j1[i] == 48 || j1[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j1[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j4, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j4[x] += r[x];
                                }

                            }
                            if (j2[i] == j4[i] + 26)
                            {
                                if (j2[i] == 1 || j2[i] == 9 || j2[i] == 14 || j2[i] == 22 || j2[i] == 27 || j2[i] == 35 || j2[i] == 40 || j2[i] == 48 || j2[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j2[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j4, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j4[x] += r[x];
                                }

                            }
                            if (j3[i] == j4[i] + 13)
                            {
                                if (j3[i] == 1 || j3[i] == 9 || j3[i] == 14 || j3[i] == 22 || j3[i] == 27 || j3[i] == 35 || j3[i] == 40 || j3[i] == 48 || j3[i] > 51)
                                {
                                    Console.WriteLine("O peão adversário está numa casa segura!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você capturou um peão adversário, faça uma nova jogada");
                                    j3[i] = 0;
                                    Console.ReadKey();
                                    rolagem = Dado();
                                    Console.WriteLine(rolagem);
                                    Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                    x = int.Parse(Console.ReadLine());
                                    while (PrimeiroMovimento(j4, x) == true)
                                    {
                                        Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                        x = int.Parse(Console.ReadLine());
                                    }
                                    r[x] = rolagem;
                                    j4[x] += r[x];
                                }

                            }
                            if (j4[i] == 51)
                            {
                                Console.WriteLine("Parabéns, um de seus peões acaba de chegar no ponto de origem, lance o dado mais uma vez.");
                                Console.ReadKey();
                                rolagem = Dado();
                                Console.WriteLine(rolagem);
                                Console.WriteLine("Escolha o peão que deseja mover(0,1,2 ou 3)");
                                x = int.Parse(Console.ReadLine());
                                while (PrimeiroMovimento(j4, x) == true)
                                {
                                    Console.WriteLine("Peão se encontra na casa 0, escolha outro peão para mover");
                                    x = int.Parse(Console.ReadLine());
                                }
                                r[x] = rolagem;
                                j4[x] += r[x];
                            }
                            if (j4[i] > 57)
                            {
                                Console.WriteLine("Você passou do limite final, boa sorte na próxima jogada");
                                j4[i] = 57 - (j4[i] - 57);
                            }

                            Console.WriteLine("Posição relativa do peão do j4: " + j4[i]);

                        }
                        break;


                    }

                    if (Vitória(j1) == true)
                    {
                        Console.WriteLine("Parabéns J1, você venceu a partida!!!");
                        break;
                    }
                    else if (Vitória(j2) == true)
                    {
                        Console.WriteLine("Parabéns J2, você venceu a partida!!!");
                        break;
                    }
                    else if (Vitória(j3) == true)
                    {
                        Console.WriteLine("Parabéns J3, você venceu a partida!!!");
                        break;
                    }
                    else if (Vitória(j4) == true)
                    {
                        Console.WriteLine("Parabéns J4, você venceu a partida!!!");
                        break;
                    }
                    //Fim do jogo para 4 jogadores

                }
            
        }
    }
}