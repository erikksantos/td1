# Projeto: Problema de Soma de Pares

## Descrição do Problema

O **Problema de Somas de Pares** consiste em encontrar, dentro de um conjunto de números, dois números cuja soma resulte em um determinado valor.

### Aplicabilidade Prática
Esse problema é aplicável em diversas áreas, como segurança (verificação de pares de dados seguros), finanças (identificação de transações que somam um valor específico) e desenvolvimento de software (resolução de problemas complexos com dados).

## Algoritmos Implementados

1. **Força Bruta**: O algoritmo testa todas as combinações possíveis de dois números dentro do conjunto para ver se a soma deles é igual ao valor alvo.
   
2. **Divisão e Conquista**: O algoritmo divide o problema em subproblemas menores, resolve os subproblemas e combina os resultados obtidos.
   
3. **Programação Dinâmica**: O algoritmo é construído a partir de soluções parciais armazenadas, evitando recomputações e tornando o processo mais eficiente.

4. **Algoritmo Guloso**: O algoritmo toma a melhor decisão em cada etapa, de forma local, na esperança de que essa escolha leve à solução global ótima.


## Comparação de Desempenho

| Algoritmo               | Descrição                                                         | Tempo de Execução (ms)| Eficiência |Memória Usada (MB) | Observações |
|-------------------------|-------------------------------------------------------------------|-----------------------|------------|-------------------|-------------|
| **Força Bruta**          | Testa todas as combinações possíveis até encontrar a solução ótima | 10 segundos         |            |                   |             |
| **Divisão e Conquista**  | Divide o problema em subproblemas menores e resolve-os recursivamente | 5 segundos       |            |                   |             |
| **Programação Dinâmica** | Armazena soluções parciais para evitar recomputação               | 2 segundos           |            |                   |             |
| **Algoritmo Guloso**     | Armazena soluções parciais para evitar recomputação               | 2 segundos           |            |                   |             |
