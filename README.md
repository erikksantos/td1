# Projeto: Problema de Soma de Pares

## Descrição do Problema

O **Problema de Somas de Pares** consiste em encontrar, dentro de um conjunto de números, dois números cuja soma resulte em um determinado valor.

### Aplicabilidade Prática
Esse problema é aplicável em diversas áreas, como segurança (verificação de pares de dados seguros), finanças (identificação de transações que somam um valor específico) e desenvolvimento de software (resolução de problemas complexos com dados).

## Algoritmos Implementados

1. **Força Bruta**: O algoritmo testa todas as combinações possíveis de dois números dentro do conjunto para ver se a soma deles é igual ao valor procurado.
   
2. **Divisão e Conquista**: O algoritmo divide o problema em subproblemas menores, resolve os subproblemas e combina os resultados obtidos.
   
3. **Programação Dinâmica**: O algoritmo é construído a partir de soluções parciais armazenadas, evitando recomputações e tornando o processo mais eficiente.

4. **Algoritmo Guloso**: O algoritmo toma a melhor decisão em cada etapa, de forma local, na esperança de que essa escolha leve à solução global ótima.


## Comparação de Desempenho

| Algoritmo                | Tamanho do Conjunto       | Tempo de Execução (ms)| Eficiência |Memória Usada (KB) | Observações |
|--------------------------|---------------------------|-----------------------|------------|-------------------|-------------|
| **Força Bruta**          | 10                        | 10 segundos           |            |                   |             |
|                          | 100                       | 10 segundos           |            |                   |             |
|                          | 1000                      | 10 segundos           |            |                   |             |
| **Divisão e Conquista**  | 10                        | 5 segundos            |            |                   |             |
|                          | 100                       | 5 segundos            |            |                   |             |
|                          | 1000                      | 5 segundos            |            |                   |             |
| **Programação Dinâmica** | 10                        | 2 segundos            |            |                   |             |
|                          | 100                       | 2 segundos            |            |                   |             |
|                          | 1000                      | 2 segundos            |            |                   |             |
| **Algoritmo Guloso**     | 10                        | 2 segundos            |            |                   |             |
|                          | 100                       | 2 segundos            |            |                   |             |
|                          | 1000                      | 2 segundos            |            |                   |             |
