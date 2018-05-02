Ponto de Função
===============

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
