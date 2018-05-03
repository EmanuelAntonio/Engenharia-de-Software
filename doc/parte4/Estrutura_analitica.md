Estrutura Analítica
===================

Paradigma
---------

O paradigma de desenvolvimento de software que será empregado para o desenvolvimento do jogo para apoio ao ensino de Engenharia de Software será o modelo espiral.

Um dos motivos que levaram o grupo a adotar esse modelo é a natureza de desenvolvimento de um jogo, já que esse desenvolvimento é um processo incremental e volátil, onde podemos tanto inserir quanto remover requisitos durante o seu desenvolvimento. Outro fator importante para a escolha do modelo espiral é o fato de que este trabalho se refere a um projeto idealizado e desenvolvido pelas mesmas pessoas, onde nós mesmos durante o desenvolvimento conseguimos vislumbrar diferentes recursos necessários que faltam no documento de requisitos.

Contando com esses fatores, se utilizarmos alguma metodologia mais rígida, o trabalho final seria prejudicado.


Etapas
------

- **Especificação de requisitos:** Criação e edição do documento de requisitos do projeto, será revisitado a cada ciclo de desenvolvimento.
- **Criação dos modelos 3D:** Será fundamental no primeiro ciclo de desenvolvimento, onde os modelistas criarão o cenário 3D que será empregado no jogo. Será revisitado apenas quando for adicionado requisitos que incluem novas fases ou alteram os aspectos visuais de fases existente.
- **Programação do jogo:** Etapa onde será desenvolvido os requisitos gerados na primeira fase bem como as alterações requisitadas na fase de testes.
- **Realização de testes:** Etapa final de um ciclo de desenvolvimento, onde será testado o protótipo criado nas etapas anteriores e será sugerido correções. Em caso de correções de erros será encaminhado novamente para a etapa de programação no próximo ciclo.


Recursos
--------

- **Recursos humanos:** Analista de requisitos, Gerente de projeto, Desenvolvedor, Modelista 3D
- **Recursos de hardware:** 3 Computadores para desenvolvimento com acesso a internet
- **Recursos software:** Editor de texto, StarUML, CaseComplete, ProjectLibre, Git, GitHub, Google Drive, Unity


Documentos
----------

- Especificação de requisitos
- Diagrama de classes
- Estrutura analítica
- Cronograma


Cronograma
----------

![Cronograma](cronograma.png?raw=true "Cronograma")


Métrica de software
-------------------

A métrica de software que o grupo decidiu adotar para realização do projeto é a de pontos de função. Por não depender da metodologia utilizada e por fazer uma previsão baseada nas funcionalidade que terão que ser implementadas, essa métrica faz uma boa estimativa inicial, já que entrega o tamanho funcional do software baseado na quantificação dos requisitos funcionais do usuário.

#### Definição do tipo de contagem:

Projeto de desenvolvimento.

#### Definição do escopo da aplicação:

Jogo destinado a professores e alunos com o objetivo de auxiliar no ensino de engenharia de software.

#### Cálculo de ponto de função:

- **ALI:** Perfil
    - **DER:** Nick, nome da empresa, dia, mes, ano, etapa, maximo de funcionarios, pontos de pesquisa, verba
    - **RLR:** Perfil, Projeto, Funcionário, Pesquisa
    - **Complexidade:** Baixa
    - **Pontos de Função:** 7


- **ALI:** Projeto
    - **DER:** Valor pagamento, multa de atraso, tipo de empresa, tamanho da empresa, experiencia do usuario, prioridade em coleta de dados, prioridade em estudo do dominio, prioridade em documentação, prioridade em legibilidade, prioridade em qualidade da solução, prioridade em interface, prioridade em testes, prioridade em avaliação do cliente, prioridade em implantação, pontos de erro, pontos de tecnologia, pontos de design
    - **RLR:** Projeto, Perfil
    - **Complexidade:** Baixa
    - **Pontos de Função:** 7


- **ALI:** Funcionário
    - **DER:** Habilidade em tecnologia, habilidade em design, salario
    - **RLR:** Funcionário, Perfil
    - **Complexidade:** Baixa
    - **Pontos de Função:** 7


- **ALI:** Pesquisa
    - **DER:** Nome, custo em pontos de pesquisa, custo em dinheiro, tempo de pesquisa
    - **RLR:** Perfil, Perfil
    - **Complexidade:** Baixa
    - **Pontos de Função:** 7


- **EE:** Criar perfil
    - **ALR:** Perfil
    - **DER:** Nick, nome da empresa
    - **Complexidade:** Baixa
    - **Pontos de Função:** 3


- **CE:** Selecionar perfil
    - **ALR:** Perfil
    - **DER:** Nick, nome da empresa, dia, mes, ano, etapa, verba
    - **Complexidade:** Baixa
    - **Pontos de Função:** 3


- **EE:** Aceitar projetos
    - **ALR:** Perfil, Projeto
    - **DER:** Verba, valor pagamento, multa de atraso, tipo de empresa, tamanho da empresa, experiencia do usuario
    - **Complexidade:** Média
    - **Pontos de Função:** 4


- **EE:** Distribuir pontos de prioridade
    - **ALR:** Projeto
    - **DER:** Prioridade em coleta de dados, prioridade em estudo do dominio, prioridade em documentação, prioridade em legibilidade, prioridade em qualidade da solução, prioridade em interface, prioridade em testes, prioridade em avaliação do cliente, prioridade em implantação
    - **Complexidade:** Baixa
    - **Pontos de Função:** 3


- **EE:** Contratar funcionarios
    - **ALR:** Perfil, Funcionário
    - **DER:** Maximo de funcionarios, verba, habilidade em tecnologia, habilidade em design, salario
    - **Complexidade:** Média
    - **Pontos de Função:** 4


- **SE:** Exibir reajustes
    - **ALR:** Perfil, Funcionário
    - **DER:** Dia, mes, ano, verba, habilidade em tecnologia, habilidade em design, salario
    - **Complexidade:** Média
    - **Pontos de Função:** 5


- **EE:** Pesquisar metodologias
    - **ALR:** Perfil, Pesquisa, Funcionário
    - **DER:** Pontos de pesquisa, verba, habilidade em tecnologia, nome, custo em pontos de pesquisa, custo em dinheiro, tempo de pesquisa
    - **Complexidade:** Alta
    - **Pontos de Função:** 6


- **EE:** Criar metodologia
    - **ALR:** Pesquisa
    - **DER:** Nome
    - **Complexidade:** Baixa
    - **Pontos de Função:** 3


- **EE:** Salvar o jogo
    - **ALR:** Perfil, Projeto, Funcionario, Pesquisa
    - **DER:** Dia, mes, ano, etapa da empresa, maximo de funcionarios da empresa, pontos de pesquisa da empresa, verba da empresa, valor pagamento do projeto, multa de atraso do projeto, tipo de empresa do projeto, tamanho da empresa do projeto, experiencia do usuario do projeto, prioridade em coleta de dados, prioridade em estudo do dominio, prioridade em documentação, prioridade em legibilidade, prioridade em qualidade da solução, prioridade em interface, prioridade em testes, prioridade em avaliação do cliente, prioridade em implantação, pontos de erro do projeto, pontos de tecnologia do projeto, pontos de design do projeto, habilidade em tecnologia do funcionário, habilidade em design do funcionário, salario, nome da pesquisa
    - **Complexidade:** Alta
    - **Pontos de Função:** 6

**Total:** 65


#### Cálculo do fator de ajuste:

- **Comunicação de dados:** 2
- **Processamento distribuído:** 0
- **Performance:** 5
- **Configuração do equipamento:** 2
- **Volume de transações:** 1
- **Entrada de dados on-line:** 0
- **Interface com o usuário:** 4
- **Atualização on-line:** 0
- **Processamento complexo:** 4
- **Reusabilidade:** 1
- **Facilidade de implantação:** 4
- **Facilidade operacional:** 5
- **Múltiplos locais:** 1
- **Facilidade de mudanças (Flexibilidade):** 2

**Total:** 31  
**Fator de ajuste:** (31 * 0.01) + 0.65 = 0.96

#### Resultado final:

**Pontos de função ajustado:** 65 * 0.96 = 62.4
