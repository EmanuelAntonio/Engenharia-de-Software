Requisitos específicos
======================

Requisitos funcionais
---------------------

- **Requisito funcional 1:** O jogo deve permitir ao usuário criar um perfil dentro do software, onde ele definirá o seu nick que será utilizado durante toda a experiência e o nome da empresa de desenvolvimento de software que acaba de criar;
- **Requisito funcional 2:** O jogo deve apresentar conceitos de engenharia de software por meio de dicas para resolução dos problemas propostos dentro do software;
- **Requisito funcional 3:** O enredo do jogo se passará durante os 40 primeiros anos da criação da engenharia de software e mostrará a evolução dos métodos de desenvolvimento de software;
- **Requisito funcional 4:** O jogo deve apresentar uma proposta de progressão de 3 fases, onde mostrará o desenvolvimento e a evolução da empresa durante o enredo do jogo;
- **Requisito funcional 5:** Cada fase do jogo representa uma evolução no tamanho da empresa, o que impactará nos recursos de contratação de funcionários e pesquisa. Inicialmente a empresa terá apenas um funcionário, o próprio usuário, na segunda fase é possível contratar até 2 funcionários adicionais e na última fase até 4 funcionários adicionais, totalizando 5 funcionários;
- **Requisito funcional 6:** O jogo deve oferecer ao usuário a possibilidade de aceitar o desenvolvimento de um novo projeto que será feito por meio de uma opção no menu do jogo. Esses projetos deverão aparecer em um grupo de 5, que será atualizado de forma aleatória a cada 1 mês do tempo do jogo;
- **Requisito funcional 7:** Cada projeto tem um tipo de empresa, nome da empresa, descricao, valor de pagamento pela conclusão, a multa mensal pelo atraso, o tamanho da empresa, a experiência média de uso de software dos usuários, os valores de prioridade para cada uma das 9 tarefas escolhidas pelo jogador, o número de pontos de erro, pontos de tecnologia e pontos de design;
- **Requisito funcional 8:** Cada tipo de empresa tem o nome do tipo de empresa, uma lista com possíveis nomes para a empresa, um lista com possíveis descrições para o projeto, uma dificuldade mínima e máxima para que esse projeto apareça para o jogador, um pagamento mínimo e máximo, uma multa mensal mínima e máxima, um tamanho mínimo e máximo, uma experiência de usuário mínima e máxima e os valores bases para cada uma das 9 prioridades. Os valores mínimos e máximos servem para gerar os valores que serão utilizados por cada empresa daquele tipo;
- **Requisito funcional 9:** Os tipos de empresas disponíveis serão: Padaria, Escritório de Advocacia, Posto de Gasolina, Supermercado, Contabilidade, Petrolífera, Banco, Posto Avançado Alienígena;
- **Requisito funcional 10:** Os pontos de desenvolvimento de um projeto serão divididos em 3 etapas: Planejamento, Implementação e Validação. Cada etapa pode ocorrer mais de uma vez dependendo da metodologia aplicada, porém os pontos de prioridade são definidos apenas uma vez;
- **Requisito funcional 11:** Os pontos de prioridade são distribuídos pelo usuário para cada etapa. Etapa 1: Coleta de Dados com o Cliente, Estudo do Domínio da Aplicação, Documentação. Etapa 2: Legibilidade do Código, Qualidade da Solução, Desenvolvimento de Interface. Etapa 3: Realização de Testes, Avaliação do Cliente, Implementação;
- **Requisito funcional 12:** Para cada projeto gerado, seus parâmetros de nome da empresa, descricao, valor de pagamento, multa mensal de atraso, tamanho da empresa, experiência do usuário, pontos de design solicitados e pontos de tecnologia solicitados serão definidos de forma aleatória dentro dos mínimos e máximos definidos para o tipo da empresa. Além disso os pontos de prioridade em design e os pontos de prioridade em tecnologia serão definidos a partir dos valores bases para aquele tipo de empresa e serão modificados pelos demais atributos do projeto. Esses pontos de prioridade determinam quão rápido é a geração de pontos de design e pontos de tecnologia para cada prioridade. A satisfação do cliente depende de atender a quantidade de pontos de design e pontos de tecnologia solicitado;
- **Requisito funcional 13:** Durante o desenvolvimento do projeto os funcionários gerarão ponto de pesquisa para a empresa, que futuramente serão usados no jogo para pesquisar sobre determinada metodologia de desenvolvimento de software. Essas metodologias possuirão nome, custo em pontos de pesquisa, custo em dinheiro e tempo de pesquisa;
- **Requisito funcional 14:** Durante o desenvolvimento do projeto os funcionários gerarão pontos de tecnologia para o projeto, o que fará com que a empresa ganhe experiência em determinada área de conhecimento, e esses pontos serão distribuídos ao encerramento do projeto. Funcionários com mais habilidade de tecnologia codificam funcionalidades mais rápido, o que gera um menor gasto de recursos;
- **Requisito funcional 15:** Durante o desenvolvimento do projeto os funcionários gerarão pontos de design para o projeto, o que fará com que a empresa ganhe experiência na área de interação humano computador, e esses pontos serão distribuídos ao encerramento do projeto. Funcionários com mais habilidade de design desenvolvem melhores interfaces, o que impacta na satisfação do cliente;
- **Requisito funcional 16:** Durante o desenvolvimento do projeto os funcionários gerarão pontos de erro para o projeto, o que fará com que a satisfação do cliente caia na entrega do projeto;
- **Requisito funcional 17:** Todos os pontos, de erro, pesquisa, design e tecnologia serão criados de acordo com a escolha correta da metodologia de desenvolvimento, e os pontos de prioridades distribuídas pelo usuário;
- **Requisito funcional 18:** A empresa terá uma verba inicial para manutenção. A cada mês do jogo será descontado desta verba o custo de manutenção do local onde a empresa está instalada e dos salários dos funcionários. Para cada uma das 3 fases o valor da manutenção do local irá ser diferente, sendo maior a cada próxima fase. Se toda a verba da empresa acabar o jogo se encerra com a derrota do usuário;
- **Requisito funcional 19:** A empresa poderá contratar novos funcionários se houver vaga. Para isso será exibida uma tela para escolha da contratação, onde é mostrada o habilidade em design, tecnologia e pesquisa. Quanto maior for esses níveis, mais pontos eles gerarão. Além de exibir o salário daquele candidato. O salário dos candidatos será calculado a partir da habilidade média daquela pessoa;
- **Requisito funcional 20:** O salário do funcionário será reajustado a cada ano de acordo com a habilidade média atual;
- **Requisito funcional 21:** O jogo deverá permitir ao usuário que possa demitir algum funcionário e abrirá uma nova vaga para contratação;
- **Requisito funcional 22:** A lista de candidatos às novas vagas deverá ter um total de 5 pessoas, onde essa lista será preenchida aleatoriamente e atualizada a cada 2 meses no tempo do jogo;
- **Requisito funcional 23:** O jogo deverá fornecer ao usuário a possibilidade de pesquisar novas metodologias apenas clicando em cima de algum funcionário. Esse funcionário não poderá ser utilizado dentro de um projeto enquanto estiver realizando esta atividade;
- **Requisito funcional 24:** O jogo deverá fornecer ao usuário a possibilidade de criar a própria metodologia baseada nas metodologias já pesquisadas;
- **Requisito funcional 25:** O jogo deverá fornecer ao usuário a possibilidade de salvar o progresso do jogo;
- **Requisito funcional 26:** O jogo decorrerá até a era das metodologias ágeis, a história contada a partir desse momento não irá se alterar, mas o usuário poderá continuar jogando.

Requisitos não funcionais
-------------------------

- **Requisito não funcional 1:** O jogo deve ser totalmente aderente aos principais conceitos de Orientação a Objeto (encapsulamento, herança, polimorfismo, tipificação forte, etc.);
- **Requisito não funcional 2:** O jogo deve ser desenvolvido utilizando a engine Unity;
- **Requisito não funcional 3:** O jogo deve ser desenvolvido utilizando a linguagem C#;
- **Requisito não funcional 4:** O jogo deve ser desenvolvido para as plataformas windows e linux;
- **Requisito não funcional 5:** O jogo deve ser desenvolvido em gráficos 3D utilizando o estilo de câmera isométrica;
- **Requisito não funcional 6:** Os modelos 3D devem ser criados utilizando Blender 3D;
- **Requisito não funcional 7:** O jogo deve ter desempenho otimizado para funcionar em diferentes hardwares;
- **Requisito não funcional 8:** O jogo deve salvar o progresso do usuário automaticamente em intervalos de 1 minuto;
- **Requisito não funcional 9:** O jogo deve ao iniciar abrir o jogo salvo mais recente;
- **Requisito não funcional 10:** O jogo deve suportar ser iniciado em diferentes resoluções;
