using System;
using System.Collections;

//Tópicos 3 UNITINS
//Aluno: Gelmir Elias Baumgratz Filho

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo a Calculadora em C#\n" +
                "\nFeita por Gelmir Elias Baumgratz Filho\n" +
                "\n\nEscolha quantos números quiser, e logo depois você escolhe qual operação fazer com eles.");

            bool terminouDeUsar = false;
            while (!terminouDeUsar)
            {
                ArrayList listaNumeros = new ArrayList();

                // método para escolher o primeiro número.
                EscolherNumero(listaNumeros, "Escolha um número");

                // método para escolher o segundo número.
                EscolherNumero(listaNumeros, "Escolha mais um número");

                // método que possibilita escolher quantos números a mais quiser.
                EscolherMaisNumero(listaNumeros);

                ArrayList listaNumerosMemoria = new ArrayList();
                listaNumerosMemoria = listaNumeros;

                // método que exibe o menu de operações matemáticas.
                ExibirMenuECalcularOperacao(listaNumeros);

                bool terminouEscolher = false;
                while (!terminouEscolher)
                {
                    Console.WriteLine("Escolha a opção desejada\n");
                    Console.WriteLine("\t1 - Fazer outra conta");
                    Console.WriteLine("\t2 - Utilizar o resultado da operação anterior como um número da próxima operação");
                    Console.WriteLine("\t3 - Reutilizar os números de entrada, mas selecionar outra operação matemática");
                    Console.WriteLine("\t4 - Finalizar calculadora");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Calculadora pronta para utilizar novamente");
                            resultado = 0;
                            listaNumeros.Clear();

                            terminouEscolher = true;
                            break;

                        case "2":
                            Console.WriteLine("O resultado anterior foi: " + resultado.ToString("F") + " ele será usado como o primeiro número da nova operação");

                            // alocando o resultado da operação anterior como número da próxima operação
                            listaNumeros.Clear();
                            listaNumeros.Add(resultado);
                            resultado = 0;

                            EscolherNumero(listaNumeros, "Escolha mais um número");
                            EscolherMaisNumero(listaNumeros);

                            ExibirMenuECalcularOperacao(listaNumeros);
                            break;

                        case "3":
                            Console.WriteLine("Os números digitados na operação passadas vão ser reutilizados, são eles:");
                            foreach (decimal numero in listaNumerosMemoria)
                            {
                                Console.Write(numero + " ");
                            }
                            resultado = 0;

                            Console.WriteLine("\n");
                            ExibirMenuECalcularOperacao(listaNumerosMemoria);
                            break;

                        case "4":
                            Console.WriteLine("Obrigado por utilizar a calculadora, volte sempre que precisar");
                            terminouDeUsar = true;
                            terminouEscolher = true;
                            break;

                        default:
                            Console.WriteLine("Opção escolhida inválida, tente novamente");
                            break;
                    }
                }
            }
        }

        // váriaveis estáticas auxiliares
        private static bool terminou = false;
        private static decimal resultado = 0;
        private static string numeroTentativa;
        private static decimal numeroEscolhido;
        private static ArrayList listaAuxiliar = new ArrayList();

        private static ArrayList EscolherNumero(ArrayList listaNumeros, string texto)
        {
            terminou = false;
            while (!terminou)
            {
                Console.WriteLine("\n" + texto);
                numeroTentativa = Console.ReadLine();
                if (Decimal.TryParse(numeroTentativa, out numeroEscolhido))
                {
                    listaNumeros.Add(Convert.ToDecimal(numeroEscolhido));
                    terminou = true;
                }
                else
                {
                    Console.WriteLine("\nOpção escolhida não é um número válido");
                }
            }
            return listaNumeros;
        }

        private static ArrayList EscolherMaisNumero(ArrayList listaNumeros)
        {
            terminou = false;
            while (!terminou)
            {
                Console.WriteLine("\nDeseja escolher mais um número? S-Sim, N-Não");
                switch (Console.ReadLine())
                {
                    case "s":
                        Console.WriteLine("\nQual número?");
                        numeroTentativa = Console.ReadLine();
                        if (Decimal.TryParse(numeroTentativa, out numeroEscolhido))
                        {
                            listaNumeros.Add(Convert.ToDecimal(numeroEscolhido));
                        }
                        else
                        {
                            Console.WriteLine("\nOpção escolhida não é um número válido");
                        }
                        break;

                    case "n":
                        Console.WriteLine("\nTodos os números escolhidos com sucesso.");
                        Console.WriteLine("\nOs números escolhidos foram:");
                        foreach (decimal numero in listaNumeros)
                        {
                            Console.Write(numero + " ");
                        }
                        Console.WriteLine("\n");
                        terminou = true;
                        break;

                    default:
                        Console.WriteLine("\nOpção escolhida inválida, tente novamente");
                        break;
                }
            }
            return listaNumeros;
        }

        private static void ExibirMenuECalcularOperacao(ArrayList listaNumeros)
        {
            terminou = false;
            while (!terminou)
            {
                Console.WriteLine("Escolha a operação desejada\n");
                Console.WriteLine("\tA - Adição");
                Console.WriteLine("\tS - Subtração");
                Console.WriteLine("\tM - Multiplicação");
                Console.WriteLine("\tD - Divisão");

                switch (Console.ReadLine())
                {
                    case "a":
                        foreach (decimal numero in listaNumeros)
                        {
                            resultado += numero;
                        }
                        Console.WriteLine("O resultado da Adição dos números escolhidos é: " + resultado + "\n");
                        terminou = true;
                        break;

                    case "s":
                        resultado = (decimal)listaNumeros[0];

                        listaAuxiliar.Clear();
                        listaAuxiliar.AddRange(listaNumeros);

                        listaNumeros.RemoveAt(0);
                        foreach (decimal numero in listaNumeros)
                        {
                            resultado -= numero;
                        }
                        Console.WriteLine("O resultado da Subtração dos números escolhidos é: " + resultado + "\n");
                        terminou = true;

                        listaNumeros.Clear();
                        listaNumeros.AddRange(listaAuxiliar);
                        break;

                    case "m":
                        resultado = (decimal)listaNumeros[0];

                        listaAuxiliar.Clear();
                        listaAuxiliar.AddRange(listaNumeros);

                        listaNumeros.RemoveAt(0);
                        foreach (decimal numero in listaNumeros)
                        {
                            resultado *= numero;
                        }
                        Console.WriteLine("O resultado da Multiplicação dos números escolhidos é: " + resultado + "\n");
                        terminou = true;

                        listaNumeros.Clear();
                        listaNumeros.AddRange(listaAuxiliar);
                        break;

                    case "d":
                        resultado = (decimal)listaNumeros[0];
                        bool indefinido = false;
                        if (resultado == 0)
                        {
                            Console.WriteLine("O resultado da Divisão dos números escolhidos é: 0 \n");
                            terminou = true;
                            indefinido = true;
                            resultado = 0;
                            break;
                        }

                        listaAuxiliar.Clear();
                        listaAuxiliar.AddRange(listaNumeros);

                        listaNumeros.RemoveAt(0);
                        foreach (decimal numero in listaNumeros)
                        {
                            if (numero == 0)
                            {
                                Console.WriteLine("O resultado da Divisão é indefinido\n");
                                listaNumeros.Clear();
                                listaNumeros.AddRange(listaAuxiliar);
                                terminou = true;
                                indefinido = true;
                                resultado = 0;
                                break;
                            }
                            resultado /= numero;
                        }
                        if (!indefinido)
                        {
                            Console.WriteLine("O resultado da Divisão dos números escolhidos é: " + resultado.ToString("F") + "\n");
                            terminou = true;
                            listaNumeros.Clear();
                            listaNumeros.AddRange(listaAuxiliar);
                        }
                        break;

                    default:
                        Console.WriteLine("Opção escolhida inválida, tente novamente");
                        break;
                }
            }
        }
    }
}
