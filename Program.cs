using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace AlgoritmosDeDecisao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar instâncias do problema de Soma de Pares
            var instancias = new List<List<int>>
            {
                CriaInstancia(10),
                CriaInstancia(100),
                CriaInstancia(1000)
            };

            int valor = 10;

            foreach (var instancia in instancias)
            {
                Console.WriteLine($"Testando instância com tamanho: {instancia.Count}");

                // Testes de tempo e memória
                TesteAlgoritmo("Forhhça Bruta", () => ForcaBruta.Execucao(instancia, valor));
                TesteAlgoritmo("Divisão e Conquista", () => DivisaoConquista.Execucao(instancia, valor));
                TesteAlgoritmo("Programação Dinâmica", () => ProgramacaoDinamica.Execucao(instancia, valor));
                TesteAlgoritmo("Algoritmo Guloso", () => AlgoritmoGuloso.Execucao(instancia, valor));

                Console.WriteLine();
            }
        }

        // Função que cria uma instância do problema de Soma de Pares
        private static List<int> CriaInstancia(int tamanho)
        {
            var numeros = new List<int>();
            var random = new Random();

            for (int i = 0; i < tamanho; i++)
            {
                numeros.Add(random.Next(1, 101));
            }

            return numeros;
        }

        // Função que testa um algoritmo e mede o tempo de execução e consumo de memória
        private static void TesteAlgoritmo(string nome, Action algoritmo)
        {
            Console.WriteLine($"Teste do algoritmo: {nome}");

            // Medindo tempo de execução
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Medindo memória
            var startMemory = GC.GetTotalMemory(true);

            algoritmo(); // Executa o algoritmo

            var endMemory = GC.GetTotalMemory(true);

            stopwatch.Stop();

            var tempoExecucao = stopwatch.ElapsedMilliseconds;
            var consumoMemoria = (endMemory - startMemory) / 1024; // Memória em KB

            // Exibe os resultados
            Console.WriteLine($"Tempo de execução: {tempoExecucao}ms");
            Console.WriteLine($"Memória consumida: {consumoMemoria} KB");
            Console.WriteLine();
        }
    }

    // Algoritmos para o problema de Soma de Pares
    public static class DivisaoConquista
    {
        public static void Execucao(List<int> numeros, int valor)
        {
            var resultado = ResolverSomaParesDivisaoConquista(numeros, valor, 0, numeros.Count - 1);
            Console.WriteLine($"Pares encontrados (Divisão e Conquista): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesDivisaoConquista(List<int> numeros, int valor, int inicio, int fim)
        {
            var pares = new List<(int, int)>();

            if (inicio >= fim)
                return pares;

            int meio = (inicio + fim) / 2;
            var paresEsquerda = ResolverSomaParesDivisaoConquista(numeros, valor, inicio, meio);
            var paresDireita = ResolverSomaParesDivisaoConquista(numeros, valor, meio + 1, fim);

            pares.AddRange(paresEsquerda);
            pares.AddRange(paresDireita);

            for (int i = inicio; i <= meio; i++)
            {
                for (int j = meio + 1; j <= fim; j++)
                {
                    if (numeros[i] + numeros[j] == valor)
                    {
                        pares.Add((numeros[i], numeros[j]));
                    }
                }
            }

            return pares;
        }
    }

    public static class ForcaBruta
    {
        public static void Execucao(List<int> numeros, int valor)
        {
            var resultado = ResolverSomaParesForcaBruta(numeros, valor);
            Console.WriteLine($"Pares encontrados (Força Bruta): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesForcaBruta(List<int> numeros, int valor)
        {
            var pares = new List<(int, int)>();

            for (int i = 0; i < numeros.Count; i++)
            {
                for (int j = i + 1; j < numeros.Count; j++)
                {
                    if (numeros[i] + numeros[j] == valor)
                    {
                        pares.Add((numeros[i], numeros[j]));
                    }
                }
            }

            return pares;
        }
    }

    public static class AlgoritmoGuloso
    {
        public static void Execucao(List<int> numeros, int valor)
        {
            var resultado = ResolverSomaParesGuloso(numeros, valor);
            Console.WriteLine($"Pares encontrados (Algoritmo Guloso): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesGuloso(List<int> numeros, int valor)
        {
            var pares = new List<(int, int)>();
            numeros.Sort();

            int esquerda = 0;
            int direita = numeros.Count - 1;

            while (esquerda < direita)
            {
                int soma = numeros[esquerda] + numeros[direita];

                if (soma == valor)
                {
                    pares.Add((numeros[esquerda], numeros[direita]));
                    esquerda++;
                    direita--;
                }
                else if (soma < valor)
                {
                    esquerda++;
                }
                else
                {
                    direita--;
                }
            }

            return pares;
        }
    }

    public static class ProgramacaoDinamica
    {
        public static void Execucao(List<int> numeros, int valor)
        {
            var resultado = ResolverSomaParesProgramacaoDinamica(numeros, valor);
            Console.WriteLine($"Pares encontrados (Programação Dinâmica): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesProgramacaoDinamica(List<int> numeros, int valor)
        {
            var pares = new List<(int, int)>();
            var hashset = new HashSet<int>();

            foreach (var num in numeros)
            {
                int complemento = valor - num;
                if (hashset.Contains(complemento))
                {
                    pares.Add((num, complemento));
                }
                hashset.Add(num);
            }

            return pares;
        }
    }
}
