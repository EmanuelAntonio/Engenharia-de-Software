Ponto de Função
===============

A métrica de Pontos de Função foi criada por Allan Albrecht em 1979, ela consiste em definir uma quantidade de pontos de função para cada tipo de funcionalidade.

O IFPUG *(International Function Point Users Group)*, é responsável pela atualização das regras de Contagem de Pontos de Função, descritas no CPM *(Counting Practices Manual)*. Para se contar os pontos de função é necessário seguir alguns passos:

- Definir o tipo de contagem
    - Contagem de projeto de desenvolvimento;
    - Contagem de projeto de melhoria (manutenção);
    - Contagem de aplicação.
- Identificação do escopo da contagem;
- Contagem dos pontos de função não ajustado
    - Contagem das funções de dados;
    - Contagem das funções de transação.
- Cálculo do fator de ajuste;
- Calcular o número de pontos de função ajustados.

Ao término da contagem, essa métrica nos dá uma noção do tamanho funcional do software, que será usado para o cálculo de tempo de desenvolvimento e custo associado.


Tipos de função
---------------

### Funções de dados

- **Arquivos Lógicos Internos (ALI):** Grupo lógico de dados e persistentes mantidos dentro da fronteira da aplicação e alterado por meio de processos elementares;
- **Arquivos de Interface Externa (AIE):** Grupo lógico de dados e persistentes mantidos dentro da fronteira de outra aplicação, mas requerido ou referenciado pela aplicação que está sendo contada.

### Funções de transação

- **Entradas Externas (EE):** Processo de controle que realiza o processamento de dados do sistema e direciona o mesmo para atender os requisitos da aplicação;
- **Saídas Externas (SE):** Processo elementar destinado a apresentação de informação ao usuário ou a outra aplicação externa que utiliza de cálculos para processar essas informações;
- **Consultas Externas (CE):** Processo elementar que apresenta informação ao usuário ou a outra aplicação externa por meio de recuperação simples.


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

A complexidade das ALIs e AIEs é determinada a partir da contagem dos DERs *(Dado elementar referenciado)* e dos RLRs *(Registro lógico refenciado)*

A complexidade das EEs, SEs e CEs é determinada a partir de contagem dos ALR *(Arquivo lógico referenciado)* e dos DERs

### ALI e AIE

|          | 1~19 DERs | 20~50 DERs | 51+ DERs |
|---------:|:---------:|:----------:|:--------:|
|   1 RLRs |   Baixa   |    Baixa   |   Média  |
| 2~5 RLRs |   Baixa   |    Média   |   Alta   |
|  6+ RLRs |   Média   |    Alta    |   Alta   |

### EE

|          | 1~4 DERs | 5~15 DERs | 16+ DERs |
|---------:|:--------:|:---------:|:--------:|
| 0~1 ALRs |   Baixa  |   Baixa   |   Média  |
|   2 ALRs |   Baixa  |   Média   |   Alta   |
|  3+ ALRs |   Média  |    Alta   |   Alta   |

### SE e CE

|          | 1~5 DERs | 6~19 DERs | 20+ DERs |
|---------:|:--------:|:---------:|:--------:|
| 0~1 ALRs |   Baixa  |   Baixa   |   Média  |
| 2~3 ALRs |   Baixa  |   Média   |   Alta   |
|  4+ ALRs |   Média  |    Alta   |   Alta   |


Fator de ajuste
-----------------

Para o cálculo do fator de asjuste é atribuido um valor de 0 a 5 para cada um do itens abaixo:

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

Com base na soma de todos os valores é calculado o valor do fator de ajuste que pode variar entre -35% a +35%. Esse fator é então multiplicado pelos pontos de função para ajustá-los.


Referências
-----------

https://www.devmedia.com.br/contagem-de-pontos-de-funcao/34390  
https://en.wikipedia.org/wiki/Use_Case_Points  
http://fattocs.com/files/pt/livro-apf/citacao/JhoneySLopes-JoseLBraga-2011.pdf  
http://www.inf.furb.br/~egrahl/disciplinas/qualidade/material/GerenciaPrazo/Aulas%20Passadas/fpa.pdf
