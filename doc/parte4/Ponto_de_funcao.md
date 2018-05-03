Ponto de Função
===============

A métrica de Pontos de Função foi criada por Allan Albrecht em 1979, ela consiste em definir uma quantidade de Pontos de Função para cada tipo de funcionalidade.

O IFPUG *(International Function Point Users Group)*, é responsável pela atualização das regras de Contagem de Pontos de Função, descritas no CPM *(Counting Practices Manual)*. Para se contar os pontos de função é necessário seguir alguns passos:

- Definir o tipo de contagem;
    - Contagem de projeto de desenvolvimento;
    - Contagem de projeto de melhoria (manutenção);
    - Contagem de aplicação.
- Identificação do escopo da contagem;
- Contagem dos pontos de função não ajustado
    - Contagem das funções de dados;
    - Contagem das funções de transação.
- Cálculo do fator de reajuste
- Calcular o número de pontos de função ajustados

Ao término da contagem, essa métrica nos dá uma noção do tamanho funcional do software, que será usado para o cálculo de tempo de desenvolvimento e custo associado.

Tipos de função
---------------

### Pontos de função de dados

- **Arquivos Lógicos Internos (ALI):**
- **Arquivos de Interface Externa(AIE):**

### Pontos de função de Transação

- **Entradas Externas (EE):**
- **Saídas Externas (SE):**
- **Consultas Externas (CE):**

Valores de ponto de função
--------------------------

|     | Simples | Média | Alta |
|----:|:-------:|:-----:|:----:|
| ALI |    7    |   10  |  15  |
| AIE |    5    |   7   |  10  |
|  EE |    3    |   4   |   6  |
|  SE |    4    |   5   |   7  |
|  CE |    3    |   4   |   6  |

Definição de complexidade
-------------------------

### ALI e AIE

|          | 1~19 DERs | 20~50 DERs | 51+ DERs |
|---------:|:---------:|:----------:|:--------:|
|   1 RLRs |   Baixa   |    Baixa   |   Média  |
| 2~5 RLRs |   Baixa   |    Média   |   Alta   |
|  6+ RLRs |   Média   |    Alta    |   Alta   |

### EE

|          | 1~4 DERs | 5~15 DERs | 16+ DERs |
|---------:|:--------:|:---------:|:--------:|
| 0~1 RLRs |   Baixa  |   Baixa   |   Média  |
|   2 RLRs |   Baixa  |   Média   |   Alta   |
|  3+ RLRs |   Média  |    Alta   |   Alta   |

### SE e CE

|          | 1~5 DERs | 6~19 DERs | 20+ DERs |
|---------:|:--------:|:---------:|:--------:|
| 0~1 RLRs |   Baixa  |   Baixa   |   Média  |
| 2~3 RLRs |   Baixa  |   Média   |   Alta   |
|  4+ RLRs |   Média  |    Alta   |   Alta   |

Fator de reajuste
-----------------

- Comunicação de dados
- Processamento distribuído
- Performance
- Configuração do equipamento
- Volume de transações
- Entrada de dados on-line
- Interface com o usuário
- Atualização on-line
- Processamento complexo
- Reusabilidade
- Facilidade de implantação
- Facilidade operacional
- Múltiplos locais
- Facilidade de mudanças (Flexibilidade)

Referências
-----------

https://www.devmedia.com.br/contagem-de-pontos-de-funcao/34390  
https://en.wikipedia.org/wiki/Use_Case_Points
http://fattocs.com/files/pt/livro-apf/citacao/JhoneySLopes-JoseLBraga-2011.pdf
