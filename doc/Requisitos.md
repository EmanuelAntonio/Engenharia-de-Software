Requisitos específicos
======================

Requisitos funcionais
---------------------

- **Requisito funcional 1:** O jogo deve permitir ao usuário criar um perfil dentro do software, onde ele definirá o seu nick que será utilizado durante toda a experiência e o nome da empresa de desenvolvimento de software que acaba de criar;
- **Requisito funcional 2:** O jogo deve apresentar conceitos de engenharia de software por meio de dicas para resolução dos problemas propostos dentro do software;
- **Requisito funcional 3:** O enredo do jogo se passará durante os 40 primeiros anos da criação da engenharia de software e mostrará a evolução dos métodos de desenvolvimento de software;
- **Requisito funcional 4:** O jogo deve apresentar uma proposta de progressão de 3 fases, onde mostrará o desenvolvimento e a evolução da empresa durante o enredo do jogo;
- **Requisito funcional 5:** Cada fase do jogo representa uma evolução no tamanho da empresa, o que impactará nos recursos de contratação de funcionários e pesquisa. Inicialmente a empresa terá apenas um funcionário, o próprio usuário, na segunda fase é possível contratar até 2 funcionários adicionais e na última fase até 4 funcionários adicionais, totalizando 5 funcionários;
- **Requisito funcional 6:** O jogo deve oferecer ao usuário a possibilidade de aceitar o desenvolvimento de um novo projeto que será feito por meio de uma opção no menu do jogo. Esses projetos deverão aparecer em um grupo de 5, que será atualizado de forma aleatória em cada 2 meses do tempo do jogo;
- **Requisito funcional 7:** Cada projeto tem um valor de pagamento pela conclusão, a multa pelo atraso, o tipo da empresa, o tamanho da empresa e a experiência média de uso de software dos usuários;
- **Requisito funcional 8:** Os tipos de empresas disponíveis serão: Supermercado, Padaria, Petrolífera, Posto de Gasolina, Contabilidade, Posto Avançado Alienígena, Banco, Escritório de Advocacia;
- **Requisito funcional 9:** Os pontos de desenvolvimento de um projeto serão divididos em 3 etapas: Planejamento, Implementação e Validação. Cada etapa pode ocorrer mais de uma vez dependendo da metodologia aplicada, porém os pontos de prioridade são definidos apenas uma vez;
- **Requisito funcional 10:** Os pontos de prioridade são distribuídos pelo usuário para cada etapa. Etapa 1: Coleta de Dados com o Cliente, Estudo do Domínio da Aplicação, Documentação. Etapa 2: Legibilidade do Código, Qualidade da Solução, Desenvolvimento de Interface. Etapa 3: Realização de Testes, Avaliação do Cliente, Implementação;
- **Requisito funcional 11:** Para cada projeto gerado, será definido os pontos de prioridade mais adequados para ele utilizando os atributos de tipo de empresa, tamanho da empresa e a experiência média de uso de software. Quanto mais próximo o usuário definir dos valores padrão, melhor será a satisfação do cliente no final;
- **Requisito funcional 12:** Durante o desenvolvimento do projeto os funcionários gerarão ponto de pesquisa para a empresa, que futuramente serão usados no jogo para pesquisar sobre determinada metodologia de desenvolvimento de software. Essas metodologias posssuirão nome, custo em pontos de pesquisa, custo em dinheiro e tempo de pesquisa;
- **Requisito funcional 13:** Durante o desenvolvimento do projeto os funcionários gerarão pontos de tecnologia para o projeto, o que fará com que a empresa ganhe experiência em determinada área de conhecimento, e esses pontos serão distribuídos ao encerramento do projeto. Funcionários com mais habilidade de tecnologia codificam funcionalidades mais rápido, o que gera um menor gasto de recursos;
- **Requisito funcional 14:** Durante o desenvolvimento do projeto os funcionários gerarão pontos de design para o projeto, o que fará com que a empresa ganhe experiência na área de interação humano computador, e esses pontos serão distribuídos ao encerramento do projeto. Funcionários com mais habilidade de design desenvolvem melhores interfaces, o que impacta na satisfação do cliente;
- **Requisito funcional 15:** Durante o desenvolvimento do projeto os funcionários gerarão pontos de erro para o projeto, o que fará com que a satisfação do cliente caia na entrega do projeto;
- **Requisito funcional 16:** Todos os pontos, de erro, pesquisa, design e tecnologia serão criados de acordo com a escolha correta da metodologia de desenvolvimento, e os pontos de prioridades distribuídas pelo usuário;
- **Requisito funcional 17:** A empresa terá uma verba inicial para manutenção. A cada mês do jogo será descontado desta verba o custo de manutenção do local onde a empresa está instalada e dos salários dos funcionários. Para cada uma das 3 fases o valor da manutenção do local irá ser diferente, sendo maior a cada próxima fase. Se toda a verba da empresa acabar o jogo se encerará com a derrota do usuário;
- **Requisito funcional 18:** A empresa poderá contratar novos funcionários se houver vaga. Para isso será exibida uma tela para escolha da contratação, onde é mostrada o nível de design, tecnologia e pesquisa. Quanto maior for esses níveis, mais pontos eles gerarão. Além de exibir o salário daquele candidato. O salário dos candidatos será calculado a partir do nível médio daquela pessoa;
- **Requisito funcional 19:** O salário do funcionário será reajustado a cada ano de acordo com o nível médio atual;
- **Requisito funcional 20:** O jogo deverá permitir ao usuário que possa demitir algum funcionário e abrirá uma nova vaga para contratação;
- **Requisito funcional 21:** A lista de candidatos às novas vagas deverá ter um total de 5 pessoas, onde essa lista será preenchida aleatoriamente e atualizada a cada 2 meses no tempo do jogo;
- **Requisito funcional 22:** O jogo deverá fornecer ao usuário a possibilidade de pesquisar novas metodologias apenas clicando em cima de algum funcionário. Esse funcionário não poderá ser utilizado dentro de um projeto enquanto estiver realizando esta atividade;
- **Requisito funcional 23:** O jogo deverá fornecer ao usuário a possibilidade de criar a própria metodologia baseada nas metodologias já pesquisadas;
- **Requisito funcional 24:** O jogo deverá fornecer ao usuário a possibilidade de salvar o progresso do jogo;
- **Requisito funcional 25:** O jogo decorrerá até a era das metodologias ágeis, a história contada a partir desse momento não irá se alterar, mas o usuário poderá continuar jogando.

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
