using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace AlgoritmosDeDecisao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar instância do problema de Soma de Pares
            var instancia = CriarInstancia();

            // Submeter aos algoritmos e medir o tempo e memória
            TestarAlgoritmo("Força Bruta", () => ForcaBruta.Executar(instancia));
            TestarAlgoritmo("Divisão e Conquista", () => DivisaoConquista.Executar(instancia));
            TestarAlgoritmo("Programação Dinâmica", () => ProgramacaoDinamica.Executar(instancia));
            TestarAlgoritmo("Algoritmo Guloso", () => AlgoritmoGuloso.Executar(instancia));
        }

        // Método que cria uma instância do problema de Soma de Pares
        private static List<int> CriarInstancia()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6 };
        }

        // Método que testa um algoritmo e mede o tempo de execução e consumo de memória
        private static void TestarAlgoritmo(string nomeAlgoritmo, Action algoritmo)
        {
            Console.WriteLine($"Testando algoritmo: {nomeAlgoritmo}");

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
    public static class ForcaBruta
    {
        public static void Executar(List<int> numeros)
        {
            int alvo = 10;
            var resultado = ResolverSomaParesForcaBruta(numeros, alvo);
            Console.WriteLine($"Pares encontrados (Força Bruta): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesForcaBruta(List<int> numeros, int alvo)
        {
            var pares = new List<(int, int)>();

            for (int i = 0; i < numeros.Count; i++)
            {
                for (int j = i + 1; j < numeros.Count; j++)
                {
                    if (numeros[i] + numeros[j] == alvo)
                    {
                        pares.Add((numeros[i], numeros[j]));
                    }
                }
            }

            return pares;
        }
    }

    public static class DivisaoConquista
    {
        public static void Executar(List<int> numeros)
        {
            int alvo = 10;
            var resultado = ResolverSomaParesDivisaoConquista(numeros, alvo, 0, numeros.Count - 1);
            Console.WriteLine($"Pares encontrados (Divisão e Conquista): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesDivisaoConquista(List<int> numeros, int alvo, int inicio, int fim)
        {
            var pares = new List<(int, int)>();

            if (inicio >= fim)
                return pares;

            int meio = (inicio + fim) / 2;
            var paresEsquerda = ResolverSomaParesDivisaoConquista(numeros, alvo, inicio, meio);
            var paresDireita = ResolverSomaParesDivisaoConquista(numeros, alvo, meio + 1, fim);

            pares.AddRange(paresEsquerda);
            pares.AddRange(paresDireita);

            for (int i = inicio; i <= meio; i++)
            {
                for (int j = meio + 1; j <= fim; j++)
                {
                    if (numeros[i] + numeros[j] == alvo)
                    {
                        pares.Add((numeros[i], numeros[j]));
                    }
                }
            }

            return pares;
        }
    }

    public static class ProgramacaoDinamica
    {
        public static void Executar(List<int> numeros)
        {
            int alvo = 10;
            var resultado = ResolverSomaParesProgramacaoDinamica(numeros, alvo);
            Console.WriteLine($"Pares encontrados (Programação Dinâmica): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesProgramacaoDinamica(List<int> numeros, int alvo)
        {
            var pares = new List<(int, int)>();
            var hashset = new HashSet<int>();

            foreach (var num in numeros)
            {
                int complemento = alvo - num;
                if (hashset.Contains(complemento))
                {
                    pares.Add((num, complemento));
                }
                hashset.Add(num);
            }

            return pares;
        }
    }

    public static class AlgoritmoGuloso
    {
        public static void Executar(List<int> numeros)
        {
            int alvo = 10;
            var resultado = ResolverSomaParesGuloso(numeros, alvo);
            Console.WriteLine($"Pares encontrados (Algoritmo Guloso): {string.Join(", ", resultado)}");
        }

        private static List<(int, int)> ResolverSomaParesGuloso(List<int> numeros, int alvo)
        {
            var pares = new List<(int, int)>();
            numeros.Sort();

            int esquerda = 0;
            int direita = numeros.Count - 1;

            while (esquerda < direita)
            {
                int soma = numeros[esquerda] + numeros[direita];

                if (soma == alvo)
                {
                    pares.Add((numeros[esquerda], numeros[direita]));
                    esquerda++;
                    direita--;
                }
                else if (soma < alvo)
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
}

